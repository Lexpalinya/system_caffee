using cafeshopCsharp.connection_DB;
using cafeshopCsharp.modle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace cafeshopCsharp
{
    public partial class frmSell : Form
    {
        private readonly ProductRepository _productRepository;
        private readonly BillRepository _billRepository;
        private readonly BillDetailRepository _billDetailRepository;
        private readonly MemberRepository _memberRepository;
        AccountView accountView;
        string size, pid="0", price;
        int mbId = 0, mbpoint = 0, amount = 0;

        List<Product> data;

        public frmSell()
        {
            InitializeComponent();
            // Initialize repositories in constructor
            var connection = new connectionDB().getConnection();
            _productRepository = new ProductRepository(connection);
            _billRepository = new BillRepository(connection);
            _billDetailRepository = new BillDetailRepository(connection);
            _memberRepository = new MemberRepository(connection);
        }

        public frmSell(AccountView account) : this() // Call the default constructor
        {
            InitializeAccount(account);
        }

        private void InitializeAccount(AccountView account)
        {
            if (account != null)
            {
                accountView = account;
                lblusername.Text = $"ບັນຊີ: {account.AccUserName}";
                lblAccNameLastName.Text = $" ຜູ້ຂາຍ: {account.empName} {account.empLastName}";
            }
        }

        private void reloadData()
        {
            data = (List<Product>)_productRepository.GetProductByStatusAmount();
            foreach (var item in data)
            {
                if (item.PAmount <= 0)
                {
                
                    _productRepository.UpdateStatus();
                }
            }
            data = (List<Product>)_productRepository.GetProductByStatus();
            createCard(data.ToArray());
        }

        private void Sell_Load(object sender, EventArgs e)
        {
            reloadData();
        }

        private void createCard(Product[] products)
        {
            pnMain.Controls.Clear();
            int x = 10, y = 10;
            int cardSizeX = 280, cardSizeY = 270;

            foreach (var i in Enumerable.Range(0, products.Length))
            {
                int col = i % 4;
                int rowthis = i / 4;

                ProductCards cards = new ProductCards(products[i], this)
                {
                    Location = new Point(x + col * cardSizeX, y + cardSizeY * rowthis)
                };

                pnMain.Controls.Add(cards);
            }

            pnMain.AutoScroll = true;
            pnMain.VerticalScroll.Enabled = true;
            pnMain.VerticalScroll.Visible = true;
        }

        public void createPanelSize(Product product)
        {
            string[] prices = product.PPrice.Split(',');
            string[] sizes = product.PSize.Split(',');
            Button selectedButton = null;

            pnSize.Controls.Clear();
            int X = 15, Y = 10;
            int columnWidth = 100, rowHeight = 50;

            foreach (var i in Enumerable.Range(0, sizes.Length))
            {
                int col = i % 2;
                int row = i / 2;

                Button button = new Button
                {
                    Text = sizes[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(94, 40),
                    Font = new Font("Times New Roman", 16, FontStyle.Bold),
                    Location = new Point(X + col * columnWidth, Y + row * rowHeight),
                    BackColor = Color.Green,
                    ForeColor = Color.Gold,
                };

                pid = product.PId.ToString();
                price = prices[i].ToString();
                amount = product.PAmount;





                button.Click += (sender, e) =>
                {
                    size = sizes[i];
                    foreach (var control in pnSize.Controls)
                    {
                        if (control is Button btn)
                        {
                            btn.BackColor = Color.Green;
                            btn.ForeColor = Color.Gold;
                        }
                    }
                    button.ForeColor = Color.Gold;
                    button.BackColor = Color.Black;
                    lblPrice.Text = prices[i];
                    txtTotal.Text = (int.Parse(prices[i]) * nmAmount.Value).ToString();
                };

                if (i == 0)
                {
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

        public void seleteProductSetText(Product product)
        {
            try
            {
                lblname.Text = product.PName;
                lblType.Text = product.PType;
                createPanelSize(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nmAmount_ValueChanged(object sender, EventArgs e)
        {
            if (lblPrice.Text == "") return;
            int total = (int)(nmAmount.Value * int.Parse(lblPrice.Text));
            txtTotal.Text = total.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchByType("Hot");
        }

        private void searchByType(string findType)
        {
            var find = data.Where(item => item.PType == findType);
            createCard(find.ToArray());
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

        private void button9_Click(object sender, EventArgs e)
        {
            ResetUI();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            ResetUI();
        }

        private void Addbilldetail(ListView list, int billId)
        {
            foreach (ListViewItem item in list.Items)
            {
                BillDetail billDetail = new BillDetail
                {
                    BdblId = billId,
                    BdPId = int.Parse(item.SubItems[0].Text),
                    BdSize = item.SubItems[3].Text,
                    BdPrice = int.Parse(item.SubItems[4].Text),
                    BdAmount = int.Parse(item.SubItems[5].Text),
                    BdTotal = int.Parse(item.SubItems[6].Text) 
                };


                Product product = new Product
                {
                    PId = int.Parse(item.SubItems[0].Text),
                    PAmount = int.Parse(item.SubItems[5].Text)
                };
                _productRepository.UpdateAmount(product);
                _billDetailRepository.AddBillDetail(billDetail);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listView1.Items.Count == 0) return;

                Bill addbill = new Bill
                {
                    BlAccId = accountView.AccId,
                    BlDate = DateTime.Now,
                    BlTotalMoney = double.Parse(lblAllprice.Text),
                    BlPoint = (int)int.Parse(lblAllprice.Text) / 1000
                };

                int billId;
                if (mbId != 0)
                {
                    addbill.BlMbId = mbId;
                    billId = _billRepository.AddBill(addbill);
                    _memberRepository.UpdatePoints(mbId, addbill.BlPoint);
                }
                else
                {
                    billId = _billRepository.AddBillNoMember(addbill);
                }

                Addbilldetail(listView1, billId);

                ResetUI();
                MessageBox.Show("ຂາຍສຳເລັດແລ້ວ");
                reloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmSearchMember frm = new frmSearchMember(this);
            frm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var search = data.Where(item => item.PName.ToLower().Contains(txtSearch.Text.ToLower()));
            createCard(search.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pid == "0") {
                MessageBox.Show("ກະລຸນາເລືອກສີນຄ້າ");   
            return;
            }

            int checkAmount = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text == pid)
                {
                    checkAmount += int.Parse(item.SubItems[5].Text);
                }
            }

            int currentStockAmount = amount;
            int requestedAmount = (int)nmAmount.Value;
            if (currentStockAmount < requestedAmount + checkAmount)
            {
                MessageBox.Show("ຈຳນວນບໍ່ພໍ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var order = new string[] { pid, lblname.Text, lblType.Text, size, price, nmAmount.Value.ToString(), txtTotal.Text };
            double allprice = 0;
            bool orderExists = false;

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text == pid && item.SubItems[3].Text == size)
                {
                    int existingAmount = int.Parse(item.SubItems[5].Text);
                    int newAmount = existingAmount + requestedAmount;
                    int newTotal = newAmount * int.Parse(price);

                    item.SubItems[5].Text = newAmount.ToString();
                    item.SubItems[6].Text = newTotal.ToString();
                    orderExists = true;
                }

                allprice += double.Parse(item.SubItems[6].Text);
            }

            if (!orderExists)
            {
                var newOrder = new ListViewItem(order);
                listView1.Items.Add(newOrder);
                allprice += double.Parse(txtTotal.Text);
            }

            lblAllprice.Text = allprice.ToString();
           

            
        }




        private void button9_Click_2(object sender, EventArgs e)
        {
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }



        private void ResetUI()
        {
            listView1.Items.Clear();
            lblAllprice.Text = "0";
            mbId = 0;
            mbpoint = 0;
            btnmember.BackColor = Color.White;
            pid = "0";
            lblPrice.Text = "";
            lblname.Text = "";
            lblType.Text = "";
            nmAmount.Value = 1;
            txtTotal.Text = "0.0";
            pnSize.Controls.Clear();
        }
        public void member(Member memberData)
        {
            if (memberData != null)
            {
                mbId = memberData.mbId;
                mbpoint = memberData.mbPoints;
                btnmember.BackColor = Color.Green; // Assuming btnmember is a Button control indicating membership status
                                                   // You can add other logic to handle member data as needed
            }
            else
            {
                // Handle the case where memberData is null, if necessary
            }
        }
    }
}
