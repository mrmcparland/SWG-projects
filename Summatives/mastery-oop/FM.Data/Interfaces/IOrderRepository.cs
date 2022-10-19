using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Models;

namespace FM.Data.Interfaces
{
    public interface IOrderRepository
    {
        Order LoadOrder(DateTime orderDate, string orderNumber);
        Order AddOrder(Order order);
        Order UpdateOrder(Order order);
        Order DeleteOrder(DateTime orderDate, string OrderNumber);
        List<Order> ReadAllByDate(DateTime orderDate);
        int findOrderNumberForDisplay(Order order);



    }
}
