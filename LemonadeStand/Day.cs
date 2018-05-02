using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        List<Weather> forecast;
        Random random;
        int numberOfDaysToforecastWeather;

        public List<Weather> Forecast
        {
            get { return forecast; }
            set { forecast = value; }
        }

        public Day(Random random)
        {
            this.random = random;
            numberOfDaysToforecastWeather = 7;
            Forecast = new List<Weather>();
        }

        public Day(Random random, List<Weather> previousforecast)
        {
            this.random = random;
            numberOfDaysToforecastWeather = 7;
            Forecast = new List<Weather>();
            Forecast.AddRange(previousforecast);
            Forecast.RemoveAt(0);
            Updateforecast();
        }

        private void Createforecast()
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

        private void Updateforecast()
        {
            for(int i = 0; i < Forecast.Count; i++)
            {
                Forecast[i].AlterForecast();
            }

            Createforecast();
        }
        

    }
}
