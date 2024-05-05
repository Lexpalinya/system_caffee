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

        private Member memberData = new Member();

        public frmSearchMember()
        {
            InitializeComponent();
            _memberRepository = new MemberRepository(conn.getConnection());


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

               int id= _memberRepository.AddMember(memberData);
                memberData.mbId = id;
             

                // send memberData  -----------------------------------------------------

            }
            else {

                if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    MessageBox.Show("ບໍ່ມີເບີສະມາຊິກ", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    // send memberData  -----------------------------------------------------

                    return;
                }
              
                memberData = _memberRepository.GetMember(txtPhoneNumber.Text);
                if (memberData != null)
                {
                    txtName.Text = memberData?.mbName;
                    txtAddress.Text = memberData?.mbAddress;


                    // send memberData  -----------------------------------------------------






                }
                else {
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
        // textboxfocus  ---------------------------------------------------------------------
        private void textFocus() {


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
       
        //  ckeck textbox for add member  -------------------------------------
        private bool checkText() {

            bool condition = string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text);
            return condition;
        }
    }
}
