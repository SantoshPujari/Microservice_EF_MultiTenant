using Microservice_EF_MultiTenant.Models;
using Microservice_EF_MultiTenant.Services.DTOs;

namespace Microservice_EF_MultiTenant.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product CreateProduct(CreateProductRequest request);
        bool DeleteProduct(int Id);
    }
}
