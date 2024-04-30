using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace cafeshopCsharp.connection_DB
{
   public class connectionDB
    {
          private MySqlConnection connect=new MySqlConnection("Server=localhost;Database=cafe_shop_db;Uid=root;");
        public void getConnectionDB() {
            try {

                if (connect.State ==System.Data.ConnectionState.Open) {
                    connect.Clone();
                }
                connect.Open();
            }
            catch (Exception ex) {
                MessageBox.Show("Connection failed:"+ ex.Message);
            }

            
        }
        
    }
}
