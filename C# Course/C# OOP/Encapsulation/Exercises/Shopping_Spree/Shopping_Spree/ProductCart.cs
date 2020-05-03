using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    class ProductCart : List<Product>
    {
        private List<Product> cart;

        public List<Product> Cart
        {
            get { return this.cart; }
            set { this.cart = value; }
        }

        public ProductCart()
        {
            this.Cart = new List<Product>();
        }

        public void AddToCart(string productsData)
        {
            var prodInfo = productsData.Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int productIndex = 0; productIndex < prodInfo.Length; productIndex++)
            {
                var prod = prodInfo[productIndex].Split('=', StringSplitOptions.RemoveEmptyEntries);

                string productName = prod[0];
                double prodCost = double.Parse(prod[1]);

                this.Cart.Add(new Product(productName, prodCost));
            }
        }
    }
}
