using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UI
    {
        public static void Displayforecast(List<Weather> forecast)
        {
            WriteLine($"{forecast.Count} Day Forecast");
            WriteLine("- - - - - - - - - - - - -\n");
            for(int i = 0; i < forecast.Count; i++)
            {
                string dayLabel = i = 0 ? "TODAY: " : $"{i} DAYS OUT: ";
                WriteLine($"{dayLabel} A high of {forecast[i].TempratureHigh}°F and will be {forecast[i].Condition}.")
            }
        }
        public static string GetInput(string message, string type)
        {
            string input;
            bool isInvalid = true;

            WriteLine(message);
            do
            {
                input = Console.ReadLine();

                switch (type)
                {
                    case "string":
                    default:
                        isInvalid = !IsValidString(input);
                        break;
                    case "integer greater than 0":
                        isInvalid = !IsValidIntGreaterThanZero(input);
                        break;
                }

                if (isInvalid)
                {
                    WriteLine("Invalid input, " + type + " expected.  Please try again.");
                }
            } while (isInvalid);

            return input;
        }

        private static bool IsValidString(string str)
        {
            return true;
        }

        private static bool IsValidIntGreaterThanZero(string str)
        {
            int intOut;
            if (int.TryParse(str, out intOut))
            {
                if(intOut > 0)
                {
                    return true;
                }
            }

            return false;
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
