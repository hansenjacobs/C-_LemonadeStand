using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            do
            {
                game.RunGame();
            } while (UI.GetInput("Would you like to play again? <yes/no>", "yes/no") == "yes");
        }
    }
}
