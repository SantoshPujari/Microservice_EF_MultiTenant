using Microservice_EF_MultiTenant.Services;
using Microsoft.EntityFrameworkCore;

namespace Microservice_EF_MultiTenant.Models
{
    public class ApplicationDbContext:DbContext
    {
        private readonly ICurrentTenantService _currentTenantService;

        public string? CurrentTenantID { get; private set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentTenantService currentTenantService):base(options)
        {
            _currentTenantService = currentTenantService;
            CurrentTenantID = _currentTenantService.TenantId;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(a => a.TenantId == CurrentTenantID);
            //base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList()) 
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.TenantId = CurrentTenantID;
                        break;                    
                    default:
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
