using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Dapper;
namespace cafeshopCsharp.modle
{
    public class Account
    {
        public int AccId { get; set; }

        public int AccEmpId { get; set; }
        public string AccLevel { get; set; }
        public string AccUserName { get; set; }
        public string AccPassword { get; set; }
    }

    public class AccountView {

        public int AccId { get; set; }
        public string empName { get; set; }
        public string empLastName { get; set; }
        public string AccLevel { get; set; }
        public string AccUserName { get; set; }
        public string AccPassword { get; set; }




    }

    public class AccountRepository {

        private readonly IDbConnection dbConnection;
        public AccountRepository(IDbConnection connection) {

            dbConnection = connection ?? throw new AggregateException(nameof(connection));

        }

        // Show Account -------------------------------------------------------------------------
        public IEnumerable<AccountView> GetAllAccount(){
            try {
                string sql = "SELECT * FROM v_account";
                return dbConnection.Query<AccountView>(sql);


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return Enumerable.Empty<AccountView>();
            }

        }
        // Login -----------------------------------------------------------------------------
        public AccountView AccountLogin(Account acc) {

          

            try
            {

                string sql = " SELECT * FROM v_account WHERE accUserName=@Username AND accPassword=@Password";
                return dbConnection.QueryFirst<AccountView>(sql, new { Username = acc.AccUserName, Password = acc.AccPassword });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Add Account--------------------------------------------------------------------------
        public void AddAccount(Account acc) {

            try { 
                string sql = "INSERT INTO tb_account (accEmpId,accLevel,accUserName,accPassword) VALUES (@accEmpId,@accLevel,@accUserName,@accPassword)";
               int rowAffected= dbConnection.Execute(sql,new { accEmpId=acc.AccEmpId, accLevel=acc.AccLevel, accUserName=acc.AccUserName, accPassword =acc.AccPassword});

                if (rowAffected==1) {
                    MessageBox.Show("ບັນທຶກສຳເລັດ","Save",MessageBoxButtons.OK);
                }

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Update Account ---------------------------------------------------------------------------------
        public void UpdateAccount(Account acc) {
            try
            {
                string sql= "UPDATE tb_account SET accEmpId=@accEmpId,accLevel=@accLevel,accUserName=@accUserName,accPassword=@accPassword WHERE accId=@accId";
                int rowAffected= dbConnection.Execute(sql,new { accEmpId=acc.AccEmpId, accLevel=acc.AccLevel, accUserName=acc.AccUserName, accPassword =acc.AccPassword,accId=acc.AccId});

                if (rowAffected == 0)
                {
                    MessageBox.Show("ແກ້ໄຂຜິດພາຍດ", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else {
                    MessageBox.Show("ແກ້ໄຂສຳເລັດ", "Edit", MessageBoxButtons.OK);
                }

             
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        public void DeleteAccount(Account acc) {
            try {

                string sql = "DELETE FROM tb_account WHERE accId=@accId";
                int rowAffected = dbConnection.Execute(sql, acc);
                if (rowAffected == 0)
                {
                    MessageBox.Show("ລົບຜິດພາຍດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ລົບສຳເລັດ", "DELETE", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

}




    }
}




