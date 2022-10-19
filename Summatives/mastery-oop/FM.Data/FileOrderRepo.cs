using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Data.Interfaces;
using FM.Models;
using System.IO;
using System.Linq;

namespace FM.Data
{
    
    public class FileOrderRepo : IOrderRepository
    {
        string directoryPartial;
        string txt;
        string ordDate;
        string directory;
        public FileOrderRepo()
        {
            directory = @"C:\Users\mike\Downloads\SampleData\Orders6292021.txt";
            txt = ".txt";
            directory = directoryPartial + ordDate + txt;
        }
        public FileOrderRepo(string path)
        {
            directory = path;
        }
            public Order AddOrder(Order order)
        {
            Order completedOrder = new Order();
            //get string for file name
            string strDate = order.orderDate.ToString();
            string[] strDateCleaned = strDate.Split(' ');
            string dateOnly = strDateCleaned[0];
            dateOnly = dateOnly.Replace("/", "");
            string path = directory;
            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);

                //File.WriteAllText(path, string.Empty);


                int lRow = rows.Length;
                //Console.WriteLine("There are " + lRow + " rows.");
                string[] lRowFull = rows[lRow - 1].Split(',');

                if (lRow == 1)
                {
                    order.orderNumber = 1;

                }
                else
                {
                    int extractedOrdNumber = Convert.ToInt32(lRowFull[0]);
                    order.orderNumber = extractedOrdNumber + 1;

                }


                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(order.orderNumber.ToString() + "," + order.customerName + "," + order.tax.StateAbbr + "," + order.tax.TaxRate + "," + order.product.ProductType + ","
                        + order.area + "," + order.product.CostPerSqFoot + "," + order.product.LaborCostPerSqFoot + "," + order.materialCost + "," + order.laborCost + ","
                        + order.taxSubTotal + "," + order.total);
                }

