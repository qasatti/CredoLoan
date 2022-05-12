using CredoLoan.Data.Entities;
using CredoLoan.Data.IRepositories;

namespace CredoLoan.Data.Repositories
{
    public class LoanApplicationRepository : BaseRepository<LoanApplication>, ILoanApplicationRepository
    {
        public LoanApplicationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
