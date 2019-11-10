using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    abstract class Dad
    {
        public Dad() { Console.WriteLine("Dad"); }
        public Dad(int whatEver) { Console.WriteLine("Dad({0})", whatEver); }
        public abstract void F(); // { Console.WriteLine("Dad.f()"); }
    }

    class Son : Dad
    {
        public Son(int num) : base(num)
        {

        }
        public override void F() { Console.WriteLine("Son.f()"); }
    }

    class OtherSon : Dad {
        public override void F() { Console.WriteLine("OtherSon.f()"); }
    }

    class MyClass : IComparable<MyClass>
    {
        int number;
        public int Number { get { return this.number; } }
        public int CompareTo(MyClass other)
        {
            return this.number - other.number;
        }

        public static implicit operator MyClass(int n) { return new MyClass { number = n }; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Son o1 = new Son(5);
            Dad o2 = o1;
            Dad o3 = new OtherSon();
            //o1 = (Son)o3;

            o1 = o3 as Son;

            Console.WriteLine(o1);

            OtherSon o4 = new OtherSon();
            Console.WriteLine("======================");
            o2.F();
            o4.F();
            o3.F();

            MyClass[] myObjects = { 5, 4, 3, 2, 1 };

            Array.Sort(myObjects);
            foreach (var o in myObjects)
                Console.Write(" " + o.Number);
            Console.WriteLine();
        }
    }
}
