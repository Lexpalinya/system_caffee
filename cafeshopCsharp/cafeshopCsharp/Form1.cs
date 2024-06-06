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
        private readonly AccountRepository _accountRepository;
        public Form1()
        {
            InitializeComponent();
            _salaryPaymentRepository = new SalaryPaymentRepository(new connectionDB().getConnection());
            if (DateTime.Today.Day == 25 || DateTime.Today.Day == 26 || DateTime.Today.Day == 27 || DateTime.Today.Day == 28)
            {
                _salaryPaymentRepository.AddSalaryPaymentByEmployee();
            }

            _accountRepository = new AccountRepository(new connectionDB().getConnection());



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
            try {
                if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນສຳລັບການເຂົ້າສູ່ລະບົບ", "ຄຳແນະນຳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Account account = new Account
                {
                    AccUserName = txtUsername.Text,
                    AccPassword = txtPassword.Text
                };
                var login = _accountRepository.AccountLogin(account);
                if (login == null)
                {
                    MessageBox.Show("ກະລຸນາກວດສອບ ຊື່ຜູ້ໃຊ້ ແລະ ລະຫັດຜ່ານ", "ການເຂົ້າສູ່ລະບົບຜິດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AccountView accountVie = new AccountView
                {
                    AccId = login.AccId,
                    AccUserName = login.AccUserName,
                    empLastName = login.empLastName,
                    empName = login.empName,
                    AccLevel = login.AccLevel
                };

                frmHomePage hp = new frmHomePage(accountVie
                    );
                hp.Show();
                this.Hide();
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
            
            
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
                    {
                        MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນສຳລັບການເຂົ້າສູ່ລະບົບ", "ຄຳແນະນຳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Account account = new Account
                    {
                        AccUserName = txtUsername.Text,
                        AccPassword = txtPassword.Text
                    };
                    var login = _accountRepository.AccountLogin(account);
                    if (login == null)
                    {
                        MessageBox.Show("ກະລຸນາກວດສອບ ຊື່ຜູ້ໃຊ້ ແລະ ລະຫັດຜ່ານ", "ການເຂົ້າສູ່ລະບົບຜິດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    AccountView accountVie = new AccountView
                    {
                        AccId = login.AccId,
                        AccUserName = login.AccUserName,
                        empLastName = login.empLastName,
                        empName = login.empName,
                        AccLevel = login.AccLevel
                    };

                    frmHomePage hp = new frmHomePage(accountVie
                        );
                    hp.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);


                }
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
          
        }
    }
}
