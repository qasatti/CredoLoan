using CredoLoan.Core.Enums;

namespace CredoLoan.Core.Models
{
    public class LoanApplicationModel
    {
        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Period { get; set; }

        public LoanType LoanType { get; set; }

        public LoanStatus LoanStatus { get; set; }
    }

    public class CreateLoanApplicationModel: LoanApplicationModel
    {
        public string AppliedById { get; set; }
    }

    public class EditLoanApplicationModel : CreateLoanApplicationModel
    {
        public string Id { get; set; }        
    }
    public class DetailLoanApplicationModel : LoanApplicationModel
    {
        public string Id { get; set; }
        public string AppliedByClientUserName { get; set; }
        public string AppliedByClientId { get; set; }
    }
}
