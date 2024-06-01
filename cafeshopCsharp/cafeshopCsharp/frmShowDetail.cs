using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cafeshopCsharp.modle;
using cafeshopCsharp.connection_DB;
namespace cafeshopCsharp
{
    public partial class frmShowDetail : Form
    {
        private readonly BillDetailRepository billrepo;
        int id;
        public frmShowDetail(int id,string date,string seller,string member,string point,string total)
        {
            this.id = id;
            InitializeComponent();
            label6.Text ="BIllID: "+ id.ToString();
            label5.Text = "Date: " + date;
            label1.Text = "Seller: " + seller;
            label3.Text = "Member: " + member;
            label4.Text = "Point: " + point;
            label7.Text = "Total: " + total;
        connectionDB connect = new connectionDB();
        billrepo = new BillDetailRepository(connect.getConnection());
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                this.Close();
            
        }
        IEnumerable<showbilldetail> data;

        private void frmShowDetail_Load(object sender, EventArgs e)
        {
            BillDetail idbdt = new BillDetail
            {
                BdblId = id
            };

            
            data = billrepo.getbillbyid(idbdt);
            PopulateListView();
        }
        private void PopulateListView()
        {
            // Clear existing items if any
            listView1.Items.Clear();

            // Add the fetched data to the ListView
            foreach (var detail in data)
            {
                ListViewItem item = new ListViewItem(detail.name);
                item.SubItems.Add(detail.type);
                item.SubItems.Add(detail.size.ToString());
                item.SubItems.Add(detail.price.ToString());
                item.SubItems.Add(detail.amount.ToString());
                item.SubItems.Add(detail.total.ToString());
                listView1.Items.Add(item);
            }

        }
        
    }
}
