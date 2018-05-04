using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class DayDetails
    {
        int actualCustomerCount;
        double bankAccountEndingBalance;
        double bankAccountStartingBalance;
        int potentialCustomerCount;
        bool ranOutOfInventory = false;

        public int ActualCustomerCount
        {
            get { return actualCustomerCount; }
            set { actualCustomerCount = value; }
        }

        public double BankAccountEndingBalance
        {
            get { return bankAccountEndingBalance; }
            set { bankAccountEndingBalance = value; }
        }

        public double BankAccountStartingBalance
        {
            get { return bankAccountStartingBalance; }
            set
            { bankAccountStartingBalance = value; }
        }

        public int PotentialCustomerCount
        {
            get { return potentialCustomerCount; }
            set { potentialCustomerCount = value; }
        }

        public bool RanOutOfInventory
        {
            get { return ranOutOfInventory; }
            set { ranOutOfInventory = value; }
        }

        public void RecordPurchase(double price)
        {
            actualCustomerCount++;
            bankAccountEndingBalance += price;
        }

    }
}