                //throw new NotImplementedException();
                return completedOrder;
            }
            else
            {
                //Directory.CreateDirectory(path);
                using (StreamWriter sw = File.CreateText(path))
                {
                    order.orderNumber = 1;
                    sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    sw.WriteLine(order.orderNumber + "," + order.customerName + "," + order.tax.StateAbbr + "," + order.tax.TaxRate + "," + order.product.ProductType + ","
                      + order.area + "," + order.product.CostPerSqFoot + "," + order.product.LaborCostPerSqFoot + "," + order.materialCost + "," + order.laborCost + ","
                        + order.taxSubTotal + "," + order.total);

                    return completedOrder;
                }
            }


        }

            public int findOrderNumberForDisplay(Order order)
        {
            int displayedNumber;
            Order completedOrder = new Order();
            //get string for file name
            string strDate = order.orderDate.ToString();
            string[] strDateCleaned = strDate.Split(' ');
            string dateOnly = strDateCleaned[0];
            dateOnly = dateOnly.Replace("/", "");
            string path = directory;
            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);

                //File.WriteAllText(path, string.Empty);


                int lRow = rows.Length;
                //Console.WriteLine("There are " + lRow + " rows.");
                string[] lRowFull = rows[lRow - 1].Split(',');

                if (lRow == 1)
                {
                    order.orderNumber = 1;
                    displayedNumber = order.orderNumber;
                    return displayedNumber;
                }
                else
                {
                    int extractedOrdNumber = Convert.ToInt32(lRowFull[0]);
                    order.orderNumber = extractedOrdNumber + 1;
                    displayedNumber = order.orderNumber;
                    return displayedNumber;

                }
            }
            return 1;
            }
            public Order DeleteOrder(DateTime orderDate, string OrderNumber)
            {
                string strDate = orderDate.ToString();
                string[] strDateCleaned = strDate.Split(' ');
                string dateOnly = strDateCleaned[0];
                dateOnly = dateOnly.Replace("/", "");
                string path = directory;
                string[] rows = File.ReadAllLines(path);
                //string orderNumberConverted = OrderNumber;
                //File.WriteAllText(path, string.Empty);
                Order editedOrder = new Order();

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split(',');
                    if (OrderNumber == columns[0])
                    {
                        var wholeOrder = from r in rows[i]
                                         where Convert.ToString(columns[0]) == OrderNumber
                                         select rows[i];
                        rows[i] = "";
                        File.WriteAllLines(path, rows);
                    }
                }
                var lines = File.ReadAllLines(path).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(path, lines);
                return editedOrder;
            }

            public List<Order> ReadAllByDate(DateTime orderDate)
            {

                string strDate = orderDate.ToString();

                string[] strDateCleaned = strDate.Split(' ');
                string dateOnly = strDateCleaned[0];
                dateOnly = dateOnly.Replace("/", "");
            string path = directory;
                if (!File.Exists(path))
                {
                    return null;
                }
                string[] rows = File.ReadAllLines(path);
                List<Order> order = new List<Order>();

                List<string> ordMem = new List<string>();


                for (int i = 1; i < rows.Length; i++)
                {

                    Order item = new Order();
                    //ordMem.Add(rows[i]);
                    string[] columns = rows[i].Split(',');
                    order.Add(item);

                    order[i - 1].tax = new Tax();
                    order[i - 1].product = new Product();


                    order[i - 1].orderNumber = Convert.ToInt32(columns[0]);
                    order[i - 1].customerName = columns[1];

                    order[i - 1].tax.StateAbbr = Convert.ToString(columns[2]);
                    order[i - 1].tax.TaxRate = Convert.ToDecimal(columns[3]);
                    order[i - 1].product.ProductType = columns[4];
                    order[i - 1].area = Convert.ToDecimal(columns[5]);
                    order[i - 1].product.CostPerSqFoot = Convert.ToDecimal(columns[6]);
                    order[i - 1].product.LaborCostPerSqFoot = Convert.ToDecimal(columns[7]);
                    order[i - 1].materialCost = Convert.ToDecimal(columns[8]);
                    order[i - 1].laborCost = Convert.ToDecimal(columns[9]);
                    order[i - 1].taxSubTotal = Convert.ToDecimal(columns[10]);
                    order[i - 1].total = Convert.ToDecimal(columns[11]);



                }

                return order;


            }

            public Order UpdateOrder(Order order)
            {
                string strDate = order.orderDate.ToString();
                string[] strDateCleaned = strDate.Split(' ');
                string dateOnly = strDateCleaned[0];
                dateOnly = dateOnly.Replace("/", "");
            //string path = @"C:\Users\mike\Downloads\SampleData\Orders" + dateOnly + ".txt";
                string path = directory;
                string[] rows = File.ReadAllLines(path);
                string orderNumberConverted = Convert.ToString(order.orderNumber);
                //File.WriteAllText(path, string.Empty);
                Order editedOrder = new Order();

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split(',');
                    if (Convert.ToString(order.orderNumber) == columns[0])
                    {
                        var wholeOrder = from r in rows[i]
                                         where Convert.ToInt32(columns[0]) == order.orderNumber
                                         select rows[i];
                        rows[i] = order.orderNumber.ToString() + "," + order.customerName + "," + order.tax.StateAbbr + "," + order.tax.TaxRate + "," + order.product.ProductType + ","
                                + order.area + "," + order.product.CostPerSqFoot + "," + order.product.LaborCostPerSqFoot + "," + order.materialCost + "," + order.laborCost + ","
                                + order.taxSubTotal + "," + order.total;
                        File.WriteAllLines(path, rows);
                    }
                }
                return editedOrder;
            }

            public Order LoadOrder(DateTime orderDate, string orderNumber)
            {
                string strDate = orderDate.ToString();

                string[] strDateCleaned = strDate.Split(' ');
                string dateOnly = strDateCleaned[0];
                dateOnly = dateOnly.Replace("/", "");
                string path = directory;
                //string path = @"C:\Users\mike\Downloads\SampleData\Orders" + dateOnly + ".txt";
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



        }


    } 

        

        
    

