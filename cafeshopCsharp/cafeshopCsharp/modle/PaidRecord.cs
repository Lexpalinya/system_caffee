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
    public class PaidRecord
    {
        public int PrId { get; set; }
        public string PrText { get; set; }
        public int PrAmount { get; set; }
        public int PrPrice { get; set; }
        public int PrTotal { get; set; }
        public DateTime PrDate { get; set; }
    }
    public class PaidRecordRepository {
        private readonly IDbConnection dbConnection;
        public PaidRecordRepository(IDbConnection connection) {
            dbConnection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        // GetAllPaidRecord -----------------------------------------------------------------------------------------------------
        public IEnumerable<PaidRecord> GetAllPaidRecord() {
            try { 
                return dbConnection.Query<PaidRecord>("SELECT * FROM tb_paidrecord");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<PaidRecord>();
            }
        }

        // GetPaidRecord by Month ------------------------------------------------------------------------------------------------------
        public IEnumerable<PaidRecord> GetPaidRecordBYMoth(PaidRecord paidRecord) {
            try {
                string sql = "SELECT * FROM tb_paidrecord WHERE YEAR(prDate) =@year AND MONTH(prDate) = @month";
                return dbConnection.Query<PaidRecord>(sql,new{year=paidRecord.PrDate.Year,month=paidRecord.PrDate.Month});

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<PaidRecord>();
            }

        }
        
        // Add PaidRecord ----------------------------------------------------------------------------------------------------------------
        public void AddPaidRecord(PaidRecord paidRecord) {
            try {
                string sql = "INSERT INTO tb_paidrecord (prText,prAmount,prPrice,prTotal,prDate) VALUES (@prText,@prAmount,@prPrice,@prTotal,@prDate)  ";
                int rowAffected=dbConnection.Execute(sql, paidRecord);
                if (rowAffected == 1)
                {
                    MessageBox.Show("ບັນທຶກສຳເລັດ", "Save", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Update PaidRecord -------------------------------------------------------------------------------------------
        public void UpdatePaidRecord(PaidRecord paidRecord) {
            try
            {
                string sql = "UPDATE tb_paidrecord SET prText=@prText,prAmount=@prAmount,prPrice=@prPrice,prTotal=@prTotal,prDate=@prDate WHERE prId=@prID";
                int rowAffected= dbConnection.Execute(sql, paidRecord);
                if (rowAffected == 0)
                {
                    MessageBox.Show("ແກ້ໄຂຜິດພາຍດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ແກ້ໄຂສຳເລັດ", "Edit", MessageBoxButtons.OK);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        // Delete PaidRecord -----------------------------------------------------------------------------------------------
        public void DeletePaidRecord(PaidRecord paidRecord) {
            try {
                string sql = "DELETE FROM tb_paidrecord WHERE prId=@prId";
                int rowAffected= dbConnection.Execute(sql,paidRecord);
                if (rowAffected == 0)
                {
                    MessageBox.Show("ລົບຜິດພາຍດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ລົບສຳເລັດ", "DELETE", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    
    }
}
