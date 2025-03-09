using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> query);
        IQueryable<TEntity> GetAllWithIncludes(params string[] includes);
        IQueryable<TEntity> GetAllWithIncludes(Expression<Func<TEntity, bool>> query, params string[] includes);
        TEntity? GetById(Guid id);
        TEntity Insert(TEntity obj);
        TEntity Update(TEntity obj);
        int SaveChanges();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void Rollback();
        void Dispose();
        void CreateSavePoint(string savepoint);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> objects, CancellationToken cancellationToken = default);
        void DeleteRange(IEnumerable<TEntity> objects);
        void Delete(TEntity obj);
    }
}
