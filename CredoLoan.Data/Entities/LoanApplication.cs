using CredoLoan.Core.Enums;
using CredoLoan.Core.SharedKernel;

namespace CredoLoan.Data.Entities
{
    public class LoanApplication : BaseEntity
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Period { get; set; }
        public LoanType LoanType { get; set; }
        public LoanStatus LoanStatus { get; set; }
        public Client AppliedBy { get; set; }
    }
}
