using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
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

    public class AccountAll:Account {
    
        public string empName { get; set; }
        public string empLastName { get; set; }
    
    
    
    
    
    }

    public class AccountRepository {

        private readonly IDbConnection dbConnection;
        public AccountRepository(IDbConnection connection) {

            dbConnection = connection ?? throw new AggregateException(nameof(connection));

        }

        // Show Account -------------------------------------------------------------------------
        public IEnumerable<AccountAll> GetAllAccount(){

            string sql = "SELECT * FROM v_account";
            return dbConnection.Query<AccountAll>(sql);
        
        }
        // Login -----------------------------------------------------------------------------
        public AccountAll AccountLogin(Account acc) {

            string sql = " SELECT * FROM v_account WHERE accUserName=@Username AND accPassword=@Password";
            return dbConnection.QueryFirst<AccountAll>(sql,new { Username=acc.AccUserName,Password=acc.AccPassword});
        }

        // Add Account--------------------------------------------------------------------------
        public void AddAccount(Account acc) {

            string sql = "INSERT INTO tb_account (accEmpId,accLevel,accUserName,accPassword) VALUES (@accEmpId,@accLevel,@accUserName,@accPassword)";
            dbConnection.Query<Account>(sql,new { accEmpId=acc.AccEmpId, accLevel=acc.AccLevel, accUserName=acc.AccUserName, accPassword =acc.AccPassword});
        }

        //Update Account ---------------------------------------------------------------------------------
        public void UpdateAccount(Account acc) {

            string sql= "UPDATE tb_account SET accEmpId=@accEmpId,accLevel=@accLevel,accUserName=@accUserName,accPassword=@accPassword WHERE accId=@accId";
            dbConnection.Query<Account>(sql,new { accEmpId=acc.AccEmpId, accLevel=acc.AccLevel, accUserName=acc.AccUserName, accPassword =acc.AccPassword,accId=acc.AccId});
        }

        public void DeleteAccount(Account acc) {

            string sql = "DELETE FROM tb_account WHERE accId=@accId";
            dbConnection.Query<Account>(sql, acc);
           
        
        }




    }
}




