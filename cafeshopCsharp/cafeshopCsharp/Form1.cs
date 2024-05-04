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
      
        private readonly MemberRepository _memberRepository;
        public Form1()
        {
            InitializeComponent();
            _memberRepository = new MemberRepository(new connectionDB().getConnection());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int centerX = (this.Width - panel1.Width) / 2;
            int centerY = (this.Height - panel1.Height) / 2;

            panel1.Location = new Point(centerX, centerY);
            



            Member addMember = new Member {
                mbName = "bou",
                mbPhoneNumber = "58578313",
                mbAddress = "ທ່າແຂກ, ຄຳມ່ວນ",
                mbPoints=0
                
            
            };
            Member updateMember = new Member
            {
                mbId=3,
                mbName = "kittima",
                mbPhoneNumber = "28434443",
                mbAddress = "ທ່າແຂກ, ຄຳມ່ວນ",
                mbPoints = 0


            };

            Member updatePoints = new Member {
                mbPhoneNumber = "28490166",
                mbPoints=10
            };
            Member deleteMember = new Member {
            mbId=1
            };


            //  _memberRepository.AddMember(addMember);
            //

            //  _memberRepository.UpdataMember(updateMember);
            //_memberRepository.UpdatePoints(updatePoints);
            // _memberRepository.DeleteMember(deleteMember);
          //   var members = _memberRepository.GetAllMembers();
         // var members=  _memberRepository.GetMember("28434443");
          //  List<Member> found = new List<Member> { members };

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHomePage hp = new frmHomePage();
            hp.Show();
            this.Hide();
        }
    }
}
