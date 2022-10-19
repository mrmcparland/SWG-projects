using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Models;
using FM.BLL;
using FM.Data;
using FM.Data.Interfaces;
using FM.BLL.Responses;
using NUnit.Framework;
using FM.Data.Interfaces;

namespace FM.Test
{
    public class BLL_Tests
    {
        [SetUp]
        public void setUpOrders()
        {

        }
        
        [Test]
        //[TestCase(1)]
        public void displayOrderNumberTest()
        {
            
            Order sentOrder = new Order();
            //Order returnedOrder = new Order();
            sentOrder.orderNumber = 1;
            //OrderManager orderManager = OrderManagerFactory.Create();
            OrderManager orderManager = new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
            int testInt = orderManager.displayOrderNumber(sentOrder);

            Assert.AreEqual(testInt, 1);
            Assert.AreNotEqual(testInt, 2);

        }
        [Test]
        public void ReadByIDTest()
        {
            Order sentOrder = new Order();
            //Order returnedOrder = new Order();
            string orderNumber = "2";
            sentOrder.orderDate = DateTime.Parse("06/01/2013");
            OrderManager orderManager = new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
            Order returnedOrder = orderManager.ReadByID(sentOrder.orderDate,orderNumber);

            Assert.AreEqual(returnedOrder.customerName, "Newman");
            Assert.AreEqual(returnedOrder.tax.StateAbbr, "PA");
            Assert.AreNotEqual(returnedOrder.customerName, "Mike");
        }
        [Test]
        public void GenerateProdListTest()
        {
            OrderManager orderManager = new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
            List<string> prodList = orderManager.GenerateProductList();

            Assert.AreEqual(prodList[0], "Carpet");
            Assert.AreEqual(prodList[1], "Laminate");
            Assert.AreEqual(prodList[2], "Tile");
            Assert.AreEqual(prodList[3], "Wood");
            Assert.AreNotEqual(prodList[0], "Shag");
        }
        [Test]
        public void GenerateStateAbbrListTest()
        {
            OrderManager orderManager = new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
            List<string> stateAbbrList = orderManager.GenerateStateList();

            Assert.AreEqual(stateAbbrList[0], "OH");
            Assert.AreEqual(stateAbbrList[1], "PA");
            Assert.AreEqual(stateAbbrList[2], "MI");
            Assert.AreEqual(stateAbbrList[3], "IN");
            Assert.AreNotEqual(stateAbbrList[0], "NY");
        }
        [Test]
        public void CalcEditedOrd()
        {
            Order editedOrder = new Order();
            editedOrder.tax = new Tax();
            editedOrder.product = new Product();
            OrderManager orderManager = new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
            editedOrder.area = 350;
            editedOrder.tax.StateAbbr = "OH";
            editedOrder.product.ProductType = "Carpet";
            //editedOrder.tax.TaxRate = .0625M;
            //editedOrder.product.CostPerSqFoot = 2.25M;
            //editedOrder.product.LaborCostPerSqFoot = 2.1M;
            Order returnedOrder = orderManager.CalcEditedOrdResponse(editedOrder);

            Assert.AreEqual(returnedOrder.laborCost, 735);
            Assert.AreEqual(returnedOrder.materialCost, 787.5);
            Assert.AreEqual(returnedOrder.taxSubTotal, 95.15625);
            Assert.AreEqual(returnedOrder.total, 1617.65625);
        }
        [Test]
        public void CalcOrdTotalTest()
        {
            Order newOrder = new Order();
            newOrder.tax = new Tax();
            newOrder.product = new Product();
            OrderManager orderManager = new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
            newOrder.area = 250;
            newOrder.tax.StateAbbr = "PA";
            newOrder.product.ProductType = "Tile";
            
            Order returnedOrder = orderManager.CalcOrdTotal(newOrder);

            Assert.AreEqual(returnedOrder.laborCost, 1037.5);
            Assert.AreEqual(returnedOrder.materialCost, 875);
            Assert.AreEqual(returnedOrder.taxSubTotal, 129.09375);
            Assert.AreEqual(returnedOrder.total, 2041.59375);

        }
        [Test]
        public void ReadAllByDateTest()
        {
            List<Order> orders = new List<Order>();
            OrderManager orderManager = new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
            DateTime dt = DateTime.Parse("06/29/2021");
            orders = orderManager.ReadAllByDate(dt).orders;

            Assert.AreEqual(orders[0].customerName, "Molly");
            Assert.AreEqual(orders[1].tax.StateAbbr, "MI");
            Assert.AreEqual(orders[2].product.ProductType, "Wood");
        }
        [Test]
        public void DeleteOrderTest()
        { 
            DateTime dt = DateTime.Parse("06/29/2021");
            OrderManager orderManager = new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
            Order deletedOrder = orderManager.DeleteOrder(dt, "12").order;

            Order lookupOrder = orderManager.ReadByID(dt, "12");

            Assert.IsNull(lookupOrder);
        }
        [Test]
        public void UpdateOrderTest()
        {
            Order editedOrder = new Order();
            editedOrder.tax = new Tax();
            editedOrder.product = new Product();
            OrderManager orderManager = new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
            editedOrder.orderDate = DateTime.Parse("06/29/2021");
            DateTime dt = editedOrder.orderDate;
            editedOrder.orderNumber = 13;
            editedOrder.customerName = "Ned";
            editedOrder.area = 200;
            editedOrder.tax.StateAbbr = "MI";
            editedOrder.product.ProductType = "Tile";
            Order returnedOrder = orderManager.UpdateOrder(editedOrder).order;

            Order lookupOrder = orderManager.ReadByID(dt, "13");
            Assert.AreEqual(lookupOrder.customerName, "Ned");
        }
        [Test]
        public void AddOrderTest()
        {
            Order newOrder = new Order();
            newOrder.product = new Product();
            newOrder.tax = new Tax();
            newOrder.orderDate = DateTime.Parse("06/29/2021");
            DateTime dt = newOrder.orderDate;
            //newOrder.orderNumber = 50;
            newOrder.customerName = "Janice";
            newOrder.tax.StateAbbr = "PA";
            newOrder.tax.TaxRate = 6.75M;
            newOrder.product.ProductType = "Laminate";
            newOrder.area = 100;
            newOrder.product.CostPerSqFoot = 1.75M;
            newOrder.product.LaborCostPerSqFoot = 2.1M;
            newOrder.materialCost = 175M;
            newOrder.laborCost = 210M;
            newOrder.taxSubTotal = 25.9875M;
            newOrder.total = 410.9875M;
            OrderManager orderManager = new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
            Order returnedOrder = orderManager.AddOrder(newOrder).order;
            Order lookupOrder = orderManager.ReadByID(dt, "14");

            Assert.AreEqual(lookupOrder.customerName, "Janice");



        }
    }
}
