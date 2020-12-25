using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly StoreContext context;

        public ServersController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetServersAsync()
        {
            var servers = await this.context.Servers.ToListAsync();

            return Ok(servers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServerByIdAsync(int id)
        {
            var server = await this.context.Servers.FindAsync(id);
            return Ok(server);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServer(int id, [FromBody] ServerMessage message)
        {
            var server = await this.context.Servers.FindAsync(id);

            if (server == null)
            {
                return NotFound();
            }


            // can be moved to a dedicated service
            if (message.Payload == "activate")
            {
                server.IsOnline = true;
            }

            if (message.Payload == "deactivate")
            {
                server.IsOnline = false;
                server.LastDownDate = DateTime.Now;
            }

            await this.context.SaveChangesAsync();

            return NoContent();
        }
    }
}