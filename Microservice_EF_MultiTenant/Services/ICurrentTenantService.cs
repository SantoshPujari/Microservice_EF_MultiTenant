namespace Microservice_EF_MultiTenant.Services
{
    public interface ICurrentTenantService
    {
        public string? TenantId { get; set; }
        public Task<bool> SetTenant(string tenant);
    }
}
