using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Models;

namespace FM.View
{
    public class view
    {
        private UserIO userIO;

        public view()
        {
            userIO = new UserIO();
        }
        public int ShowMenuAndGetUserChoice()
        {
            Console.WriteLine("**************************************");

            Console.WriteLine("\n* Flooring Program");
            Console.WriteLine("*");
            Console.WriteLine("* 1. Display Orders");
            Console.WriteLine("* 2. Add an Order ");

            Console.WriteLine("* 3. Edit an Order ");
            Console.WriteLine("* 4. Remove an Order");
            Console.WriteLine("* 5. Quit");
            Console.WriteLine("*");
            Console.WriteLine("**************************************");
            int userChoice = userIO.ReadInt("Enter your choice: ", 1, 5);

            return userChoice;
        }
        public void DisplayOrder(Order order)
        {
            string dateOnly = order.orderDate.ToShortDateString();
            Console.WriteLine("**************************************");
            Console.WriteLine(order.orderNumber + " | " + dateOnly);
            Console.WriteLine(order.customerName);
            Console.WriteLine(order.tax.StateAbbr);
            Console.WriteLine("Product : " + order.product.ProductType);
            Console.WriteLine("Materials : $" + string.Format("{0:0.00}", (order.product.CostPerSqFoot * order.area)));
            Console.WriteLine("Labor : $" + string.Format("{0:0.00}", (order.product.LaborCostPerSqFoot * order.area)));
            Console.WriteLine("Tax : $" + string.Format("{0:0.00}", (order.taxSubTotal)));
            Console.WriteLine("Total : $" + string.Format("{0:0.00}", (order.total)));
            Console.WriteLine("**************************************");
        }
        public void DisplayAllOrders(List<Order> orders,DateTime dt)
        {
            
            for(int i =0; i < orders.Count; i++)
            {
                
                orders[i].orderDate = dt;
                string dateOnly = orders[i].orderDate.ToShortDateString();
                if (orders[i].customerName.Contains(" [COMMA] "))
                {
                    orders[i].customerName = orders[i].customerName.Replace(" [COMMA] ", ",");
                }
                Console.WriteLine("**************************************");
                Console.WriteLine(orders[i].orderNumber + " | " + dateOnly);
                Console.WriteLine(orders[i].customerName);
                Console.WriteLine(orders[i].tax.StateAbbr);
                Console.WriteLine("Product : " + orders[i].product.ProductType);
                Console.WriteLine("Materials : $" + string.Format("{0:0.00}", (orders[i].product.CostPerSqFoot * orders[i].area)));
                Console.WriteLine("Labor : $" + string.Format("{0:0.00}",(orders[i].product.LaborCostPerSqFoot * orders[i].area)));
                Console.WriteLine("Tax : $" + string.Format("{0:0.00}", (orders[i].taxSubTotal)));
                Console.WriteLine("Total : $" + string.Format("{0:0.00}", (orders[i].total)));
                Console.WriteLine("**************************************");
                
            }
        }
        public Order CreateOrder(DateTime dt, List<string> prodList, List<string> stateList)
        {
            Order order = new Order();
            order.tax = new Tax();
            order.product = new Product();

            order.orderDate = dt;
            order.customerName = userIO.ReadString("Enter the customer name: ");
            if(order.customerName.Contains(","))
            {
                order.customerName = order.customerName.Replace(",", " [COMMA] ");
            }
            bool spChar = userIO.ReadName(order.customerName);
            while(spChar == true)
            {
                Console.WriteLine("Please enter a name without special characters: ");
                order.customerName = Console.ReadLine();
                spChar = userIO.ReadName(order.customerName);

            }
            order.tax.StateAbbr = userIO.ReadString("Enter the two-letter state abbreviation for the order: ");
            while(true)
            {
                if (stateList.Contains(order.tax.StateAbbr))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Service not available in that state, please try again.");
                    order.tax.StateAbbr = userIO.ReadString("Enter the state for the order: ");
                }
            }
            order.product.ProductType = userIO.ReadString("Enter the product type: ");
            while(true)
            {
                if(prodList.Contains(order.product.ProductType))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Product type not available, please try again.");
                    order.product.ProductType = userIO.ReadString("Enter the product type: ");
                }
            }
            order.area = userIO.ReadDecimal("Enter the square footage area for the order: ");

