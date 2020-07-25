using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Views
{
    public class UsersWithBuyersView
    {
        public UsersWithBuyersView()
        {
            this.soldProducts = new List<SoldProductView>();
        }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<SoldProductView> soldProducts { get; set; }
    }
}
