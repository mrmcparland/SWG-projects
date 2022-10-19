using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.BLL.Responses;
using FM.Models;

using FM.Data.Interfaces;


namespace FM.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private IProductRepo _ProductRepository;
        private ITaxRepo _TaxRepository;

        public OrderManager(IOrderRepository orderRepository, IProductRepo productRepo, ITaxRepo taxRepo)
        {
            _orderRepository = orderRepository;
            _ProductRepository = productRepo;
            _TaxRepository = taxRepo;
        }
        private int OrderNumberAssignment(int lastOrderNumber)
        {
            //create repo for order number gen?
            throw new NotImplementedException();
        }
        
        public OrderAddResponse AddOrder(Order order)
        {
            OrderAddResponse response = new OrderAddResponse();

            response.order = _orderRepository.AddOrder(order);
            if (response.order == null)
            {
                response.Success = false;
                response.Message = "Order add failed";
            }
            else
                response.Success = true;
            return response;
        }
        public OrderEditResponse UpdateOrder(Order order)
        {
            OrderEditResponse response = new OrderEditResponse();

            response.order = _orderRepository.UpdateOrder(order);
            if (response.order == null)
            {
                response.Success = false;
                response.Message = "Order edit failed";
            }
            else
                response.Success = true;
            return response;
        }
        public OrderDeleteResponse DeleteOrder(DateTime orderDate, string orderNumber)
        {
            OrderDeleteResponse response = new OrderDeleteResponse();

            response.order = _orderRepository.DeleteOrder(orderDate, orderNumber);
            if (response.order == null)
            {
                response.Success = false;
                response.Message = "Order delete failed";
            }
            else
                response.Success = true;
            return response;
        }

        public AllOrdersResponse ReadAllByDate(DateTime orderDate)
        {
            AllOrdersResponse response = new AllOrdersResponse();

            response.orders = _orderRepository.ReadAllByDate(orderDate);
            if (response.orders == null)
            {
                response.Success = false;
                response.Message = "No orders associated with " + orderDate;
            }
            else
                response.Success = true;
            return response;
        }
        public Order CalcOrdTotal (Order order)
        {
            CalcOrderTotalResponse response = new CalcOrderTotalResponse();
            //brings in prod data
            List<string> prodData = new List<string>();
            prodData = _ProductRepository.ReadByID(order.product.ProductType);
            order.product.CostPerSqFoot = Convert.ToDecimal(prodData[1]);
            order.product.LaborCostPerSqFoot = Convert.ToDecimal(prodData[2]);
            //brings in tax data
            List<string> taxData = new List<string>();
            taxData = _TaxRepository.ReadByID(order.tax.StateAbbr);
            
            order.tax.StateAbbr = taxData[0];
            order.tax.State = taxData[1];
            order.tax.TaxRate = Convert.ToDecimal(taxData[2]);
            //pass in fully completed order

            Order newOrder = new Order();
            newOrder.tax = new Tax();
            newOrder.product = new Product();

            newOrder.orderNumber = order.orderNumber;
            newOrder.orderDate = order.orderDate;
            newOrder.customerName = order.customerName;
            newOrder.area = order.area;
            newOrder.tax.StateAbbr = order.tax.StateAbbr;
            newOrder.product.ProductType = order.product.ProductType;
            newOrder.tax.TaxRate = order.tax.TaxRate;
            newOrder.product.CostPerSqFoot = order.product.CostPerSqFoot;
            newOrder.product.LaborCostPerSqFoot = order.product.LaborCostPerSqFoot;

            //data calc'd from files based on above data
            newOrder.materialCost = order.area * order.product.CostPerSqFoot;
            newOrder.laborCost = order.area * order.product.LaborCostPerSqFoot;
            newOrder.taxSubTotal = ((order.area * order.product.CostPerSqFoot * order.tax.TaxRate) + (order.area * order.product.LaborCostPerSqFoot * order.tax.TaxRate)) / 100;
            newOrder.total = newOrder.materialCost + newOrder.laborCost + newOrder.taxSubTotal;
            //response.order = _orderRepository.CalcnewOrdTotal(order);

            return newOrder;
        }
        public Order CalcEditedOrdResponse(Order order)
        {
            CalcEditedOrdResponse response = new CalcEditedOrdResponse();
            List<string> prodData = new List<string>();
            prodData = _ProductRepository.ReadByID(order.product.ProductType);
            order.product.CostPerSqFoot = Convert.ToDecimal(prodData[1]);
            order.product.LaborCostPerSqFoot = Convert.ToDecimal(prodData[2]);
            //brings in tax data
            List<string> taxData = new List<string>();
            taxData = _TaxRepository.ReadByID(order.tax.StateAbbr);
           
            order.tax.StateAbbr = taxData[0];
            order.tax.State = taxData[1];
            order.tax.TaxRate = Convert.ToDecimal(taxData[2]);
            //pass in fully completed order
            Order editedOrder = new Order();
            editedOrder.tax = new Tax();
            editedOrder.product = new Product();

            //data entered by order creator
            editedOrder.orderNumber = order.orderNumber;
            editedOrder.orderDate = order.orderDate;
            editedOrder.customerName = order.customerName;
            editedOrder.area = order.area;
            editedOrder.tax.StateAbbr = order.tax.StateAbbr;
            editedOrder.product.ProductType = order.product.ProductType;
            editedOrder.tax.TaxRate = order.tax.TaxRate;
            editedOrder.product.CostPerSqFoot = order.product.CostPerSqFoot;
            editedOrder.product.LaborCostPerSqFoot = order.product.LaborCostPerSqFoot;

            //data calc'd from files based on above data
            editedOrder.materialCost = editedOrder.area * editedOrder.product.CostPerSqFoot;
            editedOrder.laborCost = editedOrder.area * editedOrder.product.LaborCostPerSqFoot;
            editedOrder.taxSubTotal = ((editedOrder.area * editedOrder.product.CostPerSqFoot * editedOrder.tax.TaxRate) + (editedOrder.area * editedOrder.product.LaborCostPerSqFoot * editedOrder.tax.TaxRate)) / 100;
            editedOrder.total = editedOrder.materialCost + editedOrder.laborCost + editedOrder.taxSubTotal;
            //response.order = _orderRepository.CalcEditedOrdTotal(order);
            
            return editedOrder;

        }
        public List<string> GenerateStateList()
        {
            List<string> stateList = new List<string>();
            stateList = _TaxRepository.ReadAll();
            return stateList;
        }
        public List<string> GenerateProductList()
        {
            List<string> productList = new List<string>();
            productList = _ProductRepository.ReadAll();
            return productList;
        }

        public Order ReadByID (DateTime dt, string orderNumber)
        {
            Order order = new Order();
            try
            {
                order = _orderRepository.LoadOrder(dt, orderNumber);
            }
            catch(System.NullReferenceException)
            {
                return null;
            }
            
            return order;
        }
        public int displayOrderNumber(Order order)
        {
            int orderNumber = _orderRepository.findOrderNumberForDisplay(order);
            return orderNumber;
        }
    }
}
