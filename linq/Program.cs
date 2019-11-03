using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Program
    {
        static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        static void Main(string[] args)
        {
            var q1 = from n in numbers
                     where n % 2 == 1
                     select n / 2;

            foreach (var i in q1)
                Console.Write(" " + i);
            Console.WriteLine();

            numbers[4] = 10;

            foreach (var i in q1)
                Console.Write(" " + i);
            Console.WriteLine();
            Console.WriteLine("Square mean: " + q1.Average(i => i * i));
            Console.WriteLine("Mean: " +
                (from n in numbers
                 where n % 2 == 1
                 select n / 2).Average());

            foreach (var obj in Enumerable.Repeat(new { Age = 2 }, 5))
                Console.WriteLine(obj.Age);

            var list1 = Enumerable.Repeat(
                new { Age = 2, Name = "Cohen" },
                5).ToList();
        }
    }
}
