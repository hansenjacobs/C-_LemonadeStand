using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UI
    {
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

        public static void DisplayStoreProducts(Store store)
        {
            WriteLine("PRODUCT        PRICE");

            for (int i = 0; i < store.Products.Count; i++)
            {
                WriteLine(store.Products[i].Name.Substring(0, 15).PadRight(15) + store.Products[i].Price + "/" + store.Products[i].Unit);
            }
            WriteLine("");
        }

        public static string GetInput(string message, string type)
        {
            string input;
            bool isInvalid = true;

            WriteLine(message);
            do
            {
                input = Console.ReadLine().ToLower();

                switch (type)
                {
                    
                    case "integer greater than 0":
                        isInvalid = !IsValidIntGreaterThanZero(input);
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
                    WriteLine("Invalid input, " + type + " expected.  Please try again.");
                }
            } while (isInvalid);

            return input;
        }

        public static void GoShopping(Player player, Store store)
        {
            string input;
            do
            {
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
                    ingredient.Measurement = int.Parse(GetInput($"How many {ingredient.Name}s do you want to use per pitcher?", "integer greater than 0"));
                }
                else
                {
                    ingredient.Measurement = int.Parse(GetInput($"How many {ingredient.Unit}s of {ingredient.Name} do you want to use per pitcher?", "integer greater than 0"));
                }
            }

            foreach (Ingredient ingredient in recipe.Cup)
            {
                if (ingredient.Unit == "each" && ingredient.Name != "cup")
                {
                    ingredient.Measurement = int.Parse(GetInput($"How many {ingredient.Name}s do you want to use per cup?", "integer greater than 0"));
                }
                else if (ingredient.Name != "cup")
                {
                    ingredient.Measurement = int.Parse(GetInput($"How many {ingredient.Unit}s of {ingredient.Name} do you want to use per cup?", "integer greater than 0"));
                }
            }
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

        public static void WelcomeMessage()
        {
            WriteLine("LEMONADE STAND");
            WriteLine("===============\n");
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
