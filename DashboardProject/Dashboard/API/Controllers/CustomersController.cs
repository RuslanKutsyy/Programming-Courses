using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IGenericRepository<Customer> repository;

        public CustomersController(IGenericRepository<Customer> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var customer = await this.repository.GetAllAsync();

            return Ok(customer.ToList());
        }

        [HttpGet("{id}", Name = "GetCustomerAsync")]
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
        public async Task<IActionResult> AddNewCustomerAsync([FromBody] Customer customer)
        {
            try
            {
                await this.repository.AddAsync(customer);
                return CreatedAtRoute("GetCustomerAsync", new { id = customer.Id }, customer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
