using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class OrdersRepository/*<T> : IGenericRepository<T> where T : Order*/
    {
        //private readonly StoreContext context;

        public OrdersRepository()
        {
        }

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await this.context.Set<T>().ToListAsync();
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    return await this.context.Set<T>().FindAsync(id);
        //}

        //public async Task<int> AddAsync(T input)
        //{
        //    await this.context.Set<T>().AddAsync(input);
        //    return await this.context.SaveChangesAsync();
        //}
    }
}
