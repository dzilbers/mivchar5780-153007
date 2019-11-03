using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    public class User1b
    {
        private static int counter = 0;
        private int number;
        Printer1 myPrinter;
        public User1b(Printer1 printer)
        {
            number = ++counter;
            myPrinter = printer;
            printer.PageOver += myPageOver;
        }
        private void myPageOver()
        {
            Console.WriteLine("User " + number + ": Page Over!!!");
        }
    }

}
