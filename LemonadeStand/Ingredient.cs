using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Ingredient
    {
        string name;
        string unit;
        int measurement;

        public Ingredient(string name, string unit)
        {
            this.name = name;
            this.unit = unit;
            measurement = 0;
        }

        public int Measurement
        {
            get { return measurement; }
            set { measurement = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string Unit
        {
            get { return unit; }
            private set { unit = value; }
        }
    }
}
