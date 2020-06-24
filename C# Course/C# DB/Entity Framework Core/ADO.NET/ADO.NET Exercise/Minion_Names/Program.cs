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
            SqlConnectionHandler newConnection = new SqlConnectionHandler();
            Console.WriteLine(newConnection.startConnection());
        }
    }
}
