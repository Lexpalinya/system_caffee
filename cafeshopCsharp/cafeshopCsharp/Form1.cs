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
    public partial class Form1 : Form
    {
        private readonly SalaryPaymentRepository _salaryPaymentRepository;
        public Form1()
        {
            InitializeComponent();
            _salaryPaymentRepository = new SalaryPaymentRepository(new connectionDB().getConnection());
            if (DateTime.Today.Day == 25 || DateTime.Today.Day == 26 || DateTime.Today.Day == 27 || DateTime.Today.Day == 28)
            {
                _salaryPaymentRepository.AddSalaryPaymentByEmployee();
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int centerX = (this.Width - panel1.Width) / 2;
            int centerY = (this.Height - panel1.Height) / 2;

            panel1.Location = new Point(centerX, centerY);
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmHomePage hp = new frmHomePage();
            hp.Show();
            this.Hide();
        }
    }
}
