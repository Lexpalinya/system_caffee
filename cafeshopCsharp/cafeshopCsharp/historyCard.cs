using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cafeshopCsharp.connection_DB;
using cafeshopCsharp.modle;

namespace cafeshopCsharp
{
    public partial class historyCard : UserControl
    {
        private readonly BillRepository billrepo;
        private frmSellHistory sellhistory;
        public historyCard()
        {
            InitializeComponent();
        }

        int id;
        string date;
        string seller;
        string member;
        string point;
        string total;
        public historyCard( Billpreview bill, frmSellHistory form)
        {
            sellhistory = form;
            billrepo = new BillRepository(new connectionDB().getConnection());
            InitializeComponent();
            label1.Text = "Date: "+bill.Date.ToString();
            label2.Text = "BillID: " + bill.Id.ToString();
            label3.Text = "Cashier: " + bill.Accname;
            label4.Text = "Customer: " + bill.Cusname == null ? "ລູກຄ້າທົ່ວໄປ ":bill.Cusname ;
            label5.Text = "Point: " + bill.Point.ToString();

            id = bill.Id;
            date = bill.Date.ToString();
            seller = bill.Accname;
            member = bill.Cusname == null ? "ລູກຄ້າທົ່ວໄປ " : bill.Cusname;
            point = bill.Point.ToString();
            total = billrepo.GetTotalPriceByBillId(id).ToString();
            label6.Text = billrepo.GetTotalPriceByBillId(id).ToString();
        }
        private void historyCard_Load(object sender, EventArgs e)
        {

        }

        private void historyCard_Click(object sender, EventArgs e)
        {
            frmShowDetail fsd = new frmShowDetail(id,date,seller,member,point,total);
            fsd.Show();
        }
    }
}
