using CredoLoan.Core.Models;
using CredoLoan.Core.SharedKernel;

namespace CredoLoan.Core.Services
{
    public interface IAuthService
    {
        Task<ResponseResult> SignUp(SignUpModel model);
        Task<ResponseResult<AuthModel>> SignIn(SignInModel model);

    }
}
