using CredoLoan.Core.Models;

namespace CredoLoan.Core.Services
{
    public interface ILoanApplicationService
    {
        Task<List<DetailLoanApplicationResponseModel>> List(string clientId);
        Task<DetailLoanApplicationResponseModel> Get(string id, string clientId);
        Task<CreateLoanApplicationResponseModel> Create(CreateLoanApplicationModel model);
        Task<EditLoanApplicationResponseModel> Update(EditLoanApplicationModel model);
    }
}
