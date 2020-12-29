using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly StoreContext context;

        public CustomersController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllCustomers()
        {
            var customer = await this.context.Customers.ToListAsync();

            return Ok(customer);
        }

        [HttpGet("{id}", Name = "GetCustomerAsync")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            var customer = await this.context.Customers
                .Include(c => c.Orders).FirstAsync(c => c.Id == id);
                
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet("GetTopCustomersAndOrders/{top}")]
        public async Task<IActionResult> GetOrdersByTopCustomers(int top)
        {
            var data = await this.context.Customers.Include(x => x.Orders).OrderByDescending(cust => cust.Orders.Sum(x => x.TotalPrice)).Take(top).ToListAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomerAsync([FromBody] Customer customer)
        {
            await this.context.Customers.AddAsync(customer);
            await this.context.SaveChangesAsync();
            return CreatedAtRoute("GetCustomerAsync", new { id = customer.Id }, customer);
        }
    }
}
