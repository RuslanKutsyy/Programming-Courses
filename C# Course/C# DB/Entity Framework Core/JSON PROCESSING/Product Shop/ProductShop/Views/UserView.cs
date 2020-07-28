using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Views
{
    public class UserView
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("age")]
        public int? Age { get; set; }
        [JsonProperty("soldProducts")]
        public AllSoldProductsView SoldProducts { get; set; }
    }
}
