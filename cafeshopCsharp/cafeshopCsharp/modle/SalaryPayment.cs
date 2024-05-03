using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Dapper;

namespace cafeshopCsharp.modle
{
    public class SalaryPayment
    {
        public int SpId { get; set; }
        public int SpEmpId { get; set; }
        public int SpSalary { get; set; }
        public DateTime SpPayday { get; set; }
        public int SpStatusPay { get; set; }
    }

    public class SalaryPaymentView:SalaryPayment {

        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
    }

    public class SalaryPaymentRepository {

        private readonly IDbConnection dbConnection;
        public SalaryPaymentRepository(IDbConnection connection){
            dbConnection = connection ?? throw new ArgumentException(nameof(connection));

        }
        // GetAllSalaryPaymentView -------------------------------------------------------------------------------------
        public IEnumerable<SalaryPaymentView> GetAllSalaryPaymentViews() {

            try {
                string sql = "SELECT * FROM v_salarypayment";
                return dbConnection.Query<SalaryPaymentView>(sql);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<SalaryPaymentView>();
            }
        }


        // GetSalaryPaymentViewByMonthYear-------------------------------------------------------------------------------
        public IEnumerable<SalaryPaymentView> GetSalaryPaymentViewsByMonthYear(SalaryPayment salaryPayment) {

            try
            {
                string sql = "SELECT * FROM v_salarypayment WHERE   YEAR(spPayday)=@year AND MONTH(spPayday)=@month ";
                return dbConnection.Query<SalaryPaymentView>(sql,new { year=salaryPayment.SpPayday.Year ,month=salaryPayment.SpPayday.Month});
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<SalaryPaymentView>();
            }
        }

        // AddSalaryPayment ------------------------------------------------------------------------------------------------
        public void AddSalaryPayment(SalaryPayment salaryPayment) {
            try {
                string sql = "INSERT INTO tb_salaryPayment (spEmpId,spSalary,spPayday,spStatusPay) VALUES (@spEmpId,@spSalary,@spPayday,@spStatusPay)";

                int rowAffected = dbConnection.Execute(sql,salaryPayment);

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


        //UpdateStatusSalayPayment ---------------------------------------------------------------------------------------------
        public void UpdateStatusSalaryPayment(SalaryPayment salaryPayment) {

            try {
                string sql = "UPDATE tb_salaryPayment SET spStatusPay =@spStatusPay WHERE spId=@spId";

                int rowAffected = dbConnection.Execute(sql,salaryPayment);
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
        // DeleteSalaryPayment ----------------------------------------------------------------------------------------------------

        public void DeleteSalayPayment(SalaryPayment salaryPayment) {
            try {
                string sql = "DELETE FROM tb_salarypayment WHERE spId=@spId";
                int rowAffected = dbConnection.Execute(sql,salaryPayment);

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
