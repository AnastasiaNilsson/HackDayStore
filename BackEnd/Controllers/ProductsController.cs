using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;


namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts(string? searchTerm, string? category)
        {
            var products = _context.Products.ToList();

            if (category == "All" || !string.IsNullOrEmpty(category))
            {
                products = products.Where(product => product.Category == category).ToList();
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(product => product.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(product => product.Id == id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> SeedDatabase(int numberOfProducts)
        {
            var products = Enumerable.Range(1, numberOfProducts).Select(number => Product.Randomize()).ToList();
            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> PurgeDatabase()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Products");
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
