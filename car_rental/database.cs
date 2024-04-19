/*using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace car_rental
{
    public class DatabaseManager
    {
        private SQLiteConnection sqliteConn;
        private bool isConnected = false;

        public bool ConnectToDatabase()
        {
            var dbPath = Path.Combine(Application.StartupPath, "Database", "database.sqlite");
            var connectionString = $"Data Source={dbPath};Version=3;";
            sqliteConn = new SQLiteConnection(connectionString);

            try
            {
                sqliteConn.Open();
                isConnected = true;
                MessageBox.Show("Połączono z bazą danych!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas łączenia z bazą danych: {ex.Message}");
                isConnected = false;
            }

            return isConnected;
        }

        public void CloseConnection()
        {
            if (sqliteConn != null && sqliteConn.State == System.Data.ConnectionState.Open)
            {
                sqliteConn.Close();
                isConnected = false;
            }
        }

        public bool IsConnected()
        {
            return isConnected;
        }
    }
} */
