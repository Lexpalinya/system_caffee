using cafeshopCsharp.connection_DB;
using cafeshopCsharp.modle;
using System;
using System.Windows.Forms;

namespace cafeshopCsharp
{
    public partial class frmSearchMember : Form
    {
        private readonly MemberRepository _memberRepository;
        private connectionDB conn = new connectionDB();
        private frmSell frmsell;

        private Member memberData = new Member();

        public frmSearchMember()
        {
            InitializeComponent();
        }

        public frmSearchMember(frmSell frm)
        {
            this.frmsell = frm;
            _memberRepository = new MemberRepository(conn.getConnection());
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.MdiParent.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (checkText())
                {
                    MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບ", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                memberData = new Member
                {
                    mbName = txtName.Text,
                    mbPhoneNumber = txtPhoneNumber.Text,
                    mbAddress = txtAddress.Text,
                    mbPoints = 0
                };

                if (isExistingMember(txtPhoneNumber.Text))
                {
                    MessageBox.Show("ເບີນີ້\n" + txtPhoneNumber.Text + "\nໄດ້ສະໝັກແລ້ວ");
                    return;
                }

                int id = _memberRepository.AddMember(memberData);
                memberData.mbId = id;

                frmsell.member(memberData); // Ensure this method is now defined in frmSell
                this.Close();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    MessageBox.Show("ບໍ່ມີເບີສະມາຊິກ", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                memberData = _memberRepository.GetMember(txtPhoneNumber.Text);
                if (memberData != null)
                {
                    txtName.Text = memberData?.mbName;
                    txtAddress.Text = memberData?.mbAddress;

                    frmsell.member(memberData); // Ensure this method is now defined in frmSell
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ບໍ່ພົບ ເບີສະມາຊິກ : " + txtPhoneNumber.Text);
                    txtPhoneNumber.Focus();
                }
            }
        }

        private bool isExistingMember(string phoneNumber)
        {
            return _memberRepository.GetMember(phoneNumber) != null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                btn.Text = "ເພີ່ມ";
            }
            else
            {
                btn.Text = "ຄົ້ນຫາ";
            }
        }

        private void textFocus()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Focus();
                txtName.SelectAll();
            }
            else if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txtAddress.Focus();
                txtAddress.SelectAll();
            }
            else if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                txtPhoneNumber.Focus();
                txtPhoneNumber.SelectAll();
            }
        }

        private bool checkText()
        {
            bool condition = string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text);
            return condition;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                memberData.mbId = 0;
                memberData.mbPoints = 0;

                frmsell.member(memberData); // Ensure this method is now defined in frmSell
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
