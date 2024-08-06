using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gear.Domain.Interfaces.Generic
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll(bool readOnly = false);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool readOnly = false);
        Task<IEnumerable<TEntity>> GetAllAsync(bool readOnly = false);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool readOnly = false);
        TEntity GetById(int id);
        TEntity GetById(object[] id);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByIdAsync(object[] id);
        void Create(TEntity obj);
        void Remove(TEntity obj);
        void Remove(int id);
        void Remove(object[] id);
        void RemoveAll(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
    }
}
