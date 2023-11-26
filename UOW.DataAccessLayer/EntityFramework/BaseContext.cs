using Microsoft.EntityFrameworkCore;
using UOW.EntityLayer.Entities;

namespace UOW.DataAccessLayer.EntityFramework
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion
    }
}
