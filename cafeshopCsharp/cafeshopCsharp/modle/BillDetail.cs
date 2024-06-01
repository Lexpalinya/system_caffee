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
    public class BillDetail
    {
        public int BdblId { get; set; }
        public int BdPId { get; set; }
        public string BdSize { get; set; }
        public int BdPrice { get; set; }
        public int BdAmount { get; set; }
        public int BdTotal { get; set; }
    }
    public class showbilldetail
    {
        public string name { get; set; }
        public string type { get; set; }
        public string size{ get; set; }
        public int price { get; set; }
        public int amount { get; set; }
        public int total{ get; set; }

    }

    public class BillDetailRepository {
        private readonly IDbConnection dbConnection;

        public BillDetailRepository(IDbConnection connection ) {

            dbConnection = connection ?? throw new ArgumentException(nameof(connection));
        }
        //get bill detail from id
        public IEnumerable<showbilldetail> getbillbyid(BillDetail addid)
        {
            try
            {
                return dbConnection.Query<showbilldetail>(@"select pd.pName as name,pd.pType as type,bdt.bdSize as size,bdt.bdPrice as price,bdt.bdAmount as amount,bdt.bdTotal as total from tb_billdetail as bdt 
join tb_products as pd on bdt.bdPId = pd.pId WHERE bdt.bdblId =@bdblid",addid);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<showbilldetail>();
            }
        }


        // Add Bill Detail -----------------------------------------------------------------------

        public void AddBillDetail(BillDetail addBillDetail)
        {
            try {
                string sql = "INSERT INTO tb_billdetail (bdblId,bdPId,bdSize,bdPrice,bdAmount,bdTotal) " +
                      "VALUES (@BdblId, @BdPId, @BdSize, @BdPrice, @BdAmount, @BdTotal)";

                // Execute the SQL insert statement
                int rowsAffected = dbConnection.Execute(sql, addBillDetail);

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    
    
    
    
    
    }
}
