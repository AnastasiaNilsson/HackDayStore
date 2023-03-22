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
    public class OrdersController : ControllerBase
    {
        private readonly StoreContext _context;
        public OrdersController(StoreContext context) => _context = context;

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string orderNumber)
        {
            var order = _context.Orders.FirstOrDefault(order => order.OrderNumber == orderNumber);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateOrder(OrderRequest request)
        {
            var order = new Order(request);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return Ok(order.OrderNumber);
        }

        [HttpDelete]
        public async Task<IActionResult> PurgeDatabase()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Orders");
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
