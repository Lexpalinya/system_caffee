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



        private readonly ProductRepository _productRepository;

        private readonly AccountRepository _accountRepository;

        private readonly SalaryPaymentRepository _salaryPaymentRepository;


        private readonly EmployeeRepository _employeeRepository;
        private readonly BillRepository _billRepository;

        private readonly BillDetailRepository _billDetailRepository;

        public Form2()
        {
            InitializeComponent();
             _memberRepository = new MemberRepository(new connectionDB().getConnection());
            _paidRecordRepository = new PaidRecordRepository(new connectionDB().getConnection());
            _productRepository = new ProductRepository(new connectionDB().getConnection());
            _accountRepository = new AccountRepository(new connectionDB().getConnection());
            _salaryPaymentRepository = new SalaryPaymentRepository(new connectionDB().getConnection());

            _employeeRepository = new EmployeeRepository(new connectionDB().getConnection());

            _billRepository = new BillRepository(new connectionDB().getConnection());

            _billDetailRepository = new BillDetailRepository(new connectionDB().getConnection());
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            // test Member CRUD --------------------------------------------------------------------------------
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
            //Member findPhone = new Member {
            //    mbPhoneNumber = "28434443"
            
            //};


            //  _memberRepository.AddMember(addMember);
            //

            //  _memberRepository.UpdataMember(updateMember);
            //_memberRepository.UpdatePoints(updatePoints);
            // _memberRepository.DeleteMember(deleteMember);
           //var members = _memberRepository.GetAllMembers();
             var members=  _memberRepository.GetMember("28434443");
            List<Member> found = new List<Member> { members };

             dataGridView1.DataSource = found; 


            //test PaidRecord CRUD---------------------------------------------------------------------
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
            //  _paidRecordRepository.DeletePaidRecord(deletePaidRecord);

            //   var paidrecord = _paidRecordRepository.GetAllPaidRecord();

            //var paidrecord = _paidRecordRepository.GetPaidRecordBYMoth(paMonth);

            // dataGridView1.DataSource = paidrecord;




            // test Product CRUD-----------------------------------------------------------------------
            Product findStatus = new Product {
                PStatus = 1,
            };
            Product findType = new Product
            {
                PType = "Hot"
            };

            //Product AddProduct = new Product
            //{
            //    PName="coffee",
            //    PType="Hot",
            //    PSize="S,M,L,XL",
            //    PPrice=50000,
            //    PImage=null,
            //    PStatus=1,
            //    PPriceOriginal=20000,
            //    PExp="no"

            //};

            Product deleteProduct = new Product {
                PId = 1
            };
            // _productRepository.DeteleProduct(deleteProduct);



            // var product = _productRepository.GetAllProducts();
            //var product = _productRepository.GetProductByStatus(findStatus);



            // var product = _productRepository.GetProductByType(findType);
            // dataGridView1.DataSource = product;





            //test Account -----------------------------------------------------------------------

            Account acc = new Account {
                AccPassword = "1234",
                AccUserName = "palinya",

            };

            Account addAcc = new Account {
                AccEmpId=4,
                AccLevel="Seller",
                AccPassword="1234",
                AccUserName="palinya",
                       
            };

            Account updateAcc = new Account
            {
                AccId=11,
                AccEmpId = 4,
                AccLevel = "Seller",
                AccPassword = "1234",
                AccUserName = "oshi noy",

            };

            Account deleteAcc = new Account { 
            AccId=8
            };
            //  _accountRepository.AddAccount(addAcc);

            // _accountRepository.UpdateAccount(updateAcc);
            //  _accountRepository.DeleteAccount(deleteAcc);

            var data = _accountRepository.GetAllAccount();
            dataGridView1.DataSource = data;



            // var data = _accountRepository.AccountLogin(acc);

            //  dataGridView1.DataSource=new List<AccountAll> { data};



            // test SalayPayment ---------------------------------------------------------------------------------------

            SalaryPayment findspMonthYear = new SalaryPayment {
                SpPayday = new DateTime(2024,04,03)
            
            };

            SalaryPayment findspEmpId = new SalaryPayment {
            
                SpEmpId=5
            };

            SalaryPayment addSalaryPayment = new SalaryPayment { 
                SpEmpId=4,
                SpSalary=250000,
                SpPayday=new DateTime(2024,04,30),
                SpStatusPay=0
            };

            SalaryPayment updateStatusSalaryPayment = new SalaryPayment
            {
                SpId=3,
                
                SpStatusPay = 1
            };
            SalaryPayment deleteSalaryPayment = new SalaryPayment { 
             SpId=3
            };

            _salaryPaymentRepository.AddSalaryPaymentByEmployee();
            // _salaryPaymentRepository.AddSalaryPayment(addSalaryPayment);

            // _salaryPaymentRepository.UpdateStatusSalaryPayment(updateStatusSalaryPayment);

            // _salaryPaymentRepository.DeleteSalayPayment(deleteSalaryPayment);

            //  var data = _salaryPaymentRepository.GetAllSalaryPaymentViews();
            //var data = _salaryPaymentRepository.GetSalaryPaymentViewsByMonthYear(findspMonthYear);
            //var data = _salaryPaymentRepository.GetSalaryPaymentViewsByIdEmployee(findspEmpId);
            // dataGridView1.DataSource = data;

            // test Employee ------------------------------------------------------------------------------------------

            //  Employee deleteEmp = new Employee { 
            //      EmpId=5

            //  };
            //  _employeeRepository.DeleteEmployee(deleteEmp);
            //var data = _employeeRepository.GetAllEmployee();
            // dataGridView1.DataSource = data;

            //test Bill-----------------------------------------------------------------------------------------------

            Bill addBill = new Bill {
                BlMbId = 3,
                BlAccId = 12,
                BlTotalMoney = 50000,
                BlDate = DateTime.Now
            };

            // _billRepository.AddBill(addBill);


            // test BillDetail ------------------------------------------------------------------------------


            BillDetail addbillDetail = new BillDetail { 
            
                BdblId=1,
                BdPId=2,
                BdSize="S",
                BdPrice=50000,
                BdAmount=1,
                BdTotal=50000
            };
          //  _billDetailRepository.AddBillDetail(addbillDetail);

           



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img=null;
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK) {
                try {
                    string filename = op.FileName;

                    img = Image.FromFile(filename);
                
                }
                catch (Exception ex) {
                    MessageBox.Show("Error uploading image:"+ex.Message);
                
                }
            }


            if (img!=null) {
                // test Product ---------------------------------------------------------------------------------------



                //Product AddProduct = new Product
                //{
                //    PName = "coffee",
                //    PType = "Hot",
                //    PSize = "S,M,L,XL",
                //    PPrice = 50000,
                //    PImage = new ConvertByteToImage().ImageToByteArray(img),
                //    PStatus = 1,
                //    PPriceOriginal = 20000,
                //    PExp = "no"

                //};


                //Product updateProduct = new Product
                //{
                //    PId=2,
                //    PName = "Green tea",
                //    PType = "Hot",
                //    PSize = "S,M,L,XL",
                //    PPrice = 50000,
                //    PImage = new ConvertByteToImage().ImageToByteArray(img),
                //    PStatus = 1,
                //    PPriceOriginal = 20000,
                //    PExp = "no"

                //};
                // _productRepository.AddProduct(AddProduct);

                //_productRepository.UpdateProduct(updateProduct);
                //var product = _productRepository.GetAllProducts();
                //dataGridView1.DataSource = product;


                // test Employee -------------------------------------------------------------------------------------------
               // Employee addEmp = new Employee {
               // EmpName="palinya",
               // EmpLastName="Khanthaphengxai",
               // EmpAddress="drndang ,gunthabury",
               // EmpPhoneNumber="58578313",
               // EmpPosition="CEO",
               // EmpSalary=6000000,
               //EmpImage=new ConvertByteToImage().ImageToByteArray(img)
                
               // };
               // Employee updateEmp = new Employee
               // {
               //     EmpId=4,
               //     EmpName = "palinya",
               //     EmpLastName = "Khanthaphengxai",
               //     EmpAddress = "drndang ,gunthabury",
               //     EmpPhoneNumber = "58578313",
               //     EmpPosition = "CEO",
               //     EmpSalary = 6000000,
               //     EmpImage = new ConvertByteToImage().ImageToByteArray(img)

               // };

                //_employeeRepository.AddEmployee(addEmp);
               // _employeeRepository.UpdateEmployee(updateEmp);
                var data = _employeeRepository.GetAllEmployee();
                dataGridView1.DataSource = data;

            }
          
        }

      
    }
}