            return order;
        }
        public Order EditOrder(Order order, List<string> prodList, List<string> stateList)
        {
            Order oldOrder = new Order();
            order.tax = new Tax();
            order.product = new Product();

            oldOrder = order;
            oldOrder.orderNumber = order.orderNumber;
            oldOrder.customerName = order.customerName;
            //Console.WriteLine("OldOrder for " + oldOrder.customerName);
            //Console.ReadKey();
            oldOrder.area = order.area;
            oldOrder.product.ProductType = order.product.ProductType;
            oldOrder.tax.StateAbbr = order.tax.StateAbbr;
            
            
            order.customerName = userIO.ReadString("Enter the customer name: ");
            if (order.customerName.Contains(","))
            {
                order.customerName = order.customerName.Replace(",", " [COMMA] ");
            }
            bool spChar = userIO.ReadName(order.customerName);
            while (spChar == true)
            {
                Console.WriteLine("Please enter a name without special characters: ");
                order.customerName = Console.ReadLine();
                spChar = userIO.ReadName(order.customerName);

            }

            order.tax.StateAbbr = userIO.ReadString("Enter the two-letter state abbreviation for the order: ");
            while (true)
            {
                if (stateList.Contains(order.tax.StateAbbr))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Service not available in that state, please try again.");
                    order.tax.StateAbbr = userIO.ReadString("Enter the state for the order: ");
                }
            }
            order.product.ProductType = userIO.ReadString("Enter the product type: ");
            while (true)
            {
                if (prodList.Contains(order.product.ProductType))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Product type not available, please try again.");
                    order.product.ProductType = userIO.ReadString("Enter the product type: ");
                }
            }

            order.area = userIO.ReadDecimal("Enter the area size for the order: ");

            return order;
            //Console.WriteLine("Edited order is below:");
            //move display back to controller, then confirm edit
            //DisplayOrder(order);  
        }
        public void DeleteOrder()
        {
            Order order = new Order();

            order.orderDate = userIO.ReadDate();
            order.orderNumber = userIO.ReadOrderNumber("Enter the order number: ");
        }

        public DateTime PromptForOrdDate()
        {
            Order order = new Order();
            Console.WriteLine("Please enter the date of the order, in format MM/DD/YYYY");
            //string enteredDate = Console.ReadLine();
            order.orderDate = userIO.ReadDate();
            return order.orderDate;
        }
        public DateTime PromptForOrdDateAny()
        {
            Order order = new Order();
            Console.WriteLine("Please enter the date of the order, in format MM/DD/YYYY");
            //string enteredDate = Console.ReadLine();
            order.orderDate = userIO.ReadDateAny();
            return order.orderDate;
        }
        public string PromptForOrderNumber()
        {
            Console.WriteLine("Enter the order number to update: ");
            string ordNumber = Console.ReadLine();
           
            return ordNumber;
        }
        public bool ConfirmDeletion()
        {
            string prompt = ("Do you wish to delete the above order? Enter Y for 'yes' or N for 'no'");
            bool answer = userIO.ReadOrderConfirm(prompt);
            return answer;
        }
        public void errorMessage(string message)
        {
            Console.WriteLine(message);
        }
        public bool confirmUpdate()
        {
            string prompt = ("Do you wish to confirm this order update?");
            bool answer = userIO.ReadOrderConfirm(prompt);
            if(answer)
            {
                Console.WriteLine("Order has been updated.");
            }
            else if(!answer)
            {
                Console.WriteLine("Order not updated, returning to main menu.");
            }
            return answer;
        }
        public bool confirmAdd()
        {
            string prompt = ("Do you wish to add the above order? Enter Y for 'yes' or N for 'no'");
            bool answer = userIO.ReadOrderConfirm(prompt);
            return answer;
        }
        public void nullError()
        {
            Console.WriteLine("No such order found, press any key to return to main menu");
            Console.ReadKey();
            
        }
    }
}
