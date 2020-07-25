using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Views
{
    public class FilteredProductView
    {
        //public FilteredProductView(string name, double price, string seller)
        //{
        //    this.name = name;
        //    this.price = price;
        //    this.seller = seller;
        //}
        public string name { get; set; }
        public double price { get; set; }
        public string seller { get; set; }
    }
}
