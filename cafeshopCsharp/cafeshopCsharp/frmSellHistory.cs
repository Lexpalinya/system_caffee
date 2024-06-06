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
        int count;
        int limit = 50;
        public frmSellHistory(string role,int accId)
        {
            this.role = role;
            this.accId = accId;
            _billrepo = new BillRepository(new connectionDB().getConnection());
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
            data = (List<Billpreview>)_billrepo.GetBillsByDate(role,accId,DateTime.Today, int.Parse(lblpage.Text.Split('/')[0])).ToList();
            count =_billrepo.GetCountPage(role, accId,DateTime.Today);

        }

        private void sellHistory_Load(object sender, EventArgs e)
        {
           
            lblcount.Text = "ຂາຍໄດ້ : " + count.ToString()+ " ລາຍການ ໃນວັນທີ່";
            count = (int)count /limit + 1;
            lblpage.Text = "1/" +count.ToString();
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
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var search = (List<Billpreview>)_billrepo.GetBillsByDate(role, accId,dateTimePicker1.Value,1).ToList();
            createGrid(search.ToArray<Billpreview>());
            count =_billrepo.GetCountPage(role, accId, dateTimePicker1.Value);
            lblcount.Text = "ຂາຍໄດ້ : " + count.ToString() + " ລາຍການ ໃນວັນທີ່";
            count =(int) count / limit + 1;

            lblpage.Text = "1/" + count.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int value = int.Parse(lblpage.Text.Split('/')[0])+1;
            if (value > count) return;
            lblpage.Text = value.ToString() + "/" + count;
            var search = (List<Billpreview>)_billrepo.GetBillsByDate(role, accId, dateTimePicker1.Value.Date,value).ToList();

            createGrid(search.ToArray<Billpreview>());


        }

        private void label4_Click(object sender, EventArgs e)
        {
            int value = int.Parse(lblpage.Text.Split('/')[0]) - 1;
            if (value< 1)
            {
                return;
            }
            lblpage.Text = value.ToString()+"/"+count;
            var search = (List<Billpreview>)_billrepo.GetBillsByDate(role, accId, dateTimePicker1.Value.Date, value).ToList();

            createGrid(search.ToArray<Billpreview>());
        }
    }
}
