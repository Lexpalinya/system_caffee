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
    public partial class sellManageCard : UserControl

    {
        private readonly ProductRepository _productRepository;
        private frmSellManage _frmSellManage;

        int PId = 0;
        public sellManageCard()
        {
            InitializeComponent();


           
        }
        public sellManageCard(Product product,frmSellManage frmSellManage) {
            _frmSellManage = frmSellManage;
            _productRepository = new ProductRepository(new connectionDB().getConnection());
            InitializeComponent();
            string[] sizes =product.PSize.Split(',');
            createPanelSize(sizes);
            lblName.Text = product.PName;
            pictureBox1.Image =new ConvertByteToImage().ByteToImage(product.PImage);
            lblType.Text = product.PType;
            txtAmount.Text = product.PAmount.ToString();
            PId = product.PId;

            if (product.PStatus == 1)
            {

                BackColor = Color.DarkGreen;
            }
            else {

                BackColor = Color.DarkRed;
            }
        }

  

        public void createPanelSize(string [] sizes) {

          
            int Y = 10;
            int X = 10;
            int columnWidth = 50;
            foreach (var index in Enumerable.Range(0, sizes.Length))
            {

                int column = index % 2;
                int rowthis = index / 2;
                Label labelSize = new Label
                {
                    Text = sizes[index],
                    AutoSize = true,
                    Location = new Point(X + column * columnWidth, Y + rowthis * 30),
                    Font = new Font("Phetsarath OT", 16, FontStyle.Bold),
                    ForeColor=Color.Gold
                };


                // Size ------------------
                panelSize.Controls.Add(labelSize);


            };

        }



        private void UserControl1_Load(object sender, EventArgs e)
        {
           
        }

       

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            
            }
        }

        

        private void btnUp_Click(object sender, EventArgs e)
        {
            int amount = 0;
            if (!string.IsNullOrEmpty(txtAmount.Text) && int.TryParse(txtAmount.Text, out int currentAmount))
            {

                amount = currentAmount;
            }
                amount++;
                txtAmount .Text= amount.ToString();
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            int amount = 0;
            if (!string.IsNullOrEmpty(txtAmount.Text) && int.TryParse(txtAmount.Text, out int currentAmount))
            {

                amount = currentAmount;
            }
            if (amount > 0)  amount--;

            txtAmount.Text = amount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product update = new Product
            {
                PId = PId,
                PAmount = int.Parse(txtAmount.Text),
                PStatus = 1

            };
            _productRepository.UpdateStatusAndAmount(update);
            List<Product> updateData= (List<Product>)_productRepository.GetAllProducts();
            _frmSellManage.reLoadData(updateData);
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product update = new Product
            {
                PId = PId,
                PAmount = int.Parse(txtAmount.Text),
                PStatus = 0

            };
            _productRepository.UpdateStatusAndAmount(update);
            List<Product> updateData = (List<Product>)_productRepository.GetAllProducts();
            _frmSellManage.reLoadData(updateData);
        }
    }
}
