using CredoLoan.Core.SharedKernel;
using CredoLoan.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CredoLoan.Data.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IBaseEntity, new()
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> DeleteById(string id)
        {
            var entity = new T { Id = id };

            if (!_context.ChangeTracker.Entries<T>().Any(e => e.Entity.Id == entity.Id))
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
            }

            _context.Remove(entity);

            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteRange(IEnumerable<IBaseEntity> entities)
        {
            _context.RemoveRange(entities);

            return (await _context.SaveChangesAsync()) > 0;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetById(string id)
        {
            return _context.Set<T>().Where(x => x.Id == id);
        }

        public Task Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!_context.ChangeTracker.Entries<T>().Any(e => e.Entity.Id == entity.Id))
            {
                _context.Attach(entity);
            }

            foreach (var propertyName in entity.GetProperties().ToList())
            {
                if (propertyName != nameof(entity.Id))
                {
                    _context.Entry(entity).Property(propertyName).IsModified = true;
                }
            }

            return _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }

            // free native resources if there are any
            _context.Dispose();
        }
    }
}
