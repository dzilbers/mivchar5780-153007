using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    class Ex1a
    {
        static void Main1a(string[] args)
        {
            Printer1 printer = new Printer1();
            User1a u1 = new User1a(printer);
            User1a u2 = new User1a(printer);
            Console.WriteLine("Please enter pages to print:");
            int x = int.Parse(Console.ReadLine());
            printer.Print(x);
        }
    }
}
