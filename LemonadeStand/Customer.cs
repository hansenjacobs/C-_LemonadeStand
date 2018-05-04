using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        Random random;
        Weather forecast;
        int tasteProfile;
        int worstWeatherConditionsToBuy;

        public Customer(Random random, Weather forecast)
        {
            this.random = random;
            this.forecast = forecast;
            SetTasteProfile();
            SetWorstWeatherToBuy();
        }

        public bool DecidePurchase(Weather weather, Recipe recipe)
        {
            if(weather.ConditionIndex <= worstWeatherConditionsToBuy)
            {
                if(recipe.TasteProfile == Recipe.TasteProfiles[tasteProfile])
                {
                    return true;
                }
            }

            return false;
        }

        private string TasteProfile
        {
            get { return Recipe.TasteProfiles[tasteProfile]; }
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
