using CredoLoan.Api.ViewModels;
using FluentValidation;

namespace CredoLoan.Api.Validations
{
    public class EditLoanApplicationViewModelValidator : AbstractValidator<EditLoanApplicationViewModel>
    {
        public EditLoanApplicationViewModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.LoanType).NotEmpty().IsInEnum();
            RuleFor(x => x.LoanStatus).NotEmpty().IsInEnum();
            RuleFor(x => x.Currency).NotEmpty();
            RuleFor(x => x.Period).NotEmpty();
        }
    }
}
