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
                Printer printer = new Printer();
                User u1 = new User(printer);
                User u2 = new User(printer);
                Console.WriteLine("Please enter pages to print:");
                int x = int.Parse(Console.ReadLine());
                printer.Print(x);
            }
        }
    }

