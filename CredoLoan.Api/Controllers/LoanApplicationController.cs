using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CredoLoan.Api.Extensions;
using CredoLoan.Api.ViewModels;
using CredoLoan.Core.Models;
using CredoLoan.Core.Services;
using CredoLoan.Core.SharedKernel;
using REaDConnect.Api.Extensions;

namespace CredoLoan.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApplicationController : ControllerBase
    {
        private readonly ILoanApplicationService _loanApplicationService;
        private readonly IMapper _mapper;
        private readonly ILogger<LoanApplicationController> _logger;

        public LoanApplicationController(
            ILoanApplicationService loanApplicationService,
            IMapper mapper,
            ILogger<LoanApplicationController> logger)
        {
            _loanApplicationService = loanApplicationService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult(ModelState.GetErrors()));
            }

            var result = await _loanApplicationService.List(User.GetClientId());

            if (result.IsError)
            {
                _logger.LogError(result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult(ModelState.GetErrors()));
            }

            var result = await _loanApplicationService.Get(id, User.GetClientId());

            if (result.IsError)
            {
                _logger.LogError(result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLoanApplicationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult(ModelState.GetErrors()));
            }

            var createModel = _mapper.Map<CreateLoanApplicationModel>(model);
            createModel.AppliedById = User.GetClientId();
            var result = await _loanApplicationService.Create(createModel);

            if (result.IsError)
            {
                _logger.LogError(result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EditLoanApplicationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseResult(ModelState.GetErrors()));
            }

            var editModel = _mapper.Map<EditLoanApplicationModel>(model);
            editModel.AppliedById = User.GetClientId();
            var result = await _loanApplicationService.Update(editModel);

            if (result.IsError)
            {
                _logger.LogError(result.Message);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
