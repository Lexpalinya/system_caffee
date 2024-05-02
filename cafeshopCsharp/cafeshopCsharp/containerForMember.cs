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
    public partial class containerForMember : Form
    {
        public containerForMember()
        {
            InitializeComponent();
        }

        private void containerForMember_Load(object sender, EventArgs e)
        {
            label1.Text = "Search Member";
            searchMember smb =new searchMember();
            
            smb.MdiParent = this; smb.Show();
            smb.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            addmember amb = new addmember();
            amb.MdiParent = this;
            amb.Dock = DockStyle.Fill;
            amb.Show();
            label1.Text = "Add Member";
        }
    }
}
