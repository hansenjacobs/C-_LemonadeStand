using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {
        List<Product> products;

        public Store()
        {
            products = new List<Product>();
            products.Add(new Product("lemon", 0.10, "each"));
            products.Add(new Product("sugar", 0.10, "cup"));
            products.Add(new Product("ice cube", 0.01, "each"));
            products.Add(new Product("cup", 0.04, "each"));
        }

        public List<Product> Products
        {
            get { return products; }
            private set { products = value; }
        }

        public void DisplayProducts()
        {
            UI.DisplayStoreProducts(this);
        }
    }
}
