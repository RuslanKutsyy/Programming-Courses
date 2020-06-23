using System;
using System.Data.SqlClient;
using System.Net;
using System.Security;
using System.Linq;

namespace Minion_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            string connectionString = getConnectionString("SQLSRV", "MinionsDB");
            SqlConnection dbConn = new SqlConnection(connectionString);
            dbConn.Open();

            using (dbConn)
            {
                string queryText = $"SELECT 'Villain: ' + Name FROM Villains WHERE Id = {id}";
                SqlCommand sqlCmd = new SqlCommand(queryText, dbConn);
                string villainData = (string)sqlCmd.ExecuteScalar();

                if (villainData == null)
                {
                    //Console.WriteLine(String.Format(ErrorMessages.noSuchVillain, id.ToString()));
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                    return;
                }

                Console.WriteLine(villainData);

                queryText = "SELECT m.Name, m.Age FROM MinionsVillains AS mv" +
                            "JOIN Minions AS m ON mv.MinionId = m.Id" +
                            $"WHERE mv.VillainId = {id}";

                SqlDataReader reader = sqlCmd.ExecuteReader();


                int counter = 1;

                while (reader.Read())
                {
                    Console.WriteLine($"{counter}. {reader[0]}");
                    counter++;
                }
            }
        }

        public static string getConnectionString(string serverName, string database)
        {
            return $"Server={serverName};Database={database};User ID = RemoteAdmin;Password = P@ssword1";
        }
    }
}
