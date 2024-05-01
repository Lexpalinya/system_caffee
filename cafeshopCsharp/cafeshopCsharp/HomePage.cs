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
    public partial class HomePage : Form
    {

       
        public HomePage()
        {
            InitializeComponent();
            panel11.Visible = false;
        
          
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnMain.Visible = false;
            panel11.Visible = true;
            if (pnMain.Dock == DockStyle.None) {
                pnMain.Dock = DockStyle.Left;
            }
        }

        private void panel8_Click(object sender, EventArgs e)
        {
         
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pnMain.Visible = true;
            panel11.Visible = false;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Sell sell = new Sell();
            sell.MdiParent = this;
            sell.Show();
            sell.Dock = DockStyle.Fill;
            
  
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pnMain.Visible = true;
        }

        private void pnMain_VisibleChanged(object sender, EventArgs e)
        {
            int placelogoutBTY = this.Height - 100;
            panel10.Location = new Point(12,placelogoutBTY);
        }
    }
}
