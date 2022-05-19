namespace CredoLoan.Core.Models
{
    public class DetailLoanApplicationResponseModel : LoanApplicationBaseModel
    {
        public string Id { get; set; }
        public string AppliedByClientUserName { get; set; }
        public string AppliedByClientId { get; set; }
    }
}
