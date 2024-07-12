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
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpPhoneNumber { get; set; }
        public string EmpPosition { get; set; }
        public int EmpSalary { get; set; }
        public byte[] EmpImage { get; set; }
    }

    public class EmployeeRepository {
        private readonly IDbConnection dbConnection;
        public EmployeeRepository(IDbConnection connection) {
            dbConnection = connection ?? throw new ArgumentException(nameof(connection));
        
        }

        // GetAllEmployee----------------------------------------------------------------
        public IEnumerable<Employee> GetAllEmployee() {

            try {
                string sql = "SELECT * FROM tb_employee";
                return dbConnection.Query<Employee>(sql);
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Enumerable.Empty<Employee>();
            }
        }


        // Add Employee ---------------------------------------------------------------
        public void AddEmployee(Employee emp) {
            try
            {
                string sql = "INSERT INTO tb_employee (empName,empLastName,empAddress,empPhoneNumber,empPosition,empSalary,empImage) VALUES(@empName,@empLastName,@empAddress,@empPhoneNumber,@empPosition,@empSalary,@empImage) ";
                int rowAffected = dbConnection.Execute(sql, emp);

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
        // Update Employee ----------------------------------------------------------------
        public void UpdateEmployee(Employee emp) {
            try {
                string sql = "";
                if (emp.EmpImage != null)
                {
                    sql = "UPDATE tb_employee SET empName=@empName,empLastName=@empLastName,empAddress=@empAddress,empPhoneNumber=@empPhoneNumber,empPosition=@empPosition,empSalary=@empSalary,empImage=@empImage WHERE empId=@empId ";
                }
                else { 
                    sql = "UPDATE tb_employee SET empName=@empName,empLastName=@empLastName,empAddress=@empAddress,empPhoneNumber=@empPhoneNumber,empPosition=@empPosition,empSalary=@empSalary WHERE empId=@empId ";
                }
                int rowAffected = dbConnection.Execute(sql,emp);

            if (rowAffected == 0)
            {
                MessageBox.Show("ແກ້ໄຂຜິດພາດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Delete Employee ------------------------------------------------------------------

        public void DeleteEmployee(Employee emp)
        {
            try
            {
                string sql = "DELETE FROM tb_employee WHERE empId=@empId";
                
                int rowAffected = dbConnection.Execute(sql,emp);

                if (rowAffected == 0)
                {
                    MessageBox.Show("ລົບຜິດພາດ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

