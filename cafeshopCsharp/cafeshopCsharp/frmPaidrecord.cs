using cafeshopCsharp.connection_DB;
using cafeshopCsharp.modle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeshopCsharp
{
    public partial class frmPaidrecord : Form
    {

        private readonly PaidRecordRepository _paidrecordRepository;
        List<PaidRecord> data;
        int id;

        public frmPaidrecord()
        {
            InitializeComponent();
            _paidrecordRepository = new PaidRecordRepository(new connectionDB().getConnection());
            reloadData();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (var ac in data) {
                auto.Add(ac.PrText);
            
            }
            textBox6.AutoCompleteCustomSource = auto;
            textBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void frmPaidrecord_Load(object sender, EventArgs e)
        {

        }
        private void reloadData() {

            data= (List<PaidRecord>)_paidrecordRepository.GetAllPaidRecord();
            dataGridView1.DataSource = data;
            clearData();
        }

        private void clearData() {

            txtamount.Text="1";
            txtName.Clear();
            txtprice.Text = "1";
            txtTotal.Text = "0";
            dateTimePicker1.Value =DateTime.Today;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)|| string.IsNullOrWhiteSpace(txtTotal.Text)) {

                MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົນຖ້ວນ","ເຕືອນ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            
            }
            PaidRecord addPaidRecord = new PaidRecord {
                PrText = txtName.Text,
                PrAmount = int.Parse(txtamount.Text),
                PrPrice = int.Parse(txtprice.Text),
                PrTotal = int.Parse(txtTotal.Text),
                PrDate = dateTimePicker1.Value,
            
            };
            _paidrecordRepository.AddPaidRecord(addPaidRecord);

            reloadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtTotal.Text))
            {

                MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົນຖ້ວນ", "ເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            PaidRecord updatePaidRecord = new PaidRecord
            {
                PrId=id,
                PrText = txtName.Text,
                PrAmount = int.Parse(txtamount.Text),
                PrPrice = int.Parse(txtprice.Text),
                PrTotal = int.Parse(txtTotal.Text),
                PrDate = dateTimePicker1.Value,

            };

            _paidrecordRepository.UpdatePaidRecord(updatePaidRecord);
            reloadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ຕ້ອງການລົບຂໍ້ມູນນີ້ຫຼືບໍ?", "ຢືນຢັນ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PaidRecord delePaidRecord = new PaidRecord
                {
                    PrId = id
                };
                _paidrecordRepository.DeletePaidRecord(delePaidRecord);
                reloadData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtamount.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtprice.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTotal.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dateTimePicker1.Value =DateTime.Parse( dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());

                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             var search =data.Where(p => p.PrText.Contains(textBox6.Text)).ToList<PaidRecord>();
            dataGridView1.DataSource = search;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            PaidRecord paid = new PaidRecord {
               PrDate= dateTimePicker2.Value

            };
            var searchMonth = _paidrecordRepository.GetPaidRecordBYMoth(paid);
            dataGridView1.DataSource = searchMonth;
        }
    }
}
