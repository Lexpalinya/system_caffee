using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafeshopCsharp.modle
{
    class BillDetail
    {
        public int BdblId { get; set; }
        public Product ProductData { get; set; }
        public string BdSize { get; set; }
        public int BdPrice { get; set; }
        public int BdAmount { get; set; }
        public int BdTotal { get; set; }
    }
}
