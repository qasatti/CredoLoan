using PropertyChanged;

namespace CredoLoan.Core.SharedKernel
{
    public interface IBaseEntity
    {
        [DoNotNotify]
        public string Id { get; set; }
        HashSet<string> GetProperties();
    }
}
