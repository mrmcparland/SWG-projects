using BookList.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList
{
    class Program
    {
        static void Main(string[] args)
        {
            BookController controller = new BookController();
            controller.Run();
        }
    }
}
