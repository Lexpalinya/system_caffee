using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafeshopCsharp.modle
{
    public class Product
    {
        public int PId { get; set; }
        public string PName { get; set; }
        public ProductType PType { get; set; }
        public string PSize { get; set; }
        public int PPrice { get; set; }
        public byte[] PImage { get; set; }
        public bool PStatus { get; set; }
        public int PPriceOriginal { get; set; }
        public string PExp { get; set; }
    }

    public enum ProductType
    {
        Hot,
        Cool,
        Mix,
        Other
    }

}
