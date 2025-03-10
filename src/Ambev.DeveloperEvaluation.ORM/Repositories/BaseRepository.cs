using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly DefaultContext _context;
        private readonly DbSet<TEntity> _dbSet;
        protected BaseRepository(DefaultContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> query)
        {
            return _dbSet.Where(query).AsQueryable();
        }

        public IQueryable<TEntity> GetAllWithIncludes(params string[] includes)
        {
            var result = _dbSet.AsQueryable();
            foreach (var i in includes)
            {
                result = result.Include(i);
            }
            return result;
        }

        public IQueryable<TEntity> GetAllWithIncludes(Expression<Func<TEntity, bool>> query, params string[] includes)
        {
            var result = _dbSet.Where(query).AsNoTracking().AsQueryable();
            foreach (var i in includes)
            {
                result = result.Include(i);
            }
            return result;
        }

        public TEntity? GetById(Guid id)
        {
            var ret = _dbSet.Find(id);
            if (ret != null)
            {
                _context.Entry(ret).State = EntityState.Detached;
            }
            return ret;
        }

        public TEntity Insert(TEntity obj)
        {
            return _dbSet.Add(obj).Entity;
        }

        public TEntity Update(TEntity obj)
        {
            _dbSet.Attach(obj);
            return _dbSet.Update(obj).Entity;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();
        public void Commit() => _context.Database.CommitTransaction();
        public void Rollback() => _context.Database.RollbackTransaction();
        public void Dispose() => _context.Database.CurrentTransaction?.Rollback();
        public void CreateSavePoint(string savepoint) => _context.Database.BeginTransaction().CreateSavepoint(savepoint);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> objects, CancellationToken cancellationToken = default)
            => _context.AddRangeAsync(objects, cancellationToken);

        public void DeleteRange(IEnumerable<TEntity> objects)
        { _dbSet.RemoveRange(objects); }

        public void Delete(TEntity obj)
        { _dbSet.Remove(obj); }
    }
}