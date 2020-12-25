using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Helpers
{
    public class PaginatedResponse<T> where T : BaseEntity
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
        public PaginatedResponse(IEnumerable<T> data, int pageIndex, int pageSize)
        {
            this.Data = data.Skip((pageSize - 1) * pageIndex).Take(pageSize).ToList();
            this.Total = data.Count();
        }
    }
}
