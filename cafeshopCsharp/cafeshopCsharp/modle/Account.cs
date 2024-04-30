using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafeshopCsharp.modle
{
    public class Account
    {
        public int AccId { get; set; }
        
        public Employee EmployeeData { get; set; }

        public AccountLevel AccLevel { get; set; }
        public string AccUserName { get; set; }
        public string AccPassword { get; set; }
    }

    public enum AccountLevel
    {
        Seller,
        Admin
    }



}
