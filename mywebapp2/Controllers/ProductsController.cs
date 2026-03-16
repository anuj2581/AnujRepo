using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mywebapp2.Model;

namespace mywebapp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("getproducts")]
        public IActionResult getproduct()
        {
            var products = getdummyproduct();
           return Ok(products);
        }

        private List<Product> getdummyproduct()
        {
            var products = new List<Product>
                {
                    new Product { Id = 1, Name = "Laptop", Price = 75000, Category = "Electronics" },
                    new Product { Id = 2, Name = "Smartphone", Price = 30000, Category = "Electronics" },
                    new Product { Id = 3, Name = "Headphones", Price = 2500, Category = "Accessories" },
                    new Product { Id = 4, Name = "Keyboard", Price = 1200, Category = "Accessories" },
                    new Product { Id = 5, Name = "Mouse", Price = 800, Category = "Accessories" }
                };

            return products;
        }
    }
}
