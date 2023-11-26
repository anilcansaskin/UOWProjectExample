using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using UOW.DataAccessLayer.EntityFramework.UnitOfWork.Abstract;

namespace UOW.DataAccessLayer.EntityFramework.UnitOfWork.Concrete
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EfRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }
        public T Add(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }
        public T Update(T entity)
        {
            EntityEntry<T> ent = _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return ent.Entity;
        }
        public bool Delete(T entity)
        {
            if (entity.GetType().GetProperty("IsDelete") != null)
            {
                T _entity = entity;
                _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);
                Update(_entity);
                return true;
            }
            else
            {
                // Önce entity'nin state'ini kontrol etmeliyiz.
                var dbEntityEntry = _dbContext.Entry(entity);
                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
                return true;
            }
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                if (entity.GetType().GetProperty("IsDeleted") != null)
                {
                    T _entity = entity;
                    _entity.GetType().GetProperty("IsDeleted").SetValue(_entity, true);
                    Update(_entity);
                }
                else
                {
                    Delete(entity);
                }
                return true;
            }
            return false;
        }
    }
}
