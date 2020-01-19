using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace plinq
{
    class Program
    {
        static Random rnd = new Random(DateTime.Now.Millisecond);
        static Stopwatch watch = new Stopwatch();
        static bool Compute(int n)
        {
            for (int i = 0; i < 100000; ++i) ;
            return n % 2 == 0;
        }
        static void Main(string[] args)
        {
            var list = Enumerable.Range(1, 10000);// new List<int>();
            //for (int i = 0; i < 10000; ++i)
            //    list.Add(rnd.Next(10, 100));

            var req = from num in list.AsParallel().AsOrdered()
                      where Compute(num)
                      select num;

            watch.Start();
            var result = req.ToList();
            watch.Stop();
            Console.WriteLine($"Milliseconds: {watch.ElapsedMilliseconds}");
            Console.WriteLine("Press any key to print");
            Console.ReadKey();
            int count = 0;
            foreach (var num in result)
            {
                Console.Write($"{num} ");
                count = (count + 1) % 25;
                if (count == 0)
                    Console.WriteLine();
            }
        }
    }
}
