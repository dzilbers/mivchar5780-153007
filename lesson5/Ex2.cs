using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
    {
        class Ex2
        {
            static void Main(string[] args)
            {
                Printer2 printer = new Printer2();
                User2 u1 = new User2(printer);
                User2 u2 = new User2(printer);
                Console.WriteLine("Please enter pages to print:");
                int x = int.Parse(Console.ReadLine());
                printer.Print(x);
            }
        }
    }

