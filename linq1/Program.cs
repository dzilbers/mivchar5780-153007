using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dict1 = new List<string>
                { "dani",
                  "david",
                  "yossi"};

            IEnumerable<IGrouping<char, string>> dict2 = null;
            foreach (var g in dict2)
            {
                Console.WriteLine(g.Key);
            }
        }
    }
}
