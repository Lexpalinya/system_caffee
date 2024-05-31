using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;


namespace cafeshopCsharp.modle
{
  public class Bill{
    public int BlId { get; set; }
    public int  BlMbId{ get; set; }
    public int BlAccId { get; set; }
    public double BlTotalMoney { get; set; }
    public DateTime BlDate { get; set; }
    public int BlPoint { get; set; }
  }


    public class BillRepository {
        private readonly IDbConnection dbConnection;
        public BillRepository(IDbConnection connection){
            dbConnection = connection ?? throw new ArgumentException(nameof(connection));
        
        }
        public IEnumerable<Bill> getallbill()
        {
            try
            {
                return dbConnection.Query<Bill>("SELECT blId, blDate, blPoint, ac.accUserName, mb.mbName FROM `tb_bill` AS b INNER JOIN tb_member as mb ON b.blMbId = mb.mbId INNER JOIN tb_account as ac ON b.blAccId = ac.accId");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<Bill>();
            }
        }


        // Add Bill- -------------------------------------------------------------------------
        public int AddBill(Bill addBill) {
            try {
                string sql = "INSERT INTO tb_bill (blMbId,blAccId,blTotalMoney,blDate,blPoint) VALUES (@blMbId,@blAccId,@blTotalMoney,@blDate,@blPoint); "+ "SELECT LAST_INSERT_ID();";
                int lastInsertedId = dbConnection.QuerySingle<int>(sql, addBill);

                return lastInsertedId;
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public int AddBillNoMember(Bill addBill)
        {
            try
            {
                string sql = "INSERT INTO tb_bill (blAccId,blTotalMoney,blDate) VALUES (@blAccId,@blTotalMoney,@blDate); " + "SELECT LAST_INSERT_ID();"; ;
                int lastInsertedId = dbConnection.QuerySingle<int>(sql, addBill);

                return lastInsertedId;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }




    }

}
