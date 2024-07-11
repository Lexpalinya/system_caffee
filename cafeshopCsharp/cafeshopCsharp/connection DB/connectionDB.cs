using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cafeshopCsharp.connection_DB
{
    public class connectionDB
    {
        private readonly MySqlConnection connect = new MySqlConnection("Server=localhost;Database=cafe_shop_db;Uid=root;");

        public IDbConnection getConnection()
        {
            try
            {
                if (connect.State != System.Data.ConnectionState.Open)
                {
                    connect.Open();
                   // MessageBox.Show("Connection successful");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }

            return connect;
        }
        
        
    }
}
