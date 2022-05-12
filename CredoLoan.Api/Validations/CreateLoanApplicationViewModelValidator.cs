using CredoLoan.Api.ViewModels;
using FluentValidation;

namespace CredoLoan.Api.Validations
{
    public class CreateLoanApplicationViewModelValidator : AbstractValidator<CreateLoanApplicationViewModel>
    {
        public CreateLoanApplicationViewModelValidator()
        {
            RuleFor(x => x.LoanType).NotEmpty();
            RuleFor(x => x.LoanStatus).NotEmpty();
            RuleFor(x => x.Currency).NotEmpty();
            RuleFor(x => x.Period).NotEmpty();
        }
    }
}
