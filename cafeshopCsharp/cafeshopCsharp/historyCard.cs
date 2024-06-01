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
        public historyCard( Billpreview bill, frmSellHistory form)
        {
            sellhistory = form;
            billrepo = new BillRepository(new connectionDB().getConnection());
            InitializeComponent();
            label1.Text = bill.Date.ToString();
            id = bill.Id;
            label2.Text = bill.Id.ToString();
            label3.Text = bill.Accname;
            label4.Text = bill.Cusname == null ? "ລູກຄ້າທົ່ວໄປ ":bill.Cusname ;
            label5.Text = bill.Point.ToString();
           
            
        }
        private void historyCard_Load(object sender, EventArgs e)
        {

        }

        private void historyCard_Click(object sender, EventArgs e)
        {
            frmShowDetail fsd = new frmShowDetail(id);
            fsd.Show();
        }
    }
}
