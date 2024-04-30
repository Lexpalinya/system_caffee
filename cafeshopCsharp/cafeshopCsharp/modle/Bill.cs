using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafeshopCsharp.modle
{
  public class Bill
{
    public int BlId { get; set; }
    public Member MemberData{ get; set; }
    public Account AccountData { get; set; }
    public double BlTotalMoney { get; set; }
    public DateTime BlDate { get; set; }
}

}
