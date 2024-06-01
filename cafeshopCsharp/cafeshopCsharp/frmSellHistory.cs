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
    List<Billpreview> data;
        public frmSellHistory()
        {
            _billrepo = new BillRepository(new connectionDB().getConnection());
            InitializeComponent();
            data = (List<Billpreview>)_billrepo.GetAllBill();
            
            

        }

        private void sellHistory_Load(object sender, EventArgs e)
        {
            createGrid(data.ToArray());
        }

        private void createGrid(Billpreview[] datas)
        {

            panel1.Controls.Clear();
            int x = 10, y = 10;
            int cardSizeX = 1, cardSizeY = 200;

            //  if (data == null) return;
            foreach (var i in Enumerable.Range(0, datas.Length))
            {
                historyCard card = new historyCard(datas[i], this)
                {
                    Location = new Point(x + cardSizeX, y + (cardSizeY * i))
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
