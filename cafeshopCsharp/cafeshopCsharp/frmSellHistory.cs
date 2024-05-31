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

    public partial class frmSellHistory : Form
    {
    private readonly BillRepository _billrepo;
    List<Bill> data;
        public frmSellHistory()
        {
            _billrepo = new BillRepository(new connectionDB().getConnection());
            InitializeComponent();
            data = (List<Bill>)_billrepo.getallbill();
        }

        private void sellHistory_Load(object sender, EventArgs e)
        {
            createGrid(data.ToArray());
        }

        private void createGrid(Bill[] data)
        {

            panel1.Controls.Clear();
            int y = 1000;
            int x = 130;

            if (data == null) return;
            foreach (var i in Enumerable.Range(0, data.Length))

            {


                historyCard card = new historyCard();
                {
                    Location = new Point(x, (i + 1) * (y + 10) - y + 10);
                };
                panel1.Controls.Add(card);

            }
            panel1.AutoScroll = true;
            panel1.VerticalScroll.Enabled = true;
            panel1.VerticalScroll.Visible = true;
            label1.Text = panel1.Controls.Count.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = panel1.Controls.Count.ToString();
        }
    }
}
