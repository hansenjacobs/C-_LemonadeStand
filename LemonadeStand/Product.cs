using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Product
    {
        string name;
        double price;
        string unit;

        public Product(string name, double price, string unit)
        {
            this.name = name;
            this.price = price;
            this.unit = unit;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        public string Unit
        {
            get { return unit; }
            private set { unit = value; }
        }
    }
}
