using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Computer : Player
    {
        Random random;

        public Computer(Random random, Store store) : base(store)
        {
            this.random = random;
        }
    }
}
