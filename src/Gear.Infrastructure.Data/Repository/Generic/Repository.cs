using Microsoft.EntityFrameworkCore;
using Gear.Domain.Interfaces.Generic;
using Gear.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gear.Infrastructure.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly GearContext _context;
        private readonly DbSet<TEntity> _db;

        public Repository(GearContext context)
        {
            _context = context;
            _db = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll(bool readOnly = false)
        {
            if (readOnly) return _db.AsNoTracking().AsQueryable();
            return _db.AsQueryable();
        }

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool readOnly = false)
        {
            if (readOnly) return _db.Where(predicate).AsNoTracking().AsQueryable();
            return _db.Where(predicate).AsQueryable();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool readOnly = false)
        {
            if (readOnly) return await _db.AsNoTracking().ToListAsync();
            return await _db.ToListAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool readOnly = false)
        {
            if (readOnly) return await _db.Where(predicate).AsNoTracking().ToListAsync();
            return await _db.Where(predicate).ToListAsync();
        }

        public virtual TEntity GetById(int id) => _db.Find(id);
        public virtual TEntity GetById(object[] id)  => _db.Find(id);
        public virtual async Task<TEntity> GetByIdAsync(int id) => await _db.FindAsync(id);
        public virtual async Task<TEntity> GetByIdAsync(object[] id) => await _db.FindAsync(id);
        public virtual void Create(TEntity obj) => _db.Add(obj);
        public virtual void Remove(TEntity obj) => _db.Remove(obj);
        public virtual void Remove(int id) => _db.Remove(GetById(id));
        public virtual void Remove(object[] id) => _db.Remove(GetById(id));
        public virtual void RemoveAll(Expression<Func<TEntity, bool>> predicate)
        {
            _db.RemoveRange(GetAll(predicate).ToList());
        }

        public virtual void Update(TEntity obj) =>  _db.Update(obj);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
