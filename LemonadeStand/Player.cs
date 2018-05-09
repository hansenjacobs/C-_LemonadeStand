using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract public class Player
    {
        static double beginningBankBalance = 50;

        double bankBalance;
        string name;
        Dictionary<string, int> inventory;
        List<DayDetails> dayDetails;
        

        public double BankBalance
        {
            get { return bankBalance; }
            set { bankBalance = value; }
        }

        public static double BeginningBankBalance
        {
            get { return beginningBankBalance; }
            private set { beginningBankBalance = value; }
        }

        public List<DayDetails> DayDetails
        {
            get { return dayDetails; }
            set { dayDetails = value; }
        }

        public Dictionary<string, int> Invetory
        {
            get { return inventory; }
            private set { inventory = value; }
        }

        public string Name
        {
            get { return name.ToUpper(); }

            set { name = value.ToUpper(); }
        }

        public Player(Store store)
        {
            bankBalance = beginningBankBalance;
            name = "";
            inventory = new Dictionary<string, int>();
            dayDetails = new List<DayDetails>();
            for(int i = 0; i < store.Products.Count; i++)
            {
                inventory.Add(store.Products[i].Name, 0);
            }
            dayDetails = new List<DayDetails>();
        }

        public int AdjustInventory(string item, int quanityIncrementer)
        {
            int currentQuanity;

            if(inventory.TryGetValue(item, out currentQuanity))
            {
                if(int.MaxValue - currentQuanity >= quanityIncrementer)
                {
                    inventory[item] = currentQuanity + quanityIncrementer;
                }
                else
                {
                    throw new OverflowException();
                }
            }
            else
            {
                inventory[item] = quanityIncrementer > 0 ? quanityIncrementer : 0;
            }

            return inventory[item];
        }

        public void DisplayBankBalance()
        {
            UI.DisplayPlayerBankBalance(this);
        }

        public void GoShopping(Store store)
        {
            if (UI.GetInput($"{name} would you like to visit the store for supplies? <yes/no>", "yes/no") == "yes")
            {
                UI.GoShopping(this, store);
            }
        }

        private bool IsSufficentInventoryPitcher(Recipe recipe)
        {
            for(int i = 0; i < recipe.Pitcher.Count; i++)
            {
                if(recipe.Pitcher[i].Measurement > inventory[recipe.Pitcher[i].Name])
                {
                    return false;
                }
            }
            return true;
        }

        public bool MakePitcher(Recipe recipe)
        {
            if (IsSufficentInventoryPitcher(recipe))
            {
                for (int i = 0; i < recipe.Pitcher.Count; i++)
                {
                    UseInventory(recipe.Pitcher[i].Name, recipe.Pitcher[i].Measurement);
                }

                return true;
            }
            
            return false;
        }

        public double ProcessBankTransaction(double increaseBalanceBy)
        {
            if(double.MaxValue - bankBalance <= increaseBalanceBy) { throw new OverflowException(); }
            if(double.MinValue + bankBalance >= increaseBalanceBy) { throw new OverflowException(); }
            return BankBalance += increaseBalanceBy;
        }

        public void SetPlayerName(string playerLabel)
        {
            Name = UI.GetInput($"Enter {playerLabel}'s name:", "string");
        }

        private void UseInventory(string item, int quanity)
        {
            inventory[item] -= quanity;
        }

    }
}
