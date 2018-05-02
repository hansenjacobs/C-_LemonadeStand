using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class Player
    {
        private double _bankBalance;
        private string _name;

        public double BankBalance
        {
            get { return _bankBalance; }
        }

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public Player()
        {
            _bankBalance = 50;
        }

        

    }
}
