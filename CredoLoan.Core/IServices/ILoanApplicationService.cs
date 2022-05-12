using CredoLoan.Core.Models;
using CredoLoan.Core.SharedKernel;

namespace CredoLoan.Core.Services
{
    public interface ILoanApplicationService
    {
        Task<ResponseResult<List<DetailLoanApplicationModel>>> List(string clientId);
        Task<ResponseResult<DetailLoanApplicationModel>> Get(string id, string clientId);
        Task<ResponseResult> Create(CreateLoanApplicationModel model);
        Task<ResponseResult> Update(EditLoanApplicationModel model);

    }
}
