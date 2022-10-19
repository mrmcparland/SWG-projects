using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FM.Data;

namespace FM.BLL
{
    public class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "Test":
                    return new OrderManager(new TestOrderRepo(), new TestProductRepo(), new TestTaxRepo() );
                case "File":
                    return new OrderManager(new FileOrderRepo(), new FileProductRepo(), new FileTaxRepo());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
