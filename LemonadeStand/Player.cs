using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class Player
    {
        private double bankBalance;
        private string name;

        public double BankBalance
        {
            get { return bankBalance; }
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public Player()
        {
            bankBalance = 50;
            name = "";
        }

        public void SetPlayerName(string playerLabel)
        {
            Name = UI.GetInput($"Enter {playerLabel}'s name:", "string");
        }

    }
}
