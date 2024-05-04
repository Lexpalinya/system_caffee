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
    public partial class frmHomePage : Form
    {

       
        public frmHomePage()
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
            
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            frmReport selmn = new frmReport();
            setmdi(selmn);
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
            frmSell sell = new frmSell();
            setmdi(sell);
            
  
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

        private void label5_Click(object sender, EventArgs e)
        {
            frmEmployee selmn = new frmEmployee();
            setmdi(selmn);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmMember member = new frmMember();
            setmdi(member);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            frmPaidrecord paidrecord = new frmPaidrecord();
            setmdi(paidrecord);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            frmSellManage selmn = new frmSellManage();
            setmdi(selmn);
            
        }
        public void setmdi(Form form)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close(); 
            }
            pnMain.Visible = false;
            panel11.Visible = true;
            form.MdiParent = this;
            form.Show();
            form.Dock = DockStyle.Fill;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            frmProductAdding selmn = new frmProductAdding();
            setmdi(selmn);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            frmSellHistory selmn = new frmSellHistory();
            setmdi(selmn);
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            frmMember selmn = new frmMember();
            setmdi(selmn);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            frmEmployee selmn = new frmEmployee();
            setmdi(selmn);
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            frmSeller selmn = new frmSeller();
            setmdi(selmn);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            frmSalaryPayment salaryPayment = new frmSalaryPayment();
            setmdi(salaryPayment);
        }
    }
}
