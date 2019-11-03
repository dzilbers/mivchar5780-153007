using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    class Ex1c
    {
        static void Main1c(string[] args)
        {
            Printer1 printer = new Printer1();
            User1b u1 = new User1b(printer);
            User1b u2 = new User1b(printer);
            printer.PageOver();
        }
    }
}
