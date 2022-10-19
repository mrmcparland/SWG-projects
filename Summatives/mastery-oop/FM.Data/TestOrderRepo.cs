using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Data.Interfaces;
using FM.Models;
using System.IO;

namespace FM.Data
{
    public class TestOrderRepo : IOrderRepository
    {
        private static Order _order = new Order
        {
            
            


        };
        public Order AddOrder(Order order)
        {
            Order thisOrder = new Order();
            thisOrder.tax = new Tax();
            thisOrder.product = new Product();

            thisOrder.orderNumber = 1;
            thisOrder.customerName = "Jake";
            thisOrder.tax.StateAbbr = "IN";
            thisOrder.product.ProductType = "Tile";
            thisOrder.area = 105;
            thisOrder.tax.TaxRate = .06M;
            thisOrder.product.CostPerSqFoot = 3.5M;
            thisOrder.product.LaborCostPerSqFoot = 4.15M;
            thisOrder.materialCost = thisOrder.product.CostPerSqFoot * thisOrder.area;
            thisOrder.laborCost = thisOrder.product.LaborCostPerSqFoot * thisOrder.area;
            thisOrder.taxSubTotal = (thisOrder.materialCost + thisOrder.laborCost) * thisOrder.tax.TaxRate;
            thisOrder.total = thisOrder.materialCost + thisOrder.laborCost + thisOrder.taxSubTotal;

            return thisOrder;
        }
        public Order LoadOrder(DateTime orderDate, string orderNumber)
        {
            string strDate = orderDate.ToString();

            string[] strDateCleaned = strDate.Split(' ');
            string dateOnly = strDateCleaned[0];
            dateOnly = dateOnly.Replace("/", "");
            string path = @"C:\Users\mike\Downloads\TestData\Orders" + dateOnly + ".txt";
            try
            {
                string[] rows = File.ReadAllLines(path);
                Order order = new Order();
                order.tax = new Tax();
                order.product = new Product();

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split(',');
                    if (orderNumber == columns[0])
                    {
                        var wholeOrder = from r in rows[i]
                                         where columns[0] == orderNumber
                                         select rows[i];
                        string wholeOrderConverted = wholeOrder.FirstOrDefault().ToString();
                        string[] brokenOrder = wholeOrderConverted.Split(',');
                        //Console.WriteLine("Order is " + rows[i]);
                        order.orderNumber = Convert.ToInt32(brokenOrder[0]);
                        order.customerName = Convert.ToString(brokenOrder[1]);
                        if (order.customerName.Contains(" [COMMA] "))
                        {
                            order.customerName = order.customerName.Replace(" [COMMA] ", ",");
                        }
                        order.tax.StateAbbr = Convert.ToString(brokenOrder[2]);
                        order.tax.TaxRate = Convert.ToDecimal(brokenOrder[3]);
                        order.product.ProductType = Convert.ToString(brokenOrder[4]);
                        order.area = Convert.ToDecimal(brokenOrder[5]);
                        order.product.CostPerSqFoot = Convert.ToDecimal(brokenOrder[6]);
                        order.product.LaborCostPerSqFoot = Convert.ToDecimal(brokenOrder[7]);
                        order.materialCost = Convert.ToDecimal(brokenOrder[8]);
                        order.laborCost = Convert.ToDecimal(brokenOrder[9]);
                        order.taxSubTotal = Convert.ToDecimal(brokenOrder[10]);
                        order.total = Convert.ToDecimal(brokenOrder[11]);
                        return order;
                    }
                }
            }

            catch (FileNotFoundException)
            {
                return null;
            }
            return null;
        }

        public List<Order> ReadAllByDate(DateTime orderDate)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
        public int findOrderNumberForDisplay(Order order)
        {
            throw new NotImplementedException();
        }

        public Order DeleteOrder(DateTime orderDate, string OrderNumber)
        {
            throw new NotImplementedException();
        }
    }
}
