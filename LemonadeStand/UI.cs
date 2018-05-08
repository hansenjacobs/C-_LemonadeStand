using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UI
    {
        public static void DisplayFinalScores(List<Player> players, Dictionary<int, double> finalScores)
        {
            int i = 0;
            WriteLine("FINAL RESULTS");
            WriteLine("======================================");
            WriteLine("Player                     Profit/Loss");
            WriteLine("--------------------------------------");
            foreach (KeyValuePair<int, double> score in finalScores)
            {
                i++;
                if(players[score.Key].Name.Length < 15)
                {
                    WriteLine(players[score.Key].Name.PadRight(18) + (score.Value - Player.BeginningBankBalance).ToString("C2").PadLeft(20));
                }
                else
                {
                    WriteLine(players[score.Key].Name.Substring(0, 18) + (score.Value - Player.BeginningBankBalance).ToString("C2").PadLeft(20));
                }
            }
        }
        public static void DisplayForecast(List<Weather> forecast)
        {
            WriteLine($"{forecast.Count} Day Forecast");
            WriteLine("- - - - - - - - - - - - -\n");
            for(int i = 0; i < forecast.Count; i++)
            {
                string dayLabel = i == 0 ? "TODAY: " : $"{i} DAYS OUT: ";
                WriteLine($"{dayLabel} A high of {forecast[i].TempratureHigh}°F and will be {forecast[i].Condition}.");
            }
        }

        public static void DisplayPlayerBankBalance(Player player)
        {
            WriteLine($"{player.Name} your current bank account balance is ${player.BankBalance}\n");
        }

        public static void DisplayPlayerDayResults (Player player, int dayNumber)
        {
            int missedCustomerCount = player.DayDetails[dayNumber].PotentialCustomerCount - player.DayDetails[dayNumber].ActualCustomerCount;
            double totalSales = player.DayDetails[dayNumber].BankAccountEndingBalance - player.DayDetails[dayNumber].BankAccountStartingBalance;
            
            WriteLine($"Day {dayNumber + 1} Results for {player.Name}");
            WriteLine("==============================================");

            WriteLine("CUSTOMERS");
            WriteLine($"Customers Served: {player.DayDetails[dayNumber].ActualCustomerCount}");
            WriteLine($"Customers Missed: {missedCustomerCount:G0}\n");

            WriteLine("CASH FLOW");
            WriteLine($"Beginning Balance: {player.DayDetails[dayNumber].BankAccountStartingBalance:C2}");
            WriteLine($"Total Sales: {totalSales:C2}");
            WriteLine($"Ending Balance: {player.DayDetails[dayNumber].BankAccountEndingBalance:C2}");
            WriteLine($"Running Profit/Loss {player.DayDetails[dayNumber].BankAccountEndingBalance - Player.BeginningBankBalance}");

            if (player.DayDetails[dayNumber].RanOutOfInventory)
            {
                WriteLine("\n**********************************************************************************");
                WriteLine("*Your day ended early as you ran out of needed inventory to serve your customers.*");
                WriteLine("**********************************************************************************");
            }

            WriteLine("");
        }

        public static void DisplayPlayerInventory(Player player)
        {
            WriteLine($"{player.Name}'S INVENTORY");
            WriteLine("\nProduct           Qty");

            foreach(KeyValuePair<string, int> pair in player.Invetory)
            {
                if(pair.Key.Length < 15)
                {
                    WriteLine(pair.Key.PadRight(15) + pair.Value.ToString("G0").PadLeft(6));
                }
                else
                {
                    WriteLine(pair.Key.Substring(0, 15) + pair.Value.ToString("G0").PadLeft(6));
                }
            }
        }

        public static void DisplayStoreProducts(Store store)
        {
            WriteLine("PRODUCT        PRICE");

            for (int i = 0; i < store.Products.Count; i++)
            {
                if(store.Products[i].Name.Length > 15)
                {
                    WriteLine(store.Products[i].Name.Substring(0, 15)+ store.Products[i].Price.ToString("G2") + "/" + store.Products[i].Unit);
                }
                else
                {
                    WriteLine(store.Products[i].Name.PadRight(15) + store.Products[i].Price.ToString("G2") + "/" + store.Products[i].Unit);
                }
            }
            WriteLine("");
        }

        public static string GetInput(string message, string type)
        {
            string input;
            bool isInvalid = true;

            do
            {
                WriteLine(message);

                input = Console.ReadLine().ToLower();
                WriteLine("");

                switch (type)
                {
                    
                    case "integer greater than 0":
                        isInvalid = !IsValidIntGreaterThanZero(input);
                        break;

                    case "integer greater than or equal to 0":
                        isInvalid = !IsValidIntGreaterThanEqualZer0(input);
                        break;

                    case "double (decimal number) greater than 0.00":
                        isInvalid = !IsValidDoubleGreaterThanZero(input);
                        break;

                    case "yes/no":
                        isInvalid = !IsValidYesNo(input);
                        break;

                    case "string":
                    default:
                        isInvalid = !IsValidString(input);
                        break;
                }

                if (isInvalid)
                {
                    WriteLine("\nInvalid input, " + type + " expected.  Please try again.");
                }
            } while (isInvalid);

            return input;
        }

        public static void GoShopping(Player player, Store store)
        {
            string input;
            do
            {
                DisplayPlayerInventory(player);
                DisplayPlayerBankBalance(player);
                WriteLine("");
                DisplayStoreProducts(store);
                input = GetInput("What product would you like to purchase? Enter 'done' if your shopping is complete.", "string").ToLower();
                if (input != "done" && IsInProducts(input, store.Products))
                {
                    ShopProduct(input, store.Products.Where(p => p.Name == input).First(), player);
                }
                else if(input != "done")
                {
                    WriteLine($"{input} is not a valid product.  Please try again.");
                }
            } while (input != "done");

        }

        private static bool IsValidDoubleGreaterThanZero (string str)
        {
            double doubleOut;
            if(double.TryParse(str, out doubleOut))
            {
                if(doubleOut > 0.0)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsValidIntGreaterThanEqualZer0(string str)
        {
            int intOut;
            if (int.TryParse(str, out intOut))
            {
                if (intOut >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValidIntGreaterThanZero(string str)
        {
            int intOut;
            if (int.TryParse(str, out intOut))
            {
                if (intOut > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsInProducts(string input, List<Product> products)
        {
            if(products.Where(p => p.Name == input).FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }

        private static bool IsValidString(string str)
        {
            return true;
        }

        private static bool IsValidYesNo(string str)
        {
            if(str == "yes" || str == "no")
            {
                return true;
            }
            return false;
        }

        public static void SetRecipe(Recipe recipe, string playerName)
        {
            WriteLine($"{playerName}, what will your secret recipe be?");

            foreach(Ingredient ingredient in recipe.Pitcher)
            {
                if(ingredient.Unit == "each")
                {
                    ingredient.Measurement = int.Parse(GetInput($"How many {ingredient.Name}s do you want to use per pitcher?", "integer greater than or equal to 0"));
                }
                else
                {
                    ingredient.Measurement = int.Parse(GetInput($"How many {ingredient.Unit}s of {ingredient.Name} do you want to use per pitcher?", "integer greater than or equal to 0"));
                }
            }

            foreach (Ingredient ingredient in recipe.Cup)
            {
                if (ingredient.Unit == "each" && ingredient.Name != "cup")
                {
                    ingredient.Measurement = int.Parse(GetInput($"How many {ingredient.Name}s do you want to use per cup?", "integer greater than or equal to 0"));
                }
                else if (ingredient.Name != "cup")
                {
                    ingredient.Measurement = int.Parse(GetInput($"How many {ingredient.Unit}s of {ingredient.Name} do you want to use per cup?", "integer greater than or equal to 0"));
                }
            }

            recipe.SellPrice = double.Parse(GetInput("Lastly, what price would you like to charge customers for a cup of your delicious lemonade?", "double (decimal number) greater than 0.00"));
        }

        public static void ShopProduct(string item, Product product, Player player)
        {
            int quanity;
            
            if(product.Unit == "each")
            {
                quanity = int.Parse(GetInput($"How many {product.Name}s would you like?", "integer greater than 0"));
            }
            else
            {
                quanity = int.Parse(GetInput($"How many {product.Unit}s of {product.Name} would you like?", "integer greater than 0"));
            }

            player.AdjustInventory(product.Name, quanity);
            player.ProcessBankTransaction(product.Price * quanity * -1);

        }

        public static void WelcomeMessage(Database databse)
        {
            WriteLine("         LEMONADE STAND GAME");
            WriteLine("=====================================\n");
            WriteLine(databse.GetHighScores());
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
