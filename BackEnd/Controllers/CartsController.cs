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
    public class CartsController : ControllerBase
    {
        private readonly StoreContext _context;
        public CartsController(StoreContext context) => _context = context;

        [HttpGet("{id}")]
        public ActionResult<Cart> GetCart(string cartNumber)
        {
            var cart = _context.Carts.FirstOrDefault(cart => cart.CartNumber == cartNumber);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateCart(CartItem[] cartItems)
        {
            var cart = new Cart(cartItems);
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return Ok(cart.CartNumber);
        }

        [HttpDelete]
        public async Task<IActionResult> PurgeDatabase()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Carts");
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
