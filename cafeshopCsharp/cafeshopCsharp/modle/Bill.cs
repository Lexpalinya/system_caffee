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
    public class Bill
    {
        public int BlId { get; set; }
        public int BlMbId { get; set; }
        public int BlAccId { get; set; }
        public double BlTotalMoney { get; set; }
        public DateTime BlDate { get; set; }
        public int BlPoint { get; set; }
    }

    public class Billpreview
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Point { get; set; }
        public string Accname { get; set; }
        public string Cusname { get; set; }
        public int price { get; set; }
    }



    public class BillRepository
    {
        private readonly IDbConnection dbConnection;
        public BillRepository(IDbConnection connection)
        {
            dbConnection = connection ?? throw new ArgumentException(nameof(connection));

        }
        //get total price
        public decimal GetTotalPriceByBillId(int billId)
        {
            try
            {
                return dbConnection.ExecuteScalar<decimal>(@"
            SELECT SUM(bdPrice) 
            FROM tb_billdetail 
            WHERE bdblId = @id", new { id = billId });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; // Return 0 if an error occurs
            }
        }
        //
        //public IEnumerable<Billpreview> GetAllBill(string role, int accId)
        //{
        //    try
        //    {

        //        string sql = "SELECT " +
        //            "b.blId AS Id, b.blDate AS Date, b.blPoint AS Point, ac.accUserName AS Accname, mb.mbName AS cusname " +
        //            "FROM tb_bill AS b " +
        //            "LEFT JOIN tb_member AS mb ON b.blMbId = mb.mbId " +
        //            "INNER JOIN tb_account AS ac ON b.blAccId = ac.accId ";

        //        if (role == "Admin")
        //        {
        //            sql += "ORDER BY b.blDate DESC";
        //            return dbConnection.Query<Billpreview>(sql);
        //        }
        //        else
        //        {
        //            sql += "WHERE b.blAccId = @accId ORDER BY b.blDate DESC";
        //            return dbConnection.Query<Billpreview>(sql, new { accId = accId });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return Enumerable.Empty<Billpreview>();
        //    }
        //}
        public int GetCountPage(string role, int accId, DateTime date)
        {
            try
            {
                string sqlcountall;
                if (role == "Admin")
                {
                    sqlcountall = @"SELECT COUNT(*) FROM tb_bill AS b WHERE CAST(b.blDate AS DATE ) = @date";
                    return dbConnection.QuerySingle<int>(sqlcountall, new { date });


                }
                else
                {
                    sqlcountall = @"SELECT COUNT(*) FROM tb_bill AS b WHERE CAST(b.blDate AS DATE) = @date and b.blAccId = @accId";
                    return dbConnection.QuerySingle<int>(sqlcountall, new { date,  accId });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
                return 0;
            }


        }

        public IEnumerable<Billpreview> GetBillsByDate(string role, int accId, DateTime date, int page)
        {
            try
            {
                // Log the date for debugging purposes
                Console.WriteLine($"Date: {date.ToShortDateString()}");

                // Base SQL query
                string sql = @"SELECT 
                        b.blId AS Id, 
                        b.blDate AS Date, 
                        b.blPoint AS Point, 
                        ac.accUserName AS Accname, 
                        mb.mbName AS Cusname 
                    FROM tb_bill AS b 
                    LEFT JOIN tb_member AS mb ON b.blMbId = mb.mbId 
                    INNER JOIN tb_account AS ac ON b.blAccId = ac.accId ";

                // Append the appropriate WHERE clause and ORDER BY clause
                string dateCondition = "CAST(b.blDate AS DATE) = @date";
                int limit = 50;
                int offset = (page - 1) * limit;

                if (role == "Admin")
                {
                    sql += $"WHERE {dateCondition} ORDER BY b.blDate DESC OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";
                    return dbConnection.Query<Billpreview>(sql, new { date, limit, offset });
                }
                else if (role == "report")
                {
                    sql += "WHERE YEAR(b.blDate) = @year AND MONTH(b.blDate) = @month";
                    return dbConnection.Query<Billpreview>(sql, new { year = date.Year, month = date.Month });
                }
                else
                {
                    sql += $"WHERE b.blAccId = @accId AND {dateCondition} ORDER BY b.blDate DESC OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";
                    return dbConnection.Query<Billpreview>(sql, new { accId, date, limit, offset });
                }
            }
            catch (Exception ex)
            {
                // Log the exception message
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Billpreview>();
            }


        }

        public IEnumerable<Bill> GetBillReport( DateTime date)
        {
            try
            {

                // Base SQL query
                string sql = @"SELECT * FROM tb_bill as b
                   WHERE YEAR(b.blDate) = @year AND MONTH(b.blDate) = @month
                 ";          

                // Append the appropriate WHERE clause and ORDER BY clause

                return dbConnection.Query<Bill>(sql, new { year = date.Year, month = date.Month });
               
            }
            catch (Exception ex)
            {
                // Log the exception message
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Bill>();
            }
        }



        // Add Bill- -------------------------------------------------------------------------
        public int AddBill(Bill addBill)
        {
            try
            {
                string sql = "INSERT INTO tb_bill (blMbId, blAccId, blTotalMoney, blDate, blPoint) OUTPUT INSERTED.blId VALUES (@blMbId, @blAccId, @blTotalMoney, @blDate, @blPoint);";

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
                string sql = "INSERT INTO tb_bill (blAccId, blTotalMoney, blDate, blPoint) OUTPUT INSERTED.blId VALUES (@blAccId, @blTotalMoney, @blDate, 0);";

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
