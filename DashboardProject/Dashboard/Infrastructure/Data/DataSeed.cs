using Core.DTO;
using Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataSeed
    {
        private readonly StoreContext context;
        public DataSeed(StoreContext context)
        {
            this.context = context;
        }

        public void Seed(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Customers.Any())
                {
                    var customersData = File.ReadAllText("../Infrastructure/Data/SeedData/customers.json");
                    var customers = JsonSerializer.Deserialize<List<Customer>>(customersData);

                    foreach (var cust in customers)
                    {
                        context.Customers.Add(cust);
                    }
                }

                if (!context.Orders.Any())
                {
                    var ordersData = File.ReadAllText("../Infrastructure/Data/SeedData/orders.json");
                    var orders = JsonSerializer.Deserialize<List<OrderImportDto>>(ordersData);

                    foreach (var order in orders)
                    {
                        var orderToImport = new Order
                        {
                            TotalPrice = order.TotalPrice,
                            Placed = DateTime.ParseExact(order.Placed, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                            CustomerId = order.CustomerId
                        };

                        orderToImport.Completed = string.IsNullOrWhiteSpace(order.Completed) ? (DateTime?)null : DateTime.ParseExact(order.Completed, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        context.Orders.Add(orderToImport);
                    }
                }

                if (!context.Servers.Any())
                {
                    var serversData = File.ReadAllText("../Infrastructure/Data/SeedData/servers.json");
                    var servers = JsonSerializer.Deserialize<List<ServerImportDto>>(serversData);

                    foreach (var serverToImport in servers)
                    {
                        var server = new Server
                        {
                            Name = serverToImport.Name,
                            IsOnline = serverToImport.IsOnline
                        };

                        server.LastDownDate = string.IsNullOrWhiteSpace(serverToImport.LastDownDate) ?
                            (DateTime?)null : DateTime.ParseExact(serverToImport.LastDownDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                        context.Servers.Add(server);
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContext>();
                logger.LogError(e.StackTrace);
            }
        }
    }
}
