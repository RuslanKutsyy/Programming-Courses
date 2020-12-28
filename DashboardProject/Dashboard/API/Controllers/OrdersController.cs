using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Helpers;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly StoreContext context;

        public OrdersController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllOrders()
        {
            var orders = await this.context.Orders.Include(o => o.Customer).ToListAsync();

            return Ok(orders.ToList());
        }

        [HttpGet("{id}", Name = "GetOrderAsync")]
        public async Task<IActionResult> GetOrdersByIdAsync(int id)
        {
            var customer = await this.context.Orders.Include(o => o.Customer)
                .Select(x => new
                {
                    id = x.Id,
                    totalPrice = x.TotalPrice,
                    placed = x.Placed,
                    completed = x.Completed,
                    customer = new
                    {
                        id = x.Customer.Id,
                        firstname = x.Customer.FirstName,
                        lastname = x.Customer.LastName
                    }
                }).FirstAsync(o => o.id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrderAsync([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            await this.context.AddAsync(order);
            await this.context.SaveChangesAsync();
            return CreatedAtRoute("GetOrderAsync", new { id = order.Id }, order);
        }
        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public async Task<IActionResult> GetOrdersByPage(int pageIndex, int pageSize)
        {
            var data = await this.context.Orders.Include(o => o.Customer).OrderByDescending(c => c.Placed).ToListAsync();

            var page = new PaginatedResponse<Order>(data, pageIndex, pageSize);

            var totalCount = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount /pageSize);

            var response = new
            {
                Page = page,
                TotalPages = totalPages
            };

            return Ok(response);
        }

        [HttpGet("ByCity")]
        public async Task<IActionResult> GetOrdersByCity()
        {
            var orders = await this.context.Orders.Include(o => o.Customer).ToListAsync();

            var groupedData = orders.GroupBy(o => o.Customer.City).Select(grp => new
            {
                City = grp.Key,
                Total = Math.Round(grp.Sum(x => x.TotalPrice), 2, MidpointRounding.AwayFromZero)
            }).ToList();

            return Ok(groupedData);
        }

        [HttpGet("ByCustomer/{n}")]
        public async Task<IActionResult> GetOrdersByCustomer(int n)
        {
            var orders = await this.context.Orders.Include(o => o.Customer).ToListAsync();

            var groupedData = orders.GroupBy(o => o.Customer.Id).Select(grp => new
            {
                Name = $"{context.Customers.Find(grp.Key).FirstName} {context.Customers.Find(grp.Key).LastName}",
                Total = Math.Round(grp.Sum(x => x.TotalPrice), 2, MidpointRounding.AwayFromZero)
            }).Take(n).ToList();

            return Ok(groupedData);
        }
    }
}
