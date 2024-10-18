using Microsoft.EntityFrameworkCore;

namespace Microservice_EF_MultiTenant.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
