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
    public partial class frmSell : Form
    {

        private readonly ProductRepository _productRepository;
        
        string size, pid,price;
        


        List<Product> data;
        public frmSell()
        {

            _productRepository = new ProductRepository(new connectionDB().getConnection());
            InitializeComponent();
      

        }
     
        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void reloadData() {
            data = (List<Product>)_productRepository.GetProductByStatus();
            createCard(data.ToArray<Product>());
        }

        private void Sell_Load(object sender, EventArgs e)
        {

            reloadData();
           
        }
        private void createCard(Product[] product) {
            pnMain.Controls.Clear();
            int x = 10,y=10;           
            int cardSizeX = 280, cardSizeY = 270;
            foreach (var i in Enumerable.Range(0, product.Length)) {
                int col = i % 4;
                int rowthis = i / 4;

                ProductCards cards = new ProductCards(product[i],this)
                {
                    Location = new Point(x+col*cardSizeX,y+cardSizeY*rowthis)
                };



                pnMain.Controls.Add(cards);
            }
            pnMain.AutoScroll = true;
            pnMain.VerticalScroll.Enabled = true;
            pnMain.VerticalScroll.Visible = true;

        }

        public void createPanelSize(Product product)
        {
            string[] prices = product.PPrice.Split(',').ToArray();
            string[] sizes = product.PSize.Split(',').ToArray();
            Button selectedButton = null;


            pnSize.Controls.Clear();

            int X = 15, Y = 10;
            int columnWidth = 100,rowHight=50;
            foreach (int i in Enumerable.Range(0,sizes.Length)) {

                int col = i % 2;
                int row = i / 2;

                Button button = new Button {
                    Text = sizes[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(94, 40),
                    Font = new Font("Times new roman", 16, FontStyle.Bold),
                    Location = new Point(X + col * columnWidth, Y + row * rowHight)
                    ,BackColor=Color.Green,
                    ForeColor=Color.Gold,

                };
                
                pid = product.PId.ToString();
                price =prices[i].ToString();
                
                button.Click += (sender, e) =>
                {
                    size = sizes[i];
                    foreach (var control in pnSize.Controls) {
                        if (control is Button btn) {
                            btn.BackColor = Color.Green;
                            btn.ForeColor = Color.Gold;
                        }
                    
                    }
                    button.ForeColor = Color.Gold;
                    button.BackColor = Color.Black;
                    lblPrice.Text = prices[i];
                  
                    txtTotal.Text = (int.Parse(prices[i]) * nmAmount.Value).ToString();

                };
                if (i == 0) {
                    selectedButton = button;
                    lblPrice.Text = prices[i];

                    txtTotal.Text = (int.Parse(prices[i]) * nmAmount.Value).ToString();


                }

                pnSize.Controls.Add(button);
            }

            selectedButton?.PerformClick();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            frmSearchMember sm = new frmSearchMember();
            sm.Show();
        }

      
        public void seleteProductSetText(Product product) {
            try
            {

                lblname.Text = product.PName;
                lblType.Text = product.PType;

               
               createPanelSize(product);

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

            

        }

        private void nmAmount_ValueChanged(object sender, EventArgs e)
        {
            int total = (int)(nmAmount.Value * int.Parse(lblPrice.Text));
            txtTotal.Text = total.ToString() ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchByType("Hot");   
        }

        private void searchByType(String findType) {

            var find = data.Where<Product>(item=>item.PType==findType);
            createCard(find.ToArray<Product>());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchByType("Cool");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            searchByType("Mix");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            searchByType("Other");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            reloadData();
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            lblAllprice.Text = "0";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var search = data.Where<Product>(item => item.PName.ToLower().Contains(txtSearch.Text.ToLower()));
            createCard(search.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var order = new string[] { pid, lblname.Text, lblType.Text, size, price, nmAmount.Value.ToString(), txtTotal.Text };
            double allprice = 0;
            bool orderExists = false;


            foreach (ListViewItem item in listView1.Items) {
                if (item.SubItems[0].Text==pid&& item.SubItems[3].Text==size) {
                    int existingAmount = int.Parse(item.SubItems[5].Text);
                    int newAmount = existingAmount + int.Parse(nmAmount.Value.ToString());
                    int newTotal = newAmount * int.Parse(price);


                    item.SubItems[5].Text = newAmount.ToString();
                    item.SubItems[6].Text = newTotal.ToString();
                    orderExists = true;
                }

                allprice += double.Parse(item.SubItems[6].Text);
            }
            if (!orderExists) {

                var newOrder = new ListViewItem(order);
                listView1.Items.Add(newOrder);
                allprice += double.Parse(txtTotal.Text);
            }
            lblAllprice.Text = allprice.ToString();
        }
      
    }
}
