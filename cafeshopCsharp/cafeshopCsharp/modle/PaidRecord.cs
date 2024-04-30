using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafeshopCsharp.modle
{
    public class PaidRecord
    {
        public int PrId { get; set; }
        public string PrText { get; set; }
        public int PrAmount { get; set; }
        public int PrPrice { get; set; }
        public DateTime PrDate { get; set; }
    }
}
