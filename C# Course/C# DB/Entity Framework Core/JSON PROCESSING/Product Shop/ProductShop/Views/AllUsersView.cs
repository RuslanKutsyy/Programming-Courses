using Newtonsoft.Json;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Views
{
    public class AllUsersView
    {
        [JsonProperty("usersCount")]
        public int UsersCount { get; set; }
        [JsonProperty("users")]
        public ICollection<UserView> Users { get; set; }
    }
}
