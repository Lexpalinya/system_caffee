using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient; // Changed from MySql.Data.MySqlClient

namespace cafeshopCsharp.connection_DB
{
    public class connectionDB
    {
        private readonly SqlConnection connect = new SqlConnection("Server=.;Database=cafe;Integrated Security=True;");

        public IDbConnection getConnection()
        {
            try 
            {
                if (connect.State != ConnectionState.Open)
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
