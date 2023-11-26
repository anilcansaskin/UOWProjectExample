using UOW.DataAccessLayer.EntityFramework.UnitOfWork.Abstract;

namespace UOW.DataAccessLayer.EntityFramework.UnitOfWork.Concrete
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;
        private bool disposed;
        public EFUnitOfWork(ApplicationContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("dbContext can not be null.");
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EfRepository<T>(_dbContext);
        }
        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _dbContext.Dispose();
            }
            disposed = true;
        }
    }
}
