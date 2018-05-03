using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        List<Player> players;
        List<Day> days;
        int numberOfDaysToPlay;
        Random random;
        Store store;

        public Game()
        {
            random = new Random();
            players = new List<Player>();
            days = new List<Day>();
            numberOfDaysToPlay = 7;
            store = new Store();
        }

        public void RunGame()
        {
            SetupPlayers();
            
            // Loop through X days
            for(int i = 0; i < numberOfDaysToPlay; i++)
            {
                days.Add(new Day(random));
                UI.DisplayForecast(days[i].Forecast);
                SendPlayersToStore();
                // Each player enters recipe
                // Cycle through customers
                // Display day's results
            }


            // Loop next day

            // Display final results of each user
            // Annouce winner if multiple players
        }

        public void SendPlayersToStore()
        {
            foreach(Player player in players)
            {
                player.GoShopping(store);
            }
        }

        public void SetupComputerPlayer()
        {
            bool includeComputerPlayer;
            includeComputerPlayer = UI.GetInput("Would you like to include a computer player?", "yes/no") == "yes" ? true : false;

            if (includeComputerPlayer)
            {
                players.Add(new Computer(random, store));
                players[players.Count - 1].SetPlayerName("Computer Player");
            }
        }

        public void SetupHumanPlayers()
        {
            int playerCount;

            playerCount = int.Parse(UI.GetInput("How many human players will there be?", "integer greater than 0"));

            for (int i = 0; i < playerCount; i++)
            {
                players.Add(new Human(store));
                players[i].SetPlayerName($"Player {i}");
            }
        }

        public void SetupPlayers()
        {

            SetupHumanPlayers();
            SetupComputerPlayer();
            
        }
    }
}
