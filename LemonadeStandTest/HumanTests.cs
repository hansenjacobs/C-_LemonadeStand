using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace LemonadeStandTest
{
    [TestClass]
    public class HumanTests
    {
        [TestMethod]
        public void AdjustInventory_PositiveQuantity_IncreaseValue()
        {
            // Arrange
            Store store = new Store();
            Human human = new Human(store);
            string item = "lemon";
            int increaseBy = 10;
            int result;

            // Act
            result = human.AdjustInventory(item, increaseBy);

            // Assert
            Assert.AreEqual(result, increaseBy);
        }

        [TestMethod]
        public void AdjustInventory_UnknownItem_InventoryCountIncreaseByOne()
        {
            // Arrange
            Store store = new Store();
            Human human = new Human(store);
            string item = "cocktail umbrellas";
            int increaseBy = 10;
            int originalListCount = human.Invetory.Count;

            // Act
            human.AdjustInventory(item, increaseBy);

            // Assert
            Assert.AreEqual(originalListCount + 1, human.Invetory.Count);
        }

        [TestMethod]
        public void AdjustInventory_UnknownItemPositiveQuanity_ValueSetToIncrease()
        {
            // Arrange
            Store store = new Store();
            Human human = new Human(store);
            string item = "cocktail umbrellas";
            int increaseBy = 10;
            int result;

            // Act
            result = human.AdjustInventory(item, increaseBy);

            // Assert
            Assert.AreEqual(result, increaseBy);
        }

        [TestMethod]
        public void AdjustInventory_UnknownItemNegativeIncrease_ValueSetToZero()
        {
            // Arrange
            Store store = new Store();
            Human human = new Human(store);
            string item = "cocktail umbrellas";
            int increaseBy = -10;
            int result;

            // Act
            result = human.AdjustInventory(item, increaseBy);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void ProcessBankTransaction_MaxDouble_ReturnMaxDoubleMinusOriginalBalance()
        {
            // Arrange
            Store store = new Store();
            Human human = new Human(store);
            double originalBankBalance = human.BankBalance;
            double expectedResult = double.MaxValue - originalBankBalance;
            double result;

            // Act
            result = human.ProcessBankTransaction(double.MaxValue);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void ProcessBankTransaction_MinDouble_ReturnMinDoublePlusOriginalBalance()
        {
            // Arrange
            Store store = new Store();
            Human human = new Human(store);
            double originalBankBalance = human.BankBalance;
            double expectedResult = double.MinValue + originalBankBalance;
            double result;

            // Act
            result = human.ProcessBankTransaction(double.MinValue);

            // Assert

        }

        [TestMethod]
        public void ProcessBankTransaction_NegativeNumber_DecreaseBankBalance()
        {
            // Arrange
            Store store = new Store();
            Human human = new Human(store);
            double originalBankBalance = human.BankBalance;
            double transactionAmount = -10.50;

            // Act
            human.ProcessBankTransaction(transactionAmount);

            // Assert
            Assert.AreEqual(originalBankBalance + transactionAmount, human.BankBalance);
        }
        [TestMethod]
        public void ProcessBankTransaction_NegativeNumber_ReturnNewBankBalance()
        {
            // Arrange
            Store store = new Store();
            Human human = new Human(store);
            double originalBankBalance = human.BankBalance;
            double transactionAmount = -10.50;
            double result;

            // Act
            result = human.ProcessBankTransaction(transactionAmount);

            // Assert
            Assert.IsTrue(result == human.BankBalance);
        }

        [TestMethod]
        public void ProcessBankTransaction_PositiveNumber_IncreaseBankBalance()
        {
            // Arrange
            Store store = new Store();
            Human human = new Human(store);
            double originalBankBalance = human.BankBalance;
            double transactionAmount = 10.50;

            // Act
            human.ProcessBankTransaction(transactionAmount);

            // Assert
            Assert.AreEqual(originalBankBalance + transactionAmount, human.BankBalance);
        }

        [TestMethod]
        public void ProcessBankTransaction_PositiveNumber_ReturnNewBankBalance()
        {
            // Arrange
            Store store = new Store();
            Human human = new Human(store);
            double originalBankBalance = human.BankBalance;
            double transactionAmount = 10.50;
            double result;

            // Act
            result = human.ProcessBankTransaction(transactionAmount);

            // Assert
            Assert.AreEqual(result, human.BankBalance);
        }
    }
}
