using Microsoft.EntityFrameworkCore;

namespace Microservice_EF_MultiTenant.Models
{
    public class TenantDbContext: DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options): base(options)
        {
            
        }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
