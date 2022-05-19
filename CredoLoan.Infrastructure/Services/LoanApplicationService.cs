using AutoMapper;
using CredoLoan.Core.Models;
using CredoLoan.Core.Services;
using CredoLoan.Data.Entities;
using CredoLoan.Infrastructure.Resources;
using CredoLoan.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using CredoLoan.Core.Exceptions;

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

        public async Task<List<DetailLoanApplicationResponseModel>> List(string clientId)
        {
            var entities = await _loanApplicationRepository.GetAll()
                      .AsNoTracking()
                      .Include(x => x.AppliedBy)
                      .Where(x => x.AppliedBy.Id == clientId)
                      .ToListAsync();
            if (entities.Count == 0)
                throw new NotFoundException(StringResources.RecordNotFound);

            return _mapper.Map<List<DetailLoanApplicationResponseModel>>(entities);

        }

        public async Task<DetailLoanApplicationResponseModel> Get(string id, string clientId)
        {
            var entity = await _loanApplicationRepository.GetById(id)
                      .AsNoTracking()
                      .Include(x => x.AppliedBy)
                      .Where(x => x.Id.Equals(id) && x.AppliedBy.Id.Equals(clientId))
                      .FirstOrDefaultAsync();
            if (entity == null)
                throw new NotFoundException(StringResources.RecordNotFound);

            return _mapper.Map<DetailLoanApplicationResponseModel>(entity);
        }

        public async Task<CreateLoanApplicationResponseModel> Create(CreateLoanApplicationModel model)
        {
            var currentClient = await _userRepository.GetById(model.AppliedById).FirstOrDefaultAsync();
            if (currentClient == null)
                throw new BadRequestException(StringResources.UserNotExists);

            var entity = _mapper.Map<LoanApplication>(model);
            entity.AppliedBy = currentClient;

            return new CreateLoanApplicationResponseModel
            {
                Id = await _loanApplicationRepository.Create(entity)
            };
        }

        public async Task<EditLoanApplicationResponseModel> Update(EditLoanApplicationModel model)
        {
            var entity = await _loanApplicationRepository.GetById(model.Id)
                    .Include(x => x.AppliedBy)
                    .Where(x => x.AppliedBy.Id.Equals(model.AppliedById))
                    .FirstOrDefaultAsync();
            if (entity == null)
                throw new NotFoundException(StringResources.RecordNotFound);
            if (entity.LoanStatus == Core.Enums.LoanStatus.Approved ||
                entity.LoanStatus == Core.Enums.LoanStatus.Rejected)
                throw new BadRequestException(StringResources.LoanEditNotAlowed);

            entity.Amount = model.Amount;
            entity.Currency = model.Currency;
            entity.LoanStatus = model.LoanStatus;
            entity.Period = model.Period;
            entity.LoanType = model.LoanType;
            await _loanApplicationRepository.Update(entity);

            return new EditLoanApplicationResponseModel
            {
                Id = entity.Id
            };
        }

    }
}
