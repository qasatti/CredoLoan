using CredoLoan.Core.SharedKernel;

namespace CredoLoan.Data.IRepositories
{
    public interface IBaseRepository<T> : IDisposable where T : IBaseEntity
    {
        IQueryable<T> GetById(string id);

        Task<string> Create(T entity);

        Task Update(T entity);

        Task<bool> DeleteById(string id);

        IQueryable<T> GetAll();

        Task<bool> DeleteRange(IEnumerable<IBaseEntity> entities);
    }
}
