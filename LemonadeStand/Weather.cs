using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        Random random;
        int tempratureHigh;
        int condition;
        List<string> conditions;
        int snowTemprature;
        int percentageDivisor;
        int maxTempratureAlerterationPercent; // Int will be devided to calculate percentage.

        public Weather(Random random)
        {
            snowTemprature = 40;
            percentageDivisor = 100;
            maxTempratureAlerterationPercent = 5;

            this.random = random;
            conditions = new List<string>();
            TempratureHigh = random.Next(35, 120);
            CreateConditionsList();

        }

        public string Condition
        {
            get { return conditions[condition]; }
            private set
            {
                if (conditions.IndexOf(value) >= 0)
                {
                    condition = conditions.IndexOf(value);
                }
                else
                {
                    condition = 0;
                }
            }
        }

        public int TempratureHigh
        {
            get { return tempratureHigh; }
            private set { tempratureHigh = value; }
        }

        private void CreateConditionsList()
        {
            conditions.Clear();

            if (TempratureHigh > snowTemprature)
            {
                conditions.Add("mostly sunny");
                conditions.Add("partly sunny");
                conditions.Add("partly cloudy");
                conditions.Add("mostly cloudy");
                conditions.Add("partly cloudy with scattered rain showers");
                conditions.Add("mostly cloudy with scattered rain showers");
                conditions.Add("thunder storms");
            }
            else
            {
                conditions.Add("mostly sunny");
                conditions.Add("partly sunny");
                conditions.Add("partly cloudy");
                conditions.Add("mostly cloudy");
                conditions.Add("partly cloudy with snow flurries");
                conditions.Add("mostly cloudy with light snow");
                conditions.Add("blizzard");
            }
        }

        private void DetermineCondition()
        {
            SetCondition(random.Next(conditions.Count));
        }

        private void SetCondition(int indexCondition)
        {
            Condition = conditions[indexCondition];
        }

        public void AlterForecast()
        {
            int conditionChange;

            TempratureHigh = TempratureHigh + (TempratureHigh * (random.Next(maxTempratureAlerterationPercent) / percentageDivisor));
            CreateConditionsList();
            
            conditionChange = random.Next(-1, 1);
            if(condition + conditionChange >= 0 && condition + conditionChange < conditions.Count)
            {
                condition += conditionChange;
            }
        }
    }
}
