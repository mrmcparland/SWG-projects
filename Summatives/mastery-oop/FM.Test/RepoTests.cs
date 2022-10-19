using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Models;
using FM.Data;
using NUnit.Framework;
using FM.BLL;

namespace FM.Test
{
    [TestFixture]
    public class RepoTests
    {
        [SetUp]
        public void Setup()
        {
            //Clear out files/directory before each unit test
            FileOrderRepo repo = new FileOrderRepo(@"C:\Users\mike\Downloads\TestData\Orders6292021.txt");
            DateTime dt = DateTime.Parse("06/29/2021");

            Order newOrder = new Order();
            newOrder.tax = new Tax();
            newOrder.product = new Product();
            newOrder.customerName = "Ross";
            newOrder.area = 150;
            newOrder.product.ProductType = "Carpet";
            newOrder.tax.StateAbbr = "IN";

            Order addedOrder = repo.AddOrder(newOrder);
        }
        [Test]
        public void LoadOrderTest2()
        {
            //OrderManager orderManager = new OrderManager(new FileOrderRepo(@"C:\Users\mike\Downloads\SampleData\Orders6292021.txt"), new FileProductRepo(), new FileTaxRepo());
            FileOrderRepo repo = new FileOrderRepo(@"C:\Users\mike\Downloads\TestData\Orders6292021.txt");
            Order loadOrder = new Order();
            DateTime dt = DateTime.Parse("06/29/2021");

            loadOrder = repo.LoadOrder(dt, "3");
            Assert.AreEqual(loadOrder.customerName, "Silvio");


        }

        [Test]
        public void updateOrderTest()
        {
            FileOrderRepo repo = new FileOrderRepo(@"C:\Users\mike\Downloads\TestData\Orders6292021.txt");
            Order editedOrder = new Order();
            editedOrder.tax = new Tax();
            editedOrder.product = new Product();
            DateTime dt = DateTime.Parse("06/29/2021");
            editedOrder.orderDate = dt;
            editedOrder = repo.LoadOrder(dt, "4");
            editedOrder.customerName = "Carmine";
            editedOrder.area = 200;
            editedOrder.tax.StateAbbr = "MI";
            editedOrder.product.ProductType = "Tile";

            Order writtenOrder = repo.UpdateOrder(editedOrder);

            writtenOrder = repo.LoadOrder(dt, "4");

            Assert.AreEqual(writtenOrder.customerName, "Carmine");
            Assert.AreEqual(writtenOrder.orderNumber, 4);
        }
        [Test]
        public void ReadAllByDateTest()
        {
            List<Order> orders = new List<Order>();
            FileOrderRepo repo = new FileOrderRepo(@"C:\Users\mike\Downloads\TestData\Orders6292021.txt");
            DateTime dt = DateTime.Parse("06/29/2021");

            orders = repo.ReadAllByDate(dt);

            Assert.AreEqual(orders[0].customerName, "Molly");
            Assert.AreEqual(orders[1].customerName, "Newman");
            Assert.AreEqual(orders[2].customerName, "Silvio");
            Assert.AreEqual(orders[3].customerName, "Carmine");
            //Assert.AreEqual(orders[4].customerName, "Ross");
        }

        [Test]
        public void DeleteOrderTest()
        {
            FileOrderRepo repo = new FileOrderRepo(@"C:\Users\mike\Downloads\TestData\Orders6292021.txt");
            DateTime dt = DateTime.Parse("06/29/2021");
            repo.DeleteOrder(dt, "5");
            Order retrieveOrder = repo.LoadOrder(dt, "5");

            Assert.IsNull(retrieveOrder);
        }
        [Test]
        public void addOrderTest()
        {
            FileOrderRepo repo = new FileOrderRepo(@"C:\Users\mike\Downloads\TestData\Orders6292021.txt");
            DateTime dt = DateTime.Parse("06/29/2021");

            Order newOrder = new Order();
            newOrder.tax = new Tax();
            newOrder.product = new Product();
            newOrder.customerName = "Ross";
            newOrder.area = 150;
            newOrder.product.ProductType = "Carpet";
            newOrder.tax.StateAbbr = "IN";

            Order addedOrder = repo.AddOrder(newOrder);
            //int ordNumber = repo.findOrderNumberForDisplay(newOrder);
            Order loadOrder = repo.LoadOrder(dt, "5");

            Assert.AreEqual(loadOrder.customerName, "Ross");
        }
        

    }
}
