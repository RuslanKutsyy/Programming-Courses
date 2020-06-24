using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Dynamic;

namespace Minion_Names
{
    public class SqlConnectionHandler
    {

        public string startConnection()
        {
            int id = int.Parse(Console.ReadLine());
            string connectionString = getConnectionString("SQLSRV", "MinionsDB");
            SqlConnection dbConn = new SqlConnection(connectionString);
            dbConn.Open();
            List<string> queries = new List<string>();

            string queryText = @"SELECT 'Villain: ' + Name FROM Villains WHERE Id = @id";
            string anotherQuery = @"SELECT m.Name, m.Age FROM MinionsVillains AS mv
                                  JOIN Minions AS m ON mv.MinionId = m.Id WHERE mv.VillainId = @id";
            queries.Add(queryText);
            queries.Add(anotherQuery);

            return GetDataFromServer(dbConn, queries, id);
        }


        private string getConnectionString(string serverName, string database)
        {
            return $"Server={serverName};Database={database};User ID = RemoteAdmin;Password = P@ssword1";
        }


        private string GetDataFromServer(SqlConnection connection, List<string> queries, int id)
        {
            StringBuilder sb = new StringBuilder();
            using (connection)
            {
                SqlCommand sqlCmd = new SqlCommand(queries[0], connection);
                sqlCmd.Parameters.AddWithValue("@id", id);
                string villainData = (string)sqlCmd.ExecuteScalar();

                if (villainData == null)
                {
                    return $"No villain with ID {id} exists in the database.";
                }

                sb.AppendLine(villainData);

                sqlCmd = new SqlCommand(queries[1], connection);
                sqlCmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = sqlCmd.ExecuteReader();
                int counter = 1;

                while (reader.Read())
                {
                    sb.AppendLine($"{counter}. {reader[0]} {reader[1]}");
                    counter++;
                }
            }

            return sb.ToString();
        }
    }
}