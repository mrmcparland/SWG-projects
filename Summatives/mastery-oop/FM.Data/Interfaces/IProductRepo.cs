using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Interfaces
{
    public interface IProductRepo
    {
        List<string> ReadByID(string productType);
        List<string> ReadAll();
    }
}
