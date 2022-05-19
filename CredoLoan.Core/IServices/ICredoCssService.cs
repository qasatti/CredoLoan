using CredoLoan.Core.Models;
using CredoLoan.Core.SharedKernel;

namespace CredoLoan.Core.Services
{
    public interface ICredoCssService
    {
        Task<CssFindPersonResponseModel> FindPerson(string personNumber);
        Task<string> CssAuthorize();
    }
}
