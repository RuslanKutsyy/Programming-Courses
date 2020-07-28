using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Views
{
    public class AllSoldProductsView
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("products")]
        public ICollection<ProductView> Products { get; set; }
    }
}
