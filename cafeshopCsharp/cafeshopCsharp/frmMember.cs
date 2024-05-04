using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cafeshopCsharp.modle;
using cafeshopCsharp.connection_DB;
namespace cafeshopCsharp
{
    public partial class frmMember : Form
    {
        private MemberRepository memberrepo;
         
        
        public frmMember()
        {
            
            InitializeComponent();
            
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // add
        private void button1_Click(object sender, EventArgs e)
        {
            int point;
            
            if (int.TryParse(textBox4.Text, out point)&& !(string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrWhiteSpace(textBox3.Text) && string.IsNullOrWhiteSpace(textBox4.Text)
               ))
            {

                Member newmember = new Member
                {
                    mbName = textBox1.Text,
                    mbPhoneNumber = textBox2.Text,
                    mbAddress = textBox3.Text,
                    mbPoints = point
    
                };
                memberrepo.AddMember(newmember);
                loadMember();
            }
            else
            {
                string errortext = (string.IsNullOrWhiteSpace(textBox1.Text) ||
                      string.IsNullOrWhiteSpace(textBox2.Text) ||
                      string.IsNullOrWhiteSpace(textBox3.Text) ||
                      string.IsNullOrWhiteSpace(textBox4.Text) ) ? "ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບ"
                   : !int.TryParse(textBox4.Text, out point)?"ແຕ້ມຕ້ອງເປັນໂຕເລກ" 
                   :"brhu";


                MessageBox.Show(errortext, "ຜິດຜາດ", MessageBoxButtons.OK);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            loadMember();
            
        }
        private void loadMember()
        {
            connectionDB connect = new connectionDB();
            memberrepo = new MemberRepository(connect.getConnection());
            dataGridView1.DataSource = memberrepo.GetAllMembers();
            connect.closecn();
        }
    }
}
