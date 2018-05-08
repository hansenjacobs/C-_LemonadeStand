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
        static List<string> conditions;
        static int percentageDivisor = 100;
        static int maxTempratureAlerterationPercent = 5; // Int will be devided to calculate percentage.
        static int minTempratureHigh = 55;
        static int maxTempratureHigh = 98;

        public Weather(Random random)
        {
            this.random = random;
            conditions = new List<string>();
            TempratureHigh = random.Next(minTempratureHigh, maxTempratureHigh);
            if(conditions.Count == 0)
            {
                CreateConditionsList();
            }
            DetermineCondition();
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

        public static List<string> Conditions
        {
            get { return conditions; }
            private set { conditions = value; }
        }

        public int ConditionIndex
        {
            get { return condition; }
            private set { condition = value; }
        }

        public static int MaxTempratureHigh
        {
            get { return maxTempratureHigh; }
            private set { maxTempratureHigh = value; }
        }

        public static int MinTempratureHigh
        {
            get { return minTempratureHigh; }
            private set { minTempratureHigh = value; }
        }

        public int TempratureHigh
        {
            get { return tempratureHigh; }
            private set { tempratureHigh = value; }
        }

        private void CreateConditionsList()
        {
            conditions.Add("mostly sunny");
            conditions.Add("partly sunny");
            conditions.Add("partly cloudy");
            conditions.Add("mostly cloudy");
            conditions.Add("partly cloudy with scattered rain showers");
            conditions.Add("mostly cloudy with scattered rain showers");
            conditions.Add("thunder storms");
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
            
            conditionChange = random.Next(-1, 1);
            if(condition + conditionChange >= 0 && condition + conditionChange < conditions.Count)
            {
                condition += conditionChange;
            }
        }
    }
}
