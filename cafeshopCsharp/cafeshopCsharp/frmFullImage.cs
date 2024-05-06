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
    public partial class frmFullImage : Form
    {
        public frmFullImage()
        {
            InitializeComponent();
        }
        public frmFullImage(Image image) {
            InitializeComponent();
            pictureBox1.Image=image;
        }
        private void frmFullImage_Load(object sender, EventArgs e)
        {

        }
    }
}
