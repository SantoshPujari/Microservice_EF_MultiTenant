namespace Microservice_EF_MultiTenant.Models
{
    public interface IMustHaveTenant
    {
        public string TenantId { get; set; }
    }
}
