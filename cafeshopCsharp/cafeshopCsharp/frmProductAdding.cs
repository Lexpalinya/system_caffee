using cafeshopCsharp.connection_DB;
using cafeshopCsharp.modle;
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
        private List<Product> data;
        private readonly ProductRepository _productRepository;
        int id;
        public frmProductAdding()
        {
            InitializeComponent();
            _productRepository = new ProductRepository(new connectionDB().getConnection());
            reload();
        
        }

        //function reload ------------------------------------------------------------------------
        private void reload() {
            data = (List<Product>)_productRepository.GetAllProducts();
            dataGridView1.DataSource = data;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            clearTextBox();
        }

        // clear textbox -------------------------------------------------------------------------
        private void clearTextBox() {
            txtname.Clear();
            txtAmount.Clear();
            txtExp.Clear();
            txtOP.Clear();
            txtprice.Clear();
            cmbSize.Text = "----ກະລຸນາເລືອກຂະໜາດ----";
            cmbType.Text = "---- ກະລຸນາເລືອກປະເພດ----";
            comboBox1.Text = "---- ປະເພດ----";
            pbImage.Image = null;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        // check textbox is null and space ----------------------------------------------------------------
        private bool checkTexbox() {

            return string.IsNullOrWhiteSpace(txtname.Text) || string.IsNullOrWhiteSpace(txtAmount.Text) || string.IsNullOrWhiteSpace(txtExp.Text) || string.IsNullOrWhiteSpace(txtOP.Text) || string.IsNullOrWhiteSpace(txtprice.Text) || cmbSize.Text == "----ກະລຸນາເລືອກຂະໜາດ----" || cmbType.Text == "---- ກະລຸນາເລືອກປະເພດ----";


        }


        // check length size Price ------------------------------------------------------------------------------
        private bool CheckLengthSizePrice() {
            return cmbSize.Text.Split(',').Length != txtprice.Text.Split(',').Length;
        }

        // btn add ----------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckLengthSizePrice()) {
                MessageBox.Show("ກະລຸນາປ້ອນຈຳນວນເງິນໃຫ້ເທົ່າກັນຂະໜາດຂອງ Size", "ເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtprice.Focus();
                return;
            }
            
            if (checkTexbox()) {
                MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົນຖ້ວນ", "ເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            byte[] img = new ConvertByteToImage().ImageToByteArray(pbImage.Image);
            Product addProduct = new Product {
                PName = txtname.Text,
                PAmount = int.Parse(txtAmount.Text),
                PExp = txtExp.Text,
                PPrice = txtprice.Text,
                PPriceOriginal = int.Parse(txtOP.Text),
                PSize = cmbSize.Text,
                PType = cmbType.Text,
                PStatus = checkBox1.Checked ? 1 : 0,
                PImage=img        
            };
            _productRepository.AddProduct(addProduct);
            reload();

        }

        // set textbox for input number only --------------------------------------------------------------------
        private void txtOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ) {

                e.Handled = true;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
            }
        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)&& e.KeyChar!=',')
            {

                e.Handled = true;
            }
        }
        // btn reloadData------------------------------------------------------------------------------
        private void button5_Click(object sender, EventArgs e)
        {
            reload();
        }

        // get data from datagridview to textbox for update and delete ----------------------------------------
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString());
                    txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString();
                    cmbType.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();
                    cmbSize.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString();
                    txtprice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value?.ToString();
                    txtAmount.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value?.ToString();
                    checkBox1.Checked = dataGridView1.Rows[e.RowIndex].Cells[6].Value?.ToString() == "1";
                    txtOP.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value?.ToString();
                    txtExp.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value?.ToString();
                    byte[] img = dataGridView1.Rows[e.RowIndex].Cells[9].Value as byte[];
                    pbImage.Image = img != null ? new ConvertByteToImage().ByteToImage(img) : null;
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in dataGridView1_CellClick: " + ex.Message);
                // You may display a message box or log the error to a file here
            }
        }
        //btn update--------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {

            if (CheckLengthSizePrice())
            {
                MessageBox.Show("ກະລຸນາປ້ອນຈຳນວນເງິນໃຫ້ເທົ່າກັນຂະໜາດຂອງ Size", "ເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtprice.Focus();
                return;
            }
            if (checkTexbox())
            {
                MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົນຖ້ວນ", "ເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convert image to byte array only if PictureBox has an image
            byte[] img = pbImage.Image != null ? new ConvertByteToImage().ImageToByteArray(pbImage.Image) : null;

            Product updateProduct = new Product
            {
                PId = id,
                PName = txtname.Text,
                PAmount = int.Parse(txtAmount.Text),
                PExp = txtExp.Text,
                PPrice = txtprice.Text,
                PPriceOriginal = int.Parse(txtOP.Text),
                PSize = cmbSize.Text,
                PType = cmbType.Text,
                PStatus = checkBox1.Checked ? 1 : 0,
              
            };
            if (img != null) {
                updateProduct.PImage = img;
            }
            _productRepository.UpdateProduct(updateProduct);
            reload();
        }

        //btn delele -------------------------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            Product deleteProduct = new Product {
                PId = id
            };
            _productRepository.DeteleProduct(deleteProduct);
            reload();
        }

        // serach --------------------------------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            var search = data.Where<Product>(items => items.PName.ToLower().Contains(txtSearch.Text.ToLower()));
            dataGridView1.DataSource = search.ToArray<Product>();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var search = data.Where<Product>(items => items.PType==comboBox1.Text);
            dataGridView1.DataSource = search.ToArray<Product>();
        }
        //--------------------------------------------------------------------------------------------
        private void pbImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && pbImage.Image!=null) {
                frmFullImage frmFullImage = new frmFullImage(pbImage.Image);
                
                frmFullImage.ShowDialog();
            }
        }
        //------------------------------------------------------------------------------------------------
        private void pbImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = fileDialog.FileName;

                try
                {

                    Image image = Image.FromFile(fileName);
                    pbImage.Image = image;

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Image:" + ex.Message);
                }

            }
        }
    }
}
