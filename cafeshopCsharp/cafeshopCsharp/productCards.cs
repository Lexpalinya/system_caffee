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
    public partial class ProductCards : UserControl
    {
        // Define event for entire product card click
        public event EventHandler ProductCardClicked;
        public frmSell _frmSell;
        public Product product1;

        public ProductCards(Product product, frmSell frmSell)
        {
            _frmSell = frmSell;
            product1 = product;
            InitializeComponent();
            pictureBox1.Image = new ConvertByteToImage().ByteToImage(product.PImage);
            lbName.Text = product.PName;
            lbPrice.Text = product.PType;

            // Wire up click event for the entire product card
            this.Click += ProductCards_Click;
        }

        private void ProductCards_Click(object sender, EventArgs e)
        {
            _frmSell.seleteProductSetText(product1);
        }

        private void ProductCards_Load(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            _frmSell.seleteProductSetText(product1);
        }
    }



}
