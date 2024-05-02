using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<PaidRecord> GetAllPaidRecord() {

            return dbConnection.Query<PaidRecord>("SELECT * FROM tb_paidrecord");
        }


        public IEnumerable<PaidRecord> GetPaidRecordBYMoth(PaidRecord paidRecord) {

            return dbConnection.Query<PaidRecord>("SELECT * FROM tb_paidrecord WHERE YEAR(prDate) =@year AND MONTH(prDate) = @month",new{year=paidRecord.PrDate.Year,month=paidRecord.PrDate.Month});
        }

        public void AddPaidRecord(PaidRecord paidRecord) {
            dbConnection.Query<PaidRecord>("INSERT INTO tb_paidrecord (prText,prAmount,prPrice,prTotal,prDate) VALUES (@prText,@prAmount,@prPrice,@prTotal,@prDate)  ", paidRecord); 
        }

        public void UpdatePaidRecord(PaidRecord paidRecord) {
            dbConnection.Query<PaidRecord>("UPDATE tb_paidrecord SET prText=@prText,prAmount=@prAmount,prPrice=@prPrice,prTotal=@prTotal,prDate=@prDate WHERE prId=@prID", paidRecord);
        }
        public void DeletePaidRecord(PaidRecord paidRecord) {
            dbConnection.Query<PaidRecord>("DELETE FROM tb_paidrecord WHERE prId=@prId",paidRecord);
        }
    
    
    
    
    
    
    }
}
