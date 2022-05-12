using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CredoLoan.Api.Extensions;
using CredoLoan.Core.Services;
using CredoLoan.Core.SharedKernel;

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
            {
                return BadRequest(new ResponseResult(ModelState.GetErrors()));
            }

            var result = await _credoCssService.CssAuthorize();

            if (result.IsError)
            {
                _logger.LogError(result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet(nameof(FindPerson))]
        public async Task<IActionResult> FindPerson(string personNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult(ModelState.GetErrors()));
            }

            var result = await _credoCssService.FindPerson(personNumber);

            if (result.IsError)
            {
                _logger.LogError(result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

