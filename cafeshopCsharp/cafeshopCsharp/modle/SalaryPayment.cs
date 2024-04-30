using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafeshopCsharp.modle
{
    public class SalaryPayment
    {
        public int SpId { get; set; }
        public Employee EmployeeData { get; set; }
        public int SpSalary { get; set; }
        public DateTime SpPayday { get; set; }
    }

}
