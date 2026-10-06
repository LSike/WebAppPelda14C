using MySql.Data.MySqlClient;
namespace WebAppPelda.DataManager
{
    public class DBManager
    {
        string connectionString =
            "Server=localhost;" +
            "Database=WebAppPeldaDB;" +
            "User=root;" +
            "Password=;";
        public MySqlConnection CreateConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);            
            return connection;
        }
    }
}
