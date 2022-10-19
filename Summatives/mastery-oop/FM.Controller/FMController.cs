using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.View;
using FM.Models;
using FM.BLL;

namespace FM.Controller
{
    public class FMController
    {
        private view view;
        private UserIO userIO;
        private OrderManagerFactory OrderManagerFactory;
        public FMController()
        {
            view = new view();
        }
        public void Run()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                int menuChoice = view.ShowMenuAndGetUserChoice();

                switch(menuChoice)
                {
                    case 1:
                        DisplayOrder();
                        break;
                    case 2:
                        AddOrder();
                        break;
                    case 3:
                        UpdateOrder();
                        break;
                    case 4:
                        DeleteOrder();
                        break;
                    case 5:
                        
                        keepRunning = false;
                        break;

                        
                }
            }
        }
        private void DisplayOrder()
        {
            ShowAllOrders();
        }

        private void ShowAllOrders()
        {
            List<Order> order = new List<Order>();
            
            DateTime dt = view.PromptForOrdDateAny();
           
            OrderManager orderManager = OrderManagerFactory.Create();
            order = orderManager.ReadAllByDate(dt).orders;
            if(order == null)
            {

                view.errorMessage("No orders associated with that date.");

                return;
            }
            
            view.DisplayAllOrders(order,dt);
        }
        private void AddOrder()
        {
            Order order = new Order();
            DateTime dt = view.PromptForOrdDate();
            OrderManager orderManager = OrderManagerFactory.Create();
            List<string> stateList = new List<string>();
            List<string> prodList = new List<string>();
            stateList = orderManager.GenerateStateList();
            
            prodList = orderManager.GenerateProductList();
            Order newOrder = view.CreateOrder(dt,prodList,stateList);
            
            newOrder = orderManager.CalcOrdTotal(newOrder);
            int displayedOrdNumber = orderManager.displayOrderNumber(newOrder);
            newOrder.orderNumber = displayedOrdNumber;
            view.DisplayOrder(newOrder);
            
            bool confirmAnswer = view.confirmAdd();
            if (confirmAnswer == true)
            {
                orderManager.AddOrder(newOrder);
            }
            
        }
        private void UpdateOrder()
        {
            Order order = new Order();
            
            OrderManager orderManager = OrderManagerFactory.Create();
            List<string> stateList = new List<string>();
            List<string> prodList = new List<string>();
            stateList = orderManager.GenerateStateList();

            prodList = orderManager.GenerateProductList();
            DateTime dt = view.PromptForOrdDate();
            string ordNumber = view.PromptForOrderNumber();
           
            order = orderManager.ReadByID(dt, ordNumber);
            if(order == null)
            {
                view.errorMessage("No such order associated with that date.");

                return;
            }
            order.orderDate = dt;
            view.DisplayOrder(order);
            
            Order editedOrder = new Order();

            editedOrder = view.EditOrder(order,prodList,stateList);
            editedOrder.orderDate = dt;
            editedOrder.orderNumber = Convert.ToInt32(ordNumber);
            //edited info is captured at this point
            Order finalOrder = new Order();
            finalOrder = orderManager.CalcEditedOrdResponse(editedOrder);
            view.DisplayOrder(finalOrder);
            bool confirmAnswer = view.confirmUpdate();
            if (confirmAnswer == true)
            {
                orderManager.UpdateOrder(finalOrder);
            }
            

        }
        private void DeleteOrder()
        {
            Order order = new Order();
            OrderManager orderManager = OrderManagerFactory.Create();
            DateTime dt = view.PromptForOrdDate();
            string ordNumber = view.PromptForOrderNumber();
            order = orderManager.ReadByID(dt, ordNumber);
            if (order == null)
            {
                view.errorMessage("No such order associated with that date.");

                return;
            }
            order.orderDate = dt;
            
            view.DisplayOrder(order);
            bool deletionAnswer = view.ConfirmDeletion();
            if(deletionAnswer == true)
            {
                orderManager.DeleteOrder(dt, ordNumber);
            }
            
            

        }
        
    }
}
