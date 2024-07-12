using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cafeshopCsharp.modle;
using cafeshopCsharp.connection_DB;

namespace cafeshopCsharp
{
    public partial class frmSellHistory : Form
    {
        private readonly BillRepository _billrepo;
        private List<Billpreview> data;
        private string role;
        private int accId;
        private int count;
        private int limit = 50;

        public frmSellHistory(string role, int accId)
        {
            this.role = role;
            this.accId = accId;
            _billrepo = new BillRepository(new connectionDB().getConnection());
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
            LoadData();
        }

        private void LoadData()
        {
            // Load initial data and count
            data = _billrepo.GetBillsByDate(role, accId, DateTime.Today, 1).ToList();
            count = _billrepo.GetCountPage(role, accId, DateTime.Today);

            // Setup initial UI
            lblcount.Text = $"ຂາຍໄດ້ : {count} ລາຍການ ໃນວັນທີ່";
            int totalPages = (int)Math.Ceiling((double)count / limit);
            lblpage.Text = $"1/{totalPages}";

            // Create initial grid
            createGrid(data.ToArray());
        }

        private void createGrid(Billpreview[] datas)
        {
            panel1.Controls.Clear();
            int x = 10, y = 10;
            int cardSizeX = 205, cardSizeY = 165;

            if (datas.Length == 0)
            {
                Label label = new Label
                {
                    Size = new Size(200, 100),
                    Text = "ບໍ່ພົບລາຍການ",
                    Font = new Font("Phetsarath OT", 18, FontStyle.Bold),
                    Location = new Point(panel1.Width / 2 - 100, panel1.Height / 2)
                };
                panel1.Controls.Add(label);
                return;
            }

            foreach (var i in Enumerable.Range(0, datas.Length))
            {
                int col = i % 5;
                int row = i / 5;
                historyCard card = new historyCard(datas[i], this)
                {
                    Location = new Point(x + cardSizeX * col, y + cardSizeY * row)
                };
                panel1.Controls.Add(card);
            }

            panel1.AutoScroll = true;
            panel1.VerticalScroll.Enabled = true;
            panel1.VerticalScroll.Visible = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadDataForDate(dateTimePicker1.Value, 1);
        }
        private void sellHistory_Load(object sender, EventArgs e)
        { }

            private void LoadDataForDate(DateTime date, int page)
        {
            data = _billrepo.GetBillsByDate(role, accId, date, page).ToList();
            createGrid(data.ToArray());
            count = _billrepo.GetCountPage(role, accId, date);
            lblcount.Text = $"ຂາຍໄດ້ : {count} ລາຍການ ໃນວັນທີ່";
            int totalPages = (int)Math.Ceiling((double)count / limit);
            lblpage.Text = $"{page}/{totalPages}";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int currentPage = int.Parse(lblpage.Text.Split('/')[0]);
            int nextPage = currentPage + 1;
            if (nextPage > count) return;

            lblpage.Text = $"{nextPage}/{count}";
            LoadDataForDate(dateTimePicker1.Value, nextPage);
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label4_Click(object sender, EventArgs e)
        {
            int currentPage = int.Parse(lblpage.Text.Split('/')[0]);
            int prevPage = currentPage - 1;
            if (prevPage < 1) return;

            lblpage.Text = $"{prevPage}/{count}";
            LoadDataForDate(dateTimePicker1.Value, prevPage);
        }
    }
}
