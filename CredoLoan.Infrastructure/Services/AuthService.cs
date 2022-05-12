using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using CredoLoan.Core.Models;
using CredoLoan.Core.Services;
using CredoLoan.Data.Entities;
using CredoLoan.Infrastructure.Resources;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CredoLoan.Core.SharedKernel;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CredoLoan.Core.Extensions;

namespace CredoLoan.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Client> _clientUserManager;
        private readonly ICredoCssService _credoCssService;
        private readonly JwtOptions _jwtOptions;
        private readonly IMapper _mapper;

        public AuthService(
            UserManager<Client> clientUserManager,
            ICredoCssService credoCssService,
           IOptions<JwtOptions> jwtOptions,
            IMapper mapper)
        {
            _credoCssService = credoCssService;
            _clientUserManager = clientUserManager;
            _jwtOptions = jwtOptions.Value;
            _mapper = mapper;
        }
        public async Task<ResponseResult> SignUp(SignUpModel model)
        {
            try
            {
                var user = _mapper.Map<Client>(model);

                var findPersonResult = await _credoCssService.FindPerson(user.PersonalNumber);

                if (findPersonResult.IsError)
                {
                    return new ResponseResult($"Failed to find Person with following error: {findPersonResult.Message}", true);

                }

                user.Name = findPersonResult.Data.Result.FirstName;
                user.SurName = findPersonResult.Data.Result.LastName;
                user.PersonalNumber = findPersonResult.Data.Result.PersonalN;
                user.DateOfBirth = findPersonResult.Data.Result.BirthDate.ParseBirthDate();

                var existingUser = await _clientUserManager.FindByNameAsync(model.UserName);

                if (existingUser != null)
                {
                    return new ResponseResult(StringResources.UserNameAlreadyExists, true);
                }

                var createUserResult = await _clientUserManager.CreateAsync(user, model.Password);

                if (!createUserResult.Succeeded)
                {
                    return new ResponseResult(createUserResult.Errors.FirstOrDefault()?.Description ?? StringResources.InternalErrorOccured, true);
                }
                return new ResponseResult(StringResources.SuccessfullyCreated);

            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message, true);
            }
        }
        public async Task<ResponseResult<AuthModel>> SignIn(SignInModel model)
        {
            try
            {
                var clientUser = await _clientUserManager.FindByNameAsync(model.UserName);

                if (clientUser == null)
                {
                    return new ResponseResult<AuthModel>(null, StringResources.UserNameOrPasswordIncorrect, true);
                }
                if (!await _clientUserManager.CheckPasswordAsync(clientUser, model.Password))
                {
                    return new ResponseResult<AuthModel>(null, StringResources.UserNameOrPasswordIncorrect, true);
                }

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, clientUser.Id),
                    new Claim(ClaimTypes.Name, clientUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = GetToken(authClaims);

                var authModel = new AuthModel
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpiresIn = token.ValidTo,
                    Name = clientUser.Name,
                    SurName = clientUser.SurName,
                    UserName = clientUser.UserName,
                    PersonalNumber = clientUser.PersonalNumber,
                };

                return new ResponseResult<AuthModel>(authModel);

            }
            catch (Exception ex)
            {
                return new ResponseResult<AuthModel>(null, ex.Message, true);
            }
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var key = _jwtOptions.IssuerSigningKey;
            var issuer = _jwtOptions.Issuer;
            var audience = _jwtOptions.Audience;

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
