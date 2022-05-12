using CredoLoan.Data.Entities;
using CredoLoan.Data.IRepositories;

namespace CredoLoan.Data.Repositories
{
    public class UserRepository : BaseRepository<Client>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
