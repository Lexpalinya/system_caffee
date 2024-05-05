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
    public partial class frmSeller : Form
    {
        private readonly AccountRepository _accountRepository;
        private readonly EmployeeRepository _employeeRepository;
        private List<AccountView> data;

        int id;
        string usernameforcheck;
        public frmSeller()
        {
            _accountRepository = new AccountRepository(new connectionDB().getConnection());
            _employeeRepository = new EmployeeRepository(new connectionDB().getConnection());
            InitializeComponent();
            data =(List<AccountView>) _accountRepository.GetAllAccount();

        }



      
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbEmp.Text == "------ກະລຸນາເລືອກພະນັກງານ-----")
            {
                MessageBox.Show("ກະລຸນາເລືອກພະນັກງານ","ແຈ້ງເຕືອນ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            
            }
            if (cmbLevel.Text == "---ເລືອກລະດັບ---") {
                MessageBox.Show("ກະລຸນາເລືອກລະດັບບັນຊີ", "ແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)) {
                MessageBox.Show("ກະລຸນາເລືອກປ້ອນຂໍ້ມູນໃຫ້ຄົບຖ້ວນ", "ແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            Account addAccount = new Account
            {
                AccEmpId = int.Parse(cmbEmp.SelectedValue.ToString()),
                AccLevel = cmbLevel.Text,
                AccPassword = txtPassword.Text,
                AccUserName = txtUserName.Text

            };
            var findAccount = data.FirstOrDefault(items => items.AccUserName == txtUserName.Text);
            if (findAccount != null)
            {
                MessageBox.Show("Username: " + txtUserName.Text + " has already been taken. Please choose another one.");
                txtUserName.Focus();
                return;
            }

            _accountRepository.AddAccount(addAccount);
            showData();
        }

        private void searchAutoComplete(List<Employee> employees) {

            AutoCompleteStringCollection search = new AutoCompleteStringCollection();
            foreach (var dr in employees)
            {
                search.Add(dr.EmpName.ToString());
            }
            txtSearch.AutoCompleteCustomSource = search;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;


        }


        private void addComboboxAndAutoComplete(List<Employee> employees) {

            employees.ForEach(emp => emp.EmpName = emp.EmpName + " " + emp.EmpLastName);

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (var dr in employees)
            {
                auto.Add(dr.EmpName.ToString());
            }

            Employee newEmployee = new Employee { EmpId = 0, EmpName = "------ກະລຸນາເລືອກພະນັກງານ-----" };
            employees.Insert(0, newEmployee);
            cmbEmp.ValueMember = "empId";
            cmbEmp.DisplayMember = "empName";
            cmbEmp.DataSource = employees;
            cmbEmp.SelectedIndex = 0;
            cmbEmp.AutoCompleteCustomSource = auto;
            cmbEmp.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbEmp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            cmbEmp.SelectAll();
            cmbEmp.Focus();
        }

        private void frmSeller_Load(object sender, EventArgs e)
        {
            List<Employee> employees= (List<Employee>)_employeeRepository.GetAllEmployee();

            searchAutoComplete(employees);
            addComboboxAndAutoComplete(employees);
            showData();
           
        }

        private void showData() {
             data = (List<AccountView>)_accountRepository.GetAllAccount();
            dataGridView1.DataSource = data;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            clearText();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbEmp.Text == "------ກະລຸນາເລືອກພະນັກງານ-----")
            {
                MessageBox.Show("ກະລຸນາເລືອກພະນັກງານ", "ແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (cmbLevel.Text == "---ເລືອກລະດັບ---")
            {
                MessageBox.Show("ກະລຸນາເລືອກລະດັບບັນຊີ", "ແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("ກະລຸນາເລືອກປ້ອນຂໍ້ມູນໃຫ້ຄົບຖ້ວນ", "ແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            Account updateAccount = new Account
            {
                AccId=id,
                AccEmpId = int.Parse(cmbEmp.SelectedValue.ToString()),
                AccLevel = cmbLevel.Text,
                AccPassword = txtPassword.Text,
                AccUserName = txtUserName.Text

            };
            var findAccount = data.FirstOrDefault(items => items.AccUserName == txtUserName.Text);
            if (findAccount != null && txtUserName.Text!=usernameforcheck)
            {
                MessageBox.Show("Username: " + txtUserName.Text + " has already been taken. Please choose another one.");
                txtUserName.Focus();
                return;
            }
            _accountRepository.UpdateAccount(updateAccount);
            showData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Account deleteAccount = new Account {
                AccId = id
            };
            _accountRepository.DeleteAccount(deleteAccount);
            showData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                cmbEmp.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbLevel.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                usernameforcheck=dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtUserName.Text = usernameforcheck; 
                txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
             
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);

            }


        }
        private void clearText() {
            txtPassword.Clear();
            txtUserName.Clear();
            cmbEmp.SelectedIndex = 0;
            cmbLevel.Text = "---ເລືອກລະດັບ---";



        }

        private void reload_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var searchName = data.Where<AccountView>(items => items.empName == txtSearch.Text);
            dataGridView1.DataSource=searchName.ToArray<AccountView>();
        }
    }
}
