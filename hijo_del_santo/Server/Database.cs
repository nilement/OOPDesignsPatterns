
using System;
using System.Data.SqlClient;

namespace Server
{
    internal class Database : IDisposable
    {
        public static string DatabaseName = "hijo.dbo.";
        public static string AccountTable = DatabaseName + "Account";
        public static string CharacterTable = DatabaseName + "Character";
        public static string ItemTable = DatabaseName + "Item";
        public static string OpponentHistoryTable = DatabaseName + "OpponentHistory";

        private static string _connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly SqlConnection _connection;
        public Database()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
