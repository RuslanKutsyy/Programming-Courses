using System;
using System.Data.SqlClient;

namespace Villain_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=SQLSRV;Database=MinionsDB;User ID = RemoteAdmin; Password=P@ssword1";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
                string sqlCommandText = "SELECT CONCAT(v.Name,' - ', COUNT(mv.MinionId)) FROM Villains AS v " +
                    "JOIN MinionsVillains AS mv ON mv.VillainId = v.Id GROUP BY v.Name, v.EvilnessFactorId";
                SqlCommand command = new SqlCommand(sqlCommandText, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);
                }
            }
        }
    }
}
