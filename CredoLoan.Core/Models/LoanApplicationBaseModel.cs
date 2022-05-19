using CredoLoan.Core.Enums;

namespace CredoLoan.Core.Models
{
    public class LoanApplicationBaseModel
    {
        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Period { get; set; }

        public LoanType LoanType { get; set; }

        public LoanStatus LoanStatus { get; set; }
    }
   
}
