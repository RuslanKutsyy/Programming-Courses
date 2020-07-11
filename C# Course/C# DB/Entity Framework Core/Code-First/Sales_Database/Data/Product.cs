using System.Collections.Generic;

namespace P03_SalesDatabase.Data
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
