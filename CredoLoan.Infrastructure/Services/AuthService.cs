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
using CredoLoan.Core.Exceptions;

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
        public async Task<SignUpResponseModel> SignUp(SignUpModel model)
        {
            var user = _mapper.Map<Client>(model);
            var findPersonResult = await _credoCssService.FindPerson(user.PersonalNumber);
            user.Name = findPersonResult.Result.FirstName;
            user.SurName = findPersonResult.Result.LastName;
            user.PersonalNumber = findPersonResult.Result.PersonalN;
            user.DateOfBirth = findPersonResult.Result.BirthDate.ParseBirthDate();

            var existingUser = await _clientUserManager.FindByNameAsync(model.UserName);
            if (existingUser != null)
                throw new BadRequestException(StringResources.UserNameAlreadyExists);

            var createUserResult = await _clientUserManager.CreateAsync(user, model.Password);
            if (!createUserResult.Succeeded)
                throw new BadRequestException(createUserResult.Errors.FirstOrDefault()?.Description ?? StringResources.InternalErrorOccured);
           
            return new SignUpResponseModel
            {
                Id = user.Id
            };
        }
        public async Task<SignInResponseModel> SignIn(SignInModel model)
        {
            var clientUser = await _clientUserManager.FindByNameAsync(model.UserName);
            if (clientUser == null)
                throw new BadRequestException(StringResources.UserNameOrPasswordIncorrect);

            if (!await _clientUserManager.CheckPasswordAsync(clientUser, model.Password))
                throw new BadRequestException(StringResources.UserNameOrPasswordIncorrect);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, clientUser.Id),
                    new Claim(ClaimTypes.Name, clientUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var token = GetToken(authClaims);

            return new SignInResponseModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = token.ValidTo,
                Name = clientUser.Name,
                SurName = clientUser.SurName,
                UserName = clientUser.UserName,
                PersonalNumber = clientUser.PersonalNumber,
            };
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
