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
    public partial class frmEmployee : Form
    {
        private readonly EmployeeRepository _employeeRepository;
        List<Employee> data=null;
        int id;
        public frmEmployee()
        {
            InitializeComponent();
            _employeeRepository = new EmployeeRepository(new connectionDB().getConnection());
            reloadData();
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            
        
        }

        private void reloadData() {
            data = (List<Employee>)_employeeRepository.GetAllEmployee();
            dataGridView1.DataSource = data;
            btnAdd.Enabled = true;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
            txtAddress.Clear();
            txtLastName.Clear();
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtPosition.Clear();
            txtSalary.Text = "0";
            pbImage.Image = null;


            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (var dt in data) {

                auto.Add(dt.EmpName);
            }
            txtSearch.AutoCompleteCustomSource = auto;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;



        }
        private bool checkTextBox() { 
        
            return string.IsNullOrWhiteSpace(txtName.Text)
                || string.IsNullOrWhiteSpace(txtLastName.Text)
                || string.IsNullOrWhiteSpace(txtPhoneNumber.Text)
                || string.IsNullOrWhiteSpace(txtPosition.Text)
                || string.IsNullOrWhiteSpace(txtAddress.Text)
                || string.IsNullOrWhiteSpace(txtSalary.Text) ;

        }

        private void btnAdd_Click(object sender, EventArgs e){
            if (checkTextBox())
            {

                MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົນຖ້ວນ", "ເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] img = new ConvertByteToImage().ImageToByteArray(pbImage.Image);

            Employee addEmployee = new Employee {
                EmpName = txtName.Text,
                EmpLastName = txtLastName.Text,
                EmpAddress = txtAddress.Text,
                EmpPhoneNumber = txtPhoneNumber.Text,
                EmpPosition = txtPosition.Text,
                EmpSalary = int.Parse(txtSalary.Text),
                EmpImage = img
                      
            };

            _employeeRepository.AddEmployee(addEmployee);
            reloadData();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {

        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&! char.IsDigit(e.KeyChar)) {
                e.Handled = true; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkTextBox())
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convert image to byte array only if PictureBox has an image
            byte[] img = pbImage.Image != null ? new ConvertByteToImage().ImageToByteArray(pbImage.Image) : null;

            Employee updateEmployee = new Employee
            {
                EmpId = id,
                EmpName = txtName.Text,
                EmpLastName = txtLastName.Text,
                EmpAddress = txtAddress.Text,
                EmpPhoneNumber = txtPhoneNumber.Text,
                EmpPosition = txtPosition.Text,
                EmpSalary = int.Parse(txtSalary.Text),
                EmpImage = img
            };
            _employeeRepository.UpdateEmployee(updateEmployee);
            reloadData();
        }

        private string getDatafromDatagridview(int cell, DataGridViewCellEventArgs e) {
            return dataGridView1.Rows[e.RowIndex].Cells[cell].Value.ToString();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                id = int.Parse(getDatafromDatagridview(0, e));
                txtName.Text = getDatafromDatagridview(1, e);
                txtLastName.Text = getDatafromDatagridview(2, e);
                txtAddress.Text = getDatafromDatagridview(3, e);
                txtPhoneNumber.Text = getDatafromDatagridview(4, e);
                txtPosition.Text = getDatafromDatagridview(5, e);
                txtSalary.Text = getDatafromDatagridview(6, e);
                byte[] img = null;
                if (dataGridView1.Rows[e.RowIndex].Cells[7].Value != null && dataGridView1.Rows[e.RowIndex].Cells[7].Value is byte[]) {
                    img = (byte[])dataGridView1.Rows[e.RowIndex].Cells[7].Value;
                }
                pbImage.Image = new ConvertByteToImage().ByteToImage(img);

                btnAdd.Enabled = false;
                btnedit.Enabled = true;
                btndelete.Enabled = true;

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ຕ້ອງການລົບຂໍ້ມູນນີ້ຫຼືບໍ?","ຢືນຢັນ",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (result==DialogResult.Yes) {
                Employee deleteEmp = new Employee
                {
                    EmpId = id
                };
                _employeeRepository.DeleteEmployee(deleteEmp);
                reloadData();
            }
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reloadData();
        }

        private void pbImage_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = fileDialog.FileName;

                try
                {

                    Image image = Image.FromFile(fileName);
                    pbImage.Image = image;

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Image:" + ex.Message);
                }

            }
        }

        private void pbImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { 
            
                frmFullImage fimg = new frmFullImage(pbImage.Image);
                fimg.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var search = data.Where<Employee>(item => {
                return item.EmpPosition.ToLower().Contains(txtSearch.Text.ToLower()) || item.EmpName.ToLower().Contains(txtSearch.Text.ToLower());
            }
           );
            dataGridView1.DataSource = search.ToArray<Employee>();

        }
    }
}
