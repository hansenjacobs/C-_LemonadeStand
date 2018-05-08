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
        Dictionary<int, double> finalScores;
        List<Day> days;
        int numberOfDaysToPlay;
        Random random;
        Store store;
        Database database;

        public Game()
        {
            random = new Random();
            players = new List<Player>();
            days = new List<Day>();
            numberOfDaysToPlay = 2;
            store = new Store();
            database = new Database();
        }

        public void RunGame()
        {

            UI.WelcomeMessage(database);

            SetupPlayers();

            for (int i = 0; i < numberOfDaysToPlay; i++)
            {
                if(i != 0)
                {
                    days.Add(new Day(random, players, days[i - 1].Forecast, i));
                }
                else
                {
                    days.Add(new Day(random, players, i));
                }
                UI.DisplayForecast(days[i].Forecast);
                SendPlayersToStore();
                days[i].SetPlayerRecipes(store.Products);
                days[i].SimulateDay();
            }

            GetFinalScores();
            UI.DisplayFinalScores(players, finalScores);

        }

        private void GetFinalScores()
        {
            finalScores = new Dictionary<int, double>();
            for (int i = 0; i < players.Count; i++)
            {
                finalScores.Add(i, players[i].BankBalance);
                database.AddScore(players[i].Name, players[i].BankBalance);
            }
        }

        private void SendPlayersToStore()
        {
            foreach(Player player in players)
            {
                player.GoShopping(store);
            }
        }

        private void SetupComputerPlayer()
        {
            bool includeComputerPlayer;
            includeComputerPlayer = UI.GetInput("Would you like to include a computer player? <yes/no>", "yes/no") == "yes" ? true : false;

            if (includeComputerPlayer)
            {
                players.Add(new Computer(random, store));
                players[players.Count - 1].SetPlayerName("Computer Player");
            }
        }

        private void SetupHumanPlayers()
        {
            int playerCount;

            playerCount = int.Parse(UI.GetInput("How many human players will there be?", "integer greater than 0"));

            for (int i = 0; i < playerCount; i++)
            {
                // int playerLabel = i + 1;
                players.Add(new Human(store));
                players[i].SetPlayerName($"Player {i + 1}");
            }
        }

        private void SetupPlayers()
        {

            SetupHumanPlayers();
            SetupComputerPlayer();
            
        }
    }
}
