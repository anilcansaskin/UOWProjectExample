using Microsoft.EntityFrameworkCore;

namespace UOW.DataAccessLayer.EntityFramework
{
    public class ApplicationContext : BaseContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
