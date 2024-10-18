using Microservice_EF_MultiTenant.Models;
using Microservice_EF_MultiTenant.Services.ProductService.DTOs;

namespace Microservice_EF_MultiTenant.Services.ProductService
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product CreateProduct(CreateProductRequest request);
        bool DeleteProduct(int Id);
    }
}
