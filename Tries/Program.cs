using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stud1 = new Student();
            Student stud2 = (Student)stud1.Clone();
        }
    }
}
