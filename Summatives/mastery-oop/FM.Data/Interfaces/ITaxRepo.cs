using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Interfaces
{
    public interface ITaxRepo
    {
        List<string> ReadByID(string stateAbbr);
        List<string> ReadAll();
    }
}
