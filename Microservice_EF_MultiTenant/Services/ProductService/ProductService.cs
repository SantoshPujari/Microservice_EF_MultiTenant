using Microservice_EF_MultiTenant.Models;
using Microservice_EF_MultiTenant.Services.ProductService.DTOs;

namespace Microservice_EF_MultiTenant.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Product CreateProduct(CreateProductRequest request)
        {
            var product = new Product();
            product.Name = request.Name;
            product.Description = request.Description;

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public bool DeleteProduct(int Id)
        {
            var product = _context.Products.Where(x => x.Id == Id).FirstOrDefault();

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }
    }
}
