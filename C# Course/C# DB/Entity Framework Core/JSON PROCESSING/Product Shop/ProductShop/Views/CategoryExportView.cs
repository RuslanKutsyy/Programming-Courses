using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Views
{
    public class CategoryExportView
    {
        public string category { get; set; }
        public int productsCount { get; set; }
        public string averagePrice { get; set; }
        public string totalRevenue { get; set; }
    }
}
