using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LemonadeStand
{
    public class Database
    {
        static string connectionString = "Data Source=JSHLAPTOP;Initial Catalog=LemonadeStand;Integrated Security=True";
        SqlConnection connection;

        public Database()
        {
            connection = new SqlConnection(connectionString);
        }

        public bool AddScore(string PlayerName, double Score)
        {
            if (OpenConnection())
            {
                SqlCommand command = new SqlCommand($"INSERT INTO dbo.HighScores (PlayerName, Score) VALUES('{PlayerName}', {Score.ToString()});", connection);
                command.ExecuteNonQuery();
                CloseConnection();
                return true;
            }

            return false;
        }

        private void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error closing DB connection.\n\n" + e.Message);
            }
        }

        public string GetHighScores()
        {
            SqlCommand command;
            SqlDataReader reader = null;
            string output = "            HIGH SCORES            \n=====================================\nRk  Player                      Score\n-------------------------------------";

            if (OpenConnection())
            {
                try
                {
                    command = new SqlCommand("SELECT TOP (10) ROW_NUMBER() over (ORDER BY Score DESC) AS Rank, PlayerName, Score FROM LemonadeStand.dbo.HighScores ORDER BY Score DESC, ScoreDateTime ASC;", connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int rank = Convert.ToInt32(reader["Rank"]);
                        string playerName = reader["PlayerName"].ToString();
                        double score = Convert.ToDouble(reader["Score"]);

                        output += $"\n{rank.ToString("G0").PadLeft(2)}  {playerName.PadRight(20)}  {score.ToString("C2").PadLeft(11)}";
                    }

                }
                finally
                {
                    if(reader != null)
                    {
                        reader.Close();
                    }

                    if(connection != null)
                    {
                        connection.Close();
                    }
                }

            }

            return output;
        }
        
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error opeing DB connection.\n\n" + e.Message);
                return false;
            }
            return true;
        }

    }
}
