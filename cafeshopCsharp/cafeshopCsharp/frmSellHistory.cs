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
        string role;
        int accId;
        public frmSellHistory(string role,int accId)
        {
            this.role = role;
            this.accId = accId;
            _billrepo = new BillRepository(new connectionDB().getConnection());
            InitializeComponent();
           
            data = (List<Billpreview>)_billrepo.GetBillsByDate(role,accId,DateTime.Today);


        }

        private void sellHistory_Load(object sender, EventArgs e)
        {
            createGrid(data.ToArray());
        }

        private void createGrid(Billpreview[] datas)
        {

            panel1.Controls.Clear();
            int x = 10, y = 10;
            int cardSizeX = 205, cardSizeY = 165;
            if (datas.Length==0) {
                Label label = new Label() {
                    Size=new Size(200,100),
                    Text = "ບໍ່ພົບລາຍການ",
                    Font = new Font("Phetsarath OT", 18, FontStyle.Bold),
                    Location = new Point(panel1.Width / 2-100, panel1.Height/2) 
                } ;

                panel1.Controls.Add(label);
                
                return; }
            foreach (var i in Enumerable.Range(0, datas.Length))
            {
                int col = i % 5;
                int rowthis = i / 5;
                historyCard card = new historyCard(datas[i], this)
                {
                    Location = new Point(x + cardSizeX*col, y + (cardSizeY * rowthis))
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var search = (List<Billpreview>)_billrepo.GetBillsByDate(role, accId,dateTimePicker1.Value.Date);
            createGrid(search.ToArray<Billpreview>());
        }
    }
}
