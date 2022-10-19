using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Models;

namespace FM.BLL.Responses
{
    public class OrderEditResponse:Response
    {
        public Order order { get; set; }
    }
}
