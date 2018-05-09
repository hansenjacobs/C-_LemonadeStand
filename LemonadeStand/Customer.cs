using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        int maxIceCubeCount = 8;
        int minIceCubeCount = 0;

        Random random;
        Weather forecast;
        int tasteProfile;
        int preferedIceCubeCount;
        int worstWeatherConditionsToBuy;
        double highestPriceToPay;

        public Customer(Random random, Weather forecast)
        {
            this.random = random;
            this.forecast = forecast;
            SetTasteProfile();
            SetWorstWeatherToBuy();
            preferedIceCubeCount = random.Next(minIceCubeCount, maxIceCubeCount);
        }

        public bool DoesPurchase(Weather weather, Recipe recipe)
        {
            if(weather.ConditionIndex <= worstWeatherConditionsToBuy)
            {
                if(recipe.TasteProfile == Recipe.TasteProfiles[tasteProfile])
                {
                    if(recipe.IceCubeCount >= preferedIceCubeCount - 1 && recipe.IceCubeCount <= preferedIceCubeCount + 1 && recipe.SellPrice <= highestPriceToPay)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private string TasteProfile
        {
            get { return Recipe.TasteProfiles[tasteProfile]; }
        }

        private void SetHighestPriceToPay()
        {
            bool increaseHighestPriceToPay;

            increaseHighestPriceToPay = random.Next(-1, 3) < 0 ? false : true;

            if (increaseHighestPriceToPay)
            {
                int increase = random.Next(10, 25) / 10;
                highestPriceToPay = Store.BaseCupCost * increase;
            }
            else
            {
                highestPriceToPay = Store.BaseCupCost;
            }
        }

        private void SetTasteProfile()
        {
            tasteProfile = random.Next(Recipe.TasteProfiles.Length);
        }

        private void SetWorstWeatherToBuy()
        {
            worstWeatherConditionsToBuy = random.Next(Weather.Conditions.Count);
        }
    }
}
