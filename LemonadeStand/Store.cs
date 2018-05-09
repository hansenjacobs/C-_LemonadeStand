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
        static double lemonPrice = 0.10;
        static double sugarPrice = 0.10;
        static double iceCubePrice = 0.01;
        static double cupPrice = 0.04;

        public Store()
        {
            products = new List<Product>();
            products.Add(new Product("lemon", lemonPrice, "each", "pitcher"));
            products.Add(new Product("sugar", sugarPrice, "cup", "pitcher"));
            products.Add(new Product("ice cube", iceCubePrice, "each", "cup"));
            products.Add(new Product("cup", cupPrice, "each", "cup"));
        }

        public List<Product> Products
        {
            get { return products; }
            private set { products = value; }
        }

        public static double BaseCupCost
        {
            get { return lemonPrice * 2 + sugarPrice + iceCubePrice * 5 + cupPrice; }
        }

        public void DisplayProducts()
        {
            UI.DisplayStoreProducts(this);
        }
    }
}
