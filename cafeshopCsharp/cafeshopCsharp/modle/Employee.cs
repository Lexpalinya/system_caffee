using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafeshopCsharp.modle
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpPhoneNumber { get; set; }
        public string EmpPosition { get; set; }
        public int EmpSalary { get; set; }
        public byte[] EmpImage { get; set; }
    }
}
