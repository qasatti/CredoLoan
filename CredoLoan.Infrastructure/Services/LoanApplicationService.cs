using AutoMapper;
using CredoLoan.Core.Models;
using CredoLoan.Core.Services;
using CredoLoan.Data.Entities;
using CredoLoan.Infrastructure.Resources;
using CredoLoan.Core.SharedKernel;
using CredoLoan.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CredoLoan.Infrastructure.Services
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoanApplicationService(
            ILoanApplicationRepository loanApplicationRepository,
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            _loanApplicationRepository = loanApplicationRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseResult<List<DetailLoanApplicationModel>>> List(string clientId)
        {
            try
            {
                var entities = await _loanApplicationRepository.GetAll()
                      .AsNoTracking()
                      .Include(x => x.AppliedBy)
                      .Where(x => x.AppliedBy.Id==clientId)
                      .ToListAsync();

                return new ResponseResult<List<DetailLoanApplicationModel>>(_mapper.Map<List<DetailLoanApplicationModel>>(entities));
            }
            catch (Exception ex)
            {
                return new ResponseResult<List<DetailLoanApplicationModel>>(null, ex.Message, true);
            }
        }

        public async Task<ResponseResult<DetailLoanApplicationModel>> Get(string id, string clientId)
        {
            try
            {
                var entity = await _loanApplicationRepository.GetById(id)
                      .AsNoTracking()
                      .Include(x => x.AppliedBy)
                      .Where(x => x.Id.Equals(id) && x.AppliedBy.Id.Equals(clientId))
                      .FirstOrDefaultAsync();

                if (entity == null)
                {
                    return new ResponseResult<DetailLoanApplicationModel>(null,StringResources.RecordNotFound, true);

                }
                return new ResponseResult<DetailLoanApplicationModel>(_mapper.Map<DetailLoanApplicationModel>(entity));
            }
            catch (Exception ex)
            {
                return new ResponseResult<DetailLoanApplicationModel>(null, ex.Message, true);
            }
        }

        public async Task<ResponseResult> Create(CreateLoanApplicationModel model)
        {
            try
            {
                var currentClient = await _userRepository.GetById(model.AppliedById).FirstOrDefaultAsync();

                var entity = _mapper.Map<LoanApplication>(model);
                entity.AppliedBy = currentClient;

                await _loanApplicationRepository.Create(entity);
                return new ResponseResult(StringResources.SuccessfullyCreated);
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message, true);
            }
        }

        public async Task<ResponseResult> Update(EditLoanApplicationModel model)
        { 
            try
            {
                var entity = await _loanApplicationRepository.GetById(model.Id)
                    .Include(x => x.AppliedBy)
                    .Where(x =>  x.AppliedBy.Id.Equals(model.AppliedById))
                    .FirstOrDefaultAsync();
                if (entity == null)
                {
                    return new ResponseResult(StringResources.RecordNotFound, true);

                }
                if (entity.LoanStatus == Core.Enums.LoanStatus.Approved || entity.Amount < 0)
                {
                    return new ResponseResult(StringResources.LoanEditNotAlowed, true);
                }

                entity.Amount = model.Amount;
                entity.Currency = model.Currency;
                entity.LoanStatus = model.LoanStatus;
                entity.Period = model.Period;
                entity.LoanType = model.LoanType;
                await _loanApplicationRepository.Update(entity);
                return new ResponseResult(StringResources.SuccessfullyUpdated);
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message, true);
            }
        }

    }
}
