using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Data.Interfaces;
using FM.Models;

namespace FM.Data
{
    public class TestProductRepo : IProductRepo
    {
        public List<string> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<string> ReadByID(string productType)
        {
            throw new NotImplementedException();
        }
    }
}
