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
    public partial class Form2 : Form
    {
        private readonly MemberRepository _memberRepository;

        private readonly PaidRecordRepository _paidRecordRepository;
        public Form2()
        {
            InitializeComponent();
             _memberRepository = new MemberRepository(new connectionDB().getConnection());
            _paidRecordRepository = new PaidRecordRepository(new connectionDB().getConnection());

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Member addMember = new Member
            {
                mbName = "bou",
                mbPhoneNumber = "58578313",
                mbAddress = "ທ່າແຂກ, ຄຳມ່ວນ",
                mbPoints = 0



            };
            Member updateMember = new Member
            {
                mbId = 3,
                mbName = "kittima",
                mbPhoneNumber = "28434443",
                mbAddress = "ທ່າແຂກ, ຄຳມ່ວນ",
                mbPoints = 0


            };

            Member updatePoints = new Member
            {
                mbPhoneNumber = "28490166",
                mbPoints = 10
            };
            Member deleteMember = new Member
            {
                mbId = 1
            };


            //  _memberRepository.AddMember(addMember);
            //

            //  _memberRepository.UpdataMember(updateMember);
            //_memberRepository.UpdatePoints(updatePoints);
            // _memberRepository.DeleteMember(deleteMember);
            //var members = _memberRepository.GetAllMembers();
            // var members=  _memberRepository.GetMember("28434443");
            // List<Member> found = new List<Member> { members };

            //  dataGridView1.DataSource = found; 



            PaidRecord paMonth = new PaidRecord
            {
                PrDate = new DateTime(2024, 04, 02),
            };
            PaidRecord addpaidRecord = new PaidRecord
            {
                PrText = "tea",
                PrAmount = 10,
                PrPrice = 100000,
                PrTotal = 10 * 100000,
                PrDate = new DateTime(2024, 06, 02)

            };

            PaidRecord updateRecord = new PaidRecord
            {
                PrId=1,
                PrText = "coffee",
                PrAmount = 10,
                PrPrice = 100000,
                PrTotal = 10 * 100000,
                PrDate = new DateTime(2024, 06, 02)
            };
            PaidRecord deletePaidRecord = new PaidRecord {
                PrId=2
            
            };

            //  _paidRecordRepository.AddPaidRecord(addpaidRecord);
            // _paidRecordRepository.UpdatePaidRecord(updateRecord);
            _paidRecordRepository.DeletePaidRecord(deletePaidRecord);

            var paidrecord = _paidRecordRepository.GetAllPaidRecord();

            //var paidrecord = _paidRecordRepository.GetPaidRecordBYMoth(paMonth);

            dataGridView1.DataSource = paidrecord;


        }
    }
}
