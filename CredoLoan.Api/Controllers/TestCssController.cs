using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CredoLoan.Api.Extensions;
using CredoLoan.Core.Services;
using CredoLoan.Core.SharedKernel;
using CredoLoan.Core.Models;

namespace CredoLoan.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class TestCssController : ControllerBase
    {
        private readonly ICredoCssService _credoCssService;
        private readonly ILogger<TestCssController> _logger;

        public TestCssController(
            ICredoCssService credoCssService,
            ILogger<TestCssController> logger)
        {
            _credoCssService = credoCssService;
            _logger = logger;
        }

        [HttpGet(nameof(CssToken))]
        public async Task<ActionResult> CssToken()
        {
            if (!ModelState.IsValid)
                return BadRequest(ResponseResult.Failure(ModelState.GetErrors()));

            return Ok(ResponseResult<string>.Success(await _credoCssService.CssAuthorize()));
        }

        [HttpGet(nameof(FindPerson))]
        public async Task<IActionResult> FindPerson(string personNumber)
        {
            if (!ModelState.IsValid)
                return BadRequest(ResponseResult.Failure(ModelState.GetErrors()));

            return Ok(ResponseResult<CssFindPersonResponseModel>.Success(await _credoCssService.FindPerson(personNumber)));
        }
    }
}

