using System.Linq.Expressions;

namespace UOW.DataAccessLayer.EntityFramework.UnitOfWork.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        bool Delete(T entity);
        bool Delete(int id);
    }
}
