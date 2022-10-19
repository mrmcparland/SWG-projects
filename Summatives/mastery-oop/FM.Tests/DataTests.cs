using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Models;
using FM.Data;



using NUnit.Framework;

namespace FM.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase(1,"6/21/2021")]
        public void CanLoadOrder(int orderNumber, string orderDate)
        {
            Order order = new Order();
            TestOrderRepo testOrderRepo = new TestOrderRepo();

            order = testOrderRepo.LoadOrder(DateTime.Parse("6/21/2021"),"1");
            Assert.IsNotNull(order);
            Assert.AreEqual(orderNumber,1);
        }
        //public void CalcOrder(decimal area, decimal taxRate, decimal matlCostSqFt, decimal laborCostSqFt)
    }
}
