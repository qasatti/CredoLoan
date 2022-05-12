using CredoLoan.Api.ViewModels;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CredoLoan.Api.Validations
{
    public class SignUpViewModelValidator : AbstractValidator<SignUpViewModel>
    {
        public SignUpViewModelValidator()
        {
            RuleFor(x => x.PersonalNumber).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(4).MaximumLength(25);
            RuleFor(x => x.Password).Length(5, 15).Must(x => HasValidPassword(x)).WithMessage("Password must contain uppercase, lowercase,special character and number");
            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .Equal(x => x.Password).WithMessage("Confirm Password does not match with password");
        }
        private bool HasValidPassword(string pw)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
        }
    }
}
