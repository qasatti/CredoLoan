using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CredoLoan.Api.Extensions;
using CredoLoan.Api.ViewModels;
using CredoLoan.Core.Models;
using CredoLoan.Core.Services;
using CredoLoan.Core.SharedKernel;

namespace CredoLoan.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientAuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientAuthController> _logger;

        public ClientAuthController(
            IAuthService authService,
            IMapper mapper,
            ILogger<ClientAuthController> logger)
        {
            _authService = authService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost(nameof(SignUp))]
        public async Task<ActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult(ModelState.GetErrors()));
            }

            var result = await _authService.SignUp(_mapper.Map<SignUpModel>(model));

            if (result.IsError)
            {
                _logger.LogError(result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost(nameof(SignIn))]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult(ModelState.GetErrors()));
            }

            var result = await _authService.SignIn(_mapper.Map<SignInModel>(model));

            if (result.IsError)
            {
                _logger.LogError(result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
