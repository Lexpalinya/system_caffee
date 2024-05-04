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
        String mbid;
        public frmMember()
        {
            connectionDB connect = new connectionDB();
            memberrepo = new MemberRepository(connect.getConnection());
            InitializeComponent();
<<<<<<< Updated upstream
            
        }       
=======
<<<<<<< HEAD


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
=======
            
        }       
>>>>>>> bd666ae784e47a33b9e2884c571ef0710a1ae798
>>>>>>> Stashed changes

        // add
        private void button1_Click(object sender, EventArgs e)
        {
            int point;
            if (int.TryParse(textBox4.Text, out point)&& !(string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrWhiteSpace(textBox3.Text) && string.IsNullOrWhiteSpace(textBox4.Text)))
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

        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            int point;
            int id;
            if (  Cellclick == true && int.TryParse(mbid, out id) && int.TryParse(textBox4.Text, out point) && !(string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrWhiteSpace(textBox3.Text) && string.IsNullOrWhiteSpace(textBox4.Text)
               ) )
            {

                Member updatemb = new Member
                {
                    mbId = id,
                    mbName = textBox1.Text,
                    mbPhoneNumber = textBox2.Text,
                    mbAddress = textBox3.Text,
                    mbPoints = point

                };
                memberrepo.UpdateMember(updatemb);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                Cellclick = false;
             
                loadMember();
            }
            else
            {
                string errortext = Cellclick == false?"ກະລຸນາເລືອກແຖວ":
                    (string.IsNullOrWhiteSpace(textBox1.Text) ||
                      string.IsNullOrWhiteSpace(textBox2.Text) ||
                      string.IsNullOrWhiteSpace(textBox3.Text) ||
                      string.IsNullOrWhiteSpace(textBox4.Text)) ? "ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບ"
                   : !int.TryParse(textBox4.Text, out point) ? "ແຕ້ມຕ້ອງເປັນໂຕເລກ"
                   : "brhu";
                MessageBox.Show(errortext, "ຜິດຜາດ", MessageBoxButtons.OK);
            }
        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
           
            int id;
            if(Cellclick == true&& int.TryParse(mbid, out id))
            {
                Member deletemb = new Member
                {
                    mbId = id
                };
                memberrepo.DeleteMember(deletemb);
                Cellclick = false;
                loadMember();
            }
            else
            {
                MessageBox.Show("ກະລຸນາເລືອກແຖວ", "ຜິດຜາດ", MessageBoxButtons.OK);
            }
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
          
            loadMember();
        }
        private void loadMember()
        {
            dataGridView1.DataSource = memberrepo.GetAllMembers();
        }
        bool Cellclick;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cellclick = true;
            mbid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Member mb = new Member {
                mbPhoneNumber=textBox5.Text
            };
            var data = memberrepo.GetMember(mb);

            dataGridView1.DataSource = new List<Member> { data };
        }
    }
}
