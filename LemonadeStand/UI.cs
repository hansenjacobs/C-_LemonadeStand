using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UI
    {

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

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
