using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IGenericRepository<Order> repository;

        public OrdersController(IGenericRepository<Order> repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> GetCustomersAsync()
        {
            var orders = await this.repository.GetAllAsync();

            return Ok(orders.ToList());
        }

        [HttpGet("{id}", Name = "GetOrderAsync")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            var customer = await this.repository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomerAsync([FromBody] Order order)
        {
            try
            {
                await this.repository.AddAsync(order);
                return CreatedAtRoute("GetOrderAsync", new { id = order.Id }, order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
