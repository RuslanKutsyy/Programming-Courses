using P03_SalesDatabase.Data;
using System.Collections.Generic;

namespace Sales_Database.Data
{
    public class Store
    {
        public Store()
        {
            Sales = new HashSet<Sale>();
        }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
