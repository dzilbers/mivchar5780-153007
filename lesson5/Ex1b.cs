using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    class Ex1b
    {
        static void Main1b(string[] args)
        {
            Printer1 printer = new Printer1();
            User1b u1 = new User1b(printer);
            User1b u2 = new User1b(printer);
            Console.WriteLine("Please enter pages to print:");
            int x = int.Parse(Console.ReadLine());
            printer.Print(x);
        }
    }
}
