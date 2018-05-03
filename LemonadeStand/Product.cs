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
        string recipePart;

        public Product(string name, double price, string unit, string recipePart)
        {
            this.name = name;
            this.price = price;
            this.unit = unit;
            this.recipePart = recipePart;
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

        public string RecipePart
        {
            get { return recipePart; }
            private set { recipePart = value; }
        }

        public string Unit
        {
            get { return unit; }
            private set { unit = value; }
        }

    }
}
