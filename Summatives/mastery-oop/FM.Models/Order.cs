using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Models
{
    public class Order
    {
        public Product product { get; set; }
        public Tax tax { get; set; }
        public DateTime orderDate { get; set; }
        public int orderNumber { get; set; }
        public string customerName { get; set; }
        public decimal area { get; set; }
        public decimal materialCost { get; set; }
        public decimal laborCost { get; set; }
        public decimal taxSubTotal { get; set; }
        public decimal total { get; set; }
    }
}
