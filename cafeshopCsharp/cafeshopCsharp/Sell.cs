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
    public partial class Sell : Form
    {
        public Sell()
        {
            InitializeComponent();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        
        private string sizeselected;
        private void label9_Click(object sender, EventArgs e)
        {
            sizeselected = "S";
            lbsize.Text = sizeselected;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            sizeselected = "M";
            lbsize.Text = sizeselected;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            sizeselected = "L";
            lbsize.Text = sizeselected;
        }

        private void Sell_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchMember smb = new searchMember();
            smb.Show();

        }
    }
}
