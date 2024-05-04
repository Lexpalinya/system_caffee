using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeshopCsharp
{
    public partial class frmProductAdding : Form
    {



        public frmProductAdding()
        {
            InitializeComponent();
        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                string fileName = fileDialog.FileName;

                try {

                    Image image = Image.FromFile(fileName);
                    pbImage.Image = image;

                }

                catch (Exception ex) {
                    MessageBox.Show("Error loading Image:"+ex.Message);
                }

            }
        }



     
    }
}
