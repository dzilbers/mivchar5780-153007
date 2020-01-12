using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    class User
    {
        private static int counter = 0;
        private int number;
        Printer myPrinter;
        public User(Printer printer)
        {
            number = ++counter;
            myPrinter = printer;
            printer.PageOver += myPageOver;
        }

        private void myPageOver(object source, PrinterEventArgs args)
        {
            Console.WriteLine($"User {number}: page over in printer {source}");
        }
    }
}
