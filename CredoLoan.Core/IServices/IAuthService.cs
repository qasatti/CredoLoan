using CredoLoan.Core.Models;
using CredoLoan.Core.SharedKernel;

namespace CredoLoan.Core.Services
{
    public interface IAuthService
    {
        Task<SignUpResponseModel> SignUp(SignUpModel model);
        Task<SignInResponseModel> SignIn(SignInModel model);

    }
}
