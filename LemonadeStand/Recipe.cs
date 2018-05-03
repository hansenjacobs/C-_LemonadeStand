using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {

        List<Ingredient> cup;
        List<Ingredient> pitcher;

        public Recipe(List<Product> products)
        {
            cup = new List<Ingredient>();
            pitcher = new List<Ingredient>();
            foreach (Product product in products)
            {
                switch (product.RecipePart)
                {
                    case "pitcher":
                        pitcher.Add(new Ingredient(product.Name, product.Unit));
                        break;

                    case "cup":
                    default:
                        cup.Add(new Ingredient(product.Name, product.Unit));
                        break;
                }
            }
        }

        public List<Ingredient> Cup
        {
            get { return cup; }
            private set { cup = value; }
        }

        public List<Ingredient> Pitcher
        {
            get { return pitcher; }
            private set { pitcher = value; }
        }

        public void SetRecipe(string playerName)
        {
            UI.SetRecipe(this, playerName);
        }
    }
}
