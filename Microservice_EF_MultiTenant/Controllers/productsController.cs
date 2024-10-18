using Microservice_EF_MultiTenant.Services;
using Microservice_EF_MultiTenant.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice_EF_MultiTenant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly IProductService _productService;

        public productsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _productService.GetAllProducts();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Post(CreateProductRequest request) 
        {
            var result = _productService.CreateProduct(request);
            return Ok(result);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id) 
        { 
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }
    }
}
