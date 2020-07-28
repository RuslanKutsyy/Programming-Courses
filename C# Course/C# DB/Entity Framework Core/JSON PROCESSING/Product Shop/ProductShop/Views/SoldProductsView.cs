using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Views
{
    public class SoldProductView
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("buyerFirstName")]
        public string BuyerFirstName { get; set; }
        [JsonProperty("buyerLastName")]
        public string BuyerLastName { get; set; }
    }
}
