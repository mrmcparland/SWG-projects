using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Controller;

namespace FM.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            FMController controller = new FMController();
            controller.Run();
        }
    }
}
