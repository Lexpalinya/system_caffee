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
    public partial class frmReport : Form
    {
        private readonly AccountRepository _accountRepository;
        private readonly BillRepository _billRepository;
        private readonly SalaryPaymentRepository _salaryPaymentRepository;
        private List<AccountView> data;
        private AccountView av;
        public frmReport()
        {
            _accountRepository = new AccountRepository(new connectionDB().getConnection());
            _billRepository = new BillRepository(new connectionDB().getConnection());
            _salaryPaymentRepository = new SalaryPaymentRepository(new connectionDB().getConnection());
            InitializeComponent();
        }
        public frmReport(AccountView accountView)
        {
            av = accountView;
            _accountRepository = new AccountRepository(new connectionDB().getConnection());
            _billRepository = new BillRepository(new connectionDB().getConnection());
            _salaryPaymentRepository = new SalaryPaymentRepository(new connectionDB().getConnection());
            InitializeComponent();
        }

        private void ລາຍງານຍອດຂາຍToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            List<Bill> data = _billRepository.GetBillReport(dateTimePicker1.Value).ToList();
          
            reportTotalsales cr1 = new reportTotalsales();
            cr1.SetDataSource(data);
            crystalReportViewer1.ReportSource = cr1;
            crystalReportViewer1.Refresh();

        }

        private void ລາຍງານບນຊToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<AccountView> data = _accountRepository.GetAllAccount().ToList();
            reportAccount cr1 = new reportAccount();
            cr1.SetDataSource(data);
            crystalReportViewer1.ReportSource = cr1;
            crystalReportViewer1.Refresh();
        }

        private void ລາຍງານຈາຍເງນເດອນToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryPayment salary = new SalaryPayment { 
                SpPayday=dateTimePicker1.Value,
                SpStatusPay=1            
            };
            List<SalaryPaymentView> data = _salaryPaymentRepository.GetSalaryPaymentViewsByMonthYearAndStatus(salary).ToList();
           reportSalarys cr1 = new reportSalarys();
            cr1.SetDataSource(data);
            crystalReportViewer1.ReportSource = cr1;
            crystalReportViewer1.Refresh();
        }
    }
}
