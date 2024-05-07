using cafeshopCsharp.connection_DB;
using cafeshopCsharp.modle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeshopCsharp
{
    public partial class frmSellManage : Form
    {
          //  string[] data = {"amazon","late","green tea","milk","milk tea", "cake" ,"back coffee"};
            

        private readonly  ProductRepository _productRepository;
        List<Product> data;

        public frmSellManage()
        {
            InitializeComponent();
            _productRepository = new ProductRepository(new connectionDB().getConnection());


            data = (List<Product>)_productRepository.GetAllProducts();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void createGrid(Product[] datas)
        {

            clearPanel(mainPanel);
            int y = 150;
            int x = 30;

            if (datas == null) return;
            foreach (var i in Enumerable.Range(0, datas.Length))

            {
               

                sellManageCard card = new sellManageCard(datas[i],this)
                {
                    Location = new Point(x, (i + 1) * (y + 10) - y + 10)
                };
                mainPanel.Controls.Add(card);

            }
            mainPanel.AutoScroll = true;
            mainPanel.VerticalScroll.Enabled=true;
            mainPanel.VerticalScroll.Visible = true;

        }


        private void clearPanel(Panel panel) {
            panel.Controls.Clear();
        
        }
        //---------------------------------------------------------------------------------------------
        private void sellManage_Load(object sender, EventArgs e)
        {
            reLoad();  
        }
        private void reLoad() {

            createGrid(data.ToArray());

        }
        public void reLoadData(List<Product> products) {

            data = products;
            createGrid(data.ToArray());       
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var filteredProducts = new List<Product>();

            int status = checkBox1.Checked == true ? 1 : 0;
            filteredProducts = data.Where(item => item.PStatus ==status).ToList();
            
          

            createGrid(filteredProducts.ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            List<Product> isshow = data.Where(items => items.PType== comboBox1.Text).ToList();
            createGrid(isshow.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createGrid(data.ToArray());
        }
    }


  

}
