using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CredoLoan.Api.ViewModels
{
    public class SignUpViewModel
    {
        //[PersonalData]
        //[Required(ErrorMessage = "Personal number is required")]
        public string PersonalNumber { get; set; }

        //[PersonalData]
        //[Required(ErrorMessage = "User name field is required")]
        //[StringLength(100, ErrorMessage = "{0} must be between {2} to {1} characters in length", MinimumLength = 4)]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Password field is required")]
        //[StringLength(100, ErrorMessage = "{0} must be between {2} to {1} characters in length", MinimumLength = 8)]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at least 3 out of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "Confirm passwords do not match with password")]
        public string ConfirmPassword { get; set; }
    }
}
