using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CustomersRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext context;

        public CustomersRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task<int> AddAsync(T input)
        {
            await this.context.Set<T>().AddAsync(input);
            return await this.context.SaveChangesAsync();
        }
    }
}
