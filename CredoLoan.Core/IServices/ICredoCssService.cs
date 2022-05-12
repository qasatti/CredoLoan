using CredoLoan.Core.Models;
using CredoLoan.Core.SharedKernel;

namespace CredoLoan.Core.Services
{
    public interface ICredoCssService
    {
        Task<ResponseResult<CssFindPersonResponseModel>> FindPerson(string personNumber);
        Task<ResponseResult> CssAuthorize();

    }
}
