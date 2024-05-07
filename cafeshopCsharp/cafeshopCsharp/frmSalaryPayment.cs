using cafeshopCsharp.connection_DB;
using cafeshopCsharp.modle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeshopCsharp
{
    public partial class FrmSalaryPayment : Form
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly SalaryPaymentRepository _salaryPaymentRepository;
        List<SalaryPaymentView> data;
        List<Employee> emp;
        List<Employee> searchEmpId;
        int idemp;
        int id;
        public FrmSalaryPayment() {
            _salaryPaymentRepository = new SalaryPaymentRepository(new connectionDB().getConnection());
            _employeeRepository=new EmployeeRepository(new connectionDB().getConnection());
            emp = (List<Employee>)_employeeRepository.GetAllEmployee();
            searchEmpId= (List<Employee>)_employeeRepository.GetAllEmployee();
            InitializeComponent();
            CmbEmpShow();
            ReloadData(); 
            dateTimePicker1.Text = DateTime.Today.ToString();
            checkBox1.Text = "ຍັງບໍ່ທັນໄດ້ສຳລະ";
        }

        // show data in data gridview  and fetch data ------------------------------------------------------------------
        private void ReloadData() {
            try {
                data = (List<SalaryPaymentView>)_salaryPaymentRepository.GetAllSalaryPaymentViews();
                dataGridView1.DataSource = data;

                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                cmbEmp.Text= "------ກະລຸນາເລືອກພະນັກງານ-----";
                dateTimePicker1.Text = DateTime.Today.ToString();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        // combobox ---------------------------------------------------
        private void CmbEmpShow() {
          
           
            AutoCompletement(emp, cmbEmp);
           
            AutoCompletement(searchEmpId, cmbsearch);

        }

        // set data in combobox and autocomplete  -----------------------------------
        private void AutoCompletement(List<Employee> em,ComboBox combo) {
            em.ForEach(item => item.EmpName = item.EmpName + " " + item.EmpLastName);
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (var dt in em)
            {
                auto.Add(dt.EmpName);
            }

            combo.AutoCompleteCustomSource = auto;
            combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Employee newEmployee = new Employee { EmpId = 0, EmpName = "------ກະລຸນາເລືອກພະນັກງານ-----" };
            em.Insert(0, newEmployee);
            combo.ValueMember = "empId";
            combo.DisplayMember = "empName";
            combo.DataSource = em.ToArray<Employee>();
            combo.SelectedIndex = 0;
        }

        // set text Checkbox ------------------------------------------------------------------
       private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "ສຳລະສຳເລັດ";
            }
            else {
                checkBox1.Text = "ຍັງບໍ່ທັນໄດ້ສຳລະ";
            }
        }
        // btn save data -------------------------------------------------------------------------
        private void Button1_Click(object sender, EventArgs e)
        {
            try {
               
                //hashdle combobox for save data 
                if (cmbEmp.SelectedIndex == 0) {
                    MessageBox.Show("ກະລຸນາເລືອກພະນັກງານ", "ແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // get id Emp from combobox 
                int idemp = int.Parse(cmbEmp.SelectedValue.ToString());

                // find Salary by id Emp 
                var findSalary= emp.FirstOrDefault<Employee>(item => item.EmpId == idemp);
                
                // data add
                SalaryPayment addSalaryPayment = new SalaryPayment {
                    SpEmpId =idemp,
                    SpSalary=int.Parse(txtSalary.Text),
                    SpPayday=dateTimePicker1.Value
                };
                // check salarypayment in month
                SalaryPaymentView checkEmpPayment = _salaryPaymentRepository.GetSalaryPaymentViewsByMonthYearAndEmpId(addSalaryPayment);
                
                if (checkEmpPayment != null) {
                    MessageBox.Show("ໄດ້ມີການບັນທຶກການຈ່າຍເງິນໃນເດືອນ " + dateTimePicker1.Value.ToString()+"ໃຫ້ພະນັກງານ \n"+cmbEmp.Text +"ແລ້ວ\n ເປັນຈຳນວນເງິນ :"+checkEmpPayment.SpSalary.ToString());
                    return;
                }


                 _salaryPaymentRepository.AddSalaryPayment(addSalaryPayment);
                 ReloadData();
               
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        // get salary from emp salary  set txtSalary-------------------------------------------
        private void CmbEmp_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            idemp = int.Parse(cmbEmp.SelectedValue.ToString());
            var findSalary = emp.FirstOrDefault<Employee>(item => item.EmpId == idemp);
            txtSalary.Text = findSalary.EmpSalary.ToString();
        }

        // reload datagridveiw-------------------------------------------------------------
        private void Button4_Click(object sender, EventArgs e)
        {
            ReloadData();
        }


        
        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            // get data from datagridveiw for set combox and textbox  by Mouse Left Click ------------------------------------------------
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (e.Button == MouseButtons.Left)
            {

                try
                {
                    cmbEmp.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtSalary.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    checkBox1.Checked = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "1";

                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // update status SalaryPayment  by Mouse Right click  and status  0 -----------------------------------------------------
            else if(e.Button==MouseButtons.Right && dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "0")
            {
                try
                {

                  
                    string fullname = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    int salary = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    DialogResult result = MessageBox.Show("ຕ້ອງການສຳລະເງິນໃຫ້\n ຊື່: " + fullname + "\n ຈຳນວນເງິນ :" + salary, "ຢືນຢັນ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SalaryPayment updateStatus = new SalaryPayment
                        {
                            SpId = id,
                            SpStatusPay = 1
                        };

                        _salaryPaymentRepository.UpdateStatusSalaryPayment(updateStatus);
                        ReloadData();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

       
        // btn update All data ----------------------------------------------------------
        private void Button2_Click(object sender, EventArgs e)
        {
            try {
                SalaryPayment updateStatus = new SalaryPayment
                {
                    SpId = id,
                    SpEmpId = idemp,
                    SpSalary = int.Parse(txtSalary.Text),
                    SpPayday = dateTimePicker1.Value,
                    SpStatusPay = checkBox1.Checked == true ? 1 : 0
                   
                };

                _salaryPaymentRepository.UpdateStatusSalaryPayment(updateStatus);
                ReloadData();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //btn delete data ------------------------------------------------------------------

        private void Button3_Click(object sender, EventArgs e)
        {
            try {
                SalaryPayment delete= new SalaryPayment
                {
                    SpId = id,
                };
                _salaryPaymentRepository.DeleteSalayPayment(delete);
                ReloadData();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // search SalaryPayment by MonthYear and Status -------------------------------------------------
        private void SearchByMonthYearAndStatus() {
            try
            {
                SalaryPayment sp = new SalaryPayment {
                   
                    SpPayday=dateTimePicker2.Value,
                    SpStatusPay= checkBox2.Checked == true ? 1 : 0

                };
             
               dataGridView1.DataSource = _salaryPaymentRepository.GetSalaryPaymentViewsByMonthYearAndStatus(sp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            SearchByMonthYearAndStatus();

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
           
            SearchByMonthYearAndStatus();
        }


        // search SalaryPayment by EmpId ------------------------------------------------------------------------
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {

                SalaryPayment findByIdEmp = new SalaryPayment {
                    SpEmpId=int.Parse(cmbsearch.SelectedValue.ToString())
                };
              dataGridView1.DataSource= _salaryPaymentRepository.GetSalaryPaymentViewsByIdEmployee(findByIdEmp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }       
        
    }
}
