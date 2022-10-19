using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models
{
    public class Product
    {
        public string ProductType { get; set; }
        public decimal CostPerSqFoot { get; set; }
        public decimal LaborCostPerSqFoot { get; set; }
    }
}
