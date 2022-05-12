using CredoLoan.Core.Enums;

namespace CredoLoan.Api.ViewModels
{
    public class CreateLoanApplicationViewModel
    {
        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Period { get; set; }

        public LoanType LoanType { get; set; }

        public LoanStatus LoanStatus { get; set; }
    }


    public class EditLoanApplicationViewModel : CreateLoanApplicationViewModel
    {
        public string Id { get; set; }
    }
}
