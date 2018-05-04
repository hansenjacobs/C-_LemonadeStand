using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        static int numberOfDaysToforecastWeather = 7;
        static int minPotentialCustomers = 0;
        static int maxPotentialCustomers = 175;

        List<Weather> forecast;
        Random random;
        List<Recipe> recipes;
        List<Player> players;
        List<Customer> customers;

        public Day(Random random, List<Player> players)
        {
            this.random = random;
            Forecast = new List<Weather>();
            recipes = new List<Recipe>();
            this.players = players;
        }    

        public Day(Random random, List<Player> players, List<Weather> previousforecast)
        {
            this.random = random;
            numberOfDaysToforecastWeather = 7;
            Forecast = new List<Weather>();
            Forecast.AddRange(previousforecast);
            Forecast.RemoveAt(0);
            Updateforecast();
            recipes = new List<Recipe>();
            this.players = players;
        }

        public List<Weather> Forecast
        {
            get { return forecast; }
            set { forecast = value; }
        }

        private int CalculateCustomerCount()
        {
            return random.Next(minPotentialCustomers, maxPotentialCustomers) * (forecast[0].TempratureHigh / Weather.MaxTempratureHigh) / (forecast[0].ConditionIndex + 1);
        }

        private void CreateCustomers()
        {
            int customerCount = CalculateCustomerCount();
            // Create each potential customer
            for(int i = 0; i < customerCount; i++)
            {
                // Create customer, pass in forecast
            }
        }

        private void CreateForecast()
        {
            while (Forecast.Count != numberOfDaysToforecastWeather)
            {
                if (Forecast.Count < numberOfDaysToforecastWeather)
                {
                    Forecast.Add(new Weather(random));
                }
                else
                {
                    Forecast.RemoveAt(Forecast.Count - 1);
                }
            }
        }

        public void SetPlayerRecipes(List<Product> products)
        {
            for (int i = 0; i < players.Count; i++)
            {
                recipes.Add(new Recipe(products));
                recipes[i].SetRecipe(players[i].Name);
            }
        }

        private void Updateforecast()
        {
            for(int i = 0; i < Forecast.Count; i++)
            {
                Forecast[i].AlterForecast();
            }

            CreateForecast();
        }
        

    }
}
