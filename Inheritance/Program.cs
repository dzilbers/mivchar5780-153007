using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    abstract class Dad
    {
        protected int foo;
        public Dad() { Console.WriteLine("Dad"); }
        public Dad(int whatEver) { Console.WriteLine("Dad({0})", whatEver); }
        public abstract void F(); // { Console.WriteLine("Dad.f()"); }
        public virtual void V() { /* bla bla bla */ }
    }

    class Son : Dad
    {
        private new string foo;
        public Son(int num) : base(num)
        {
            foo = "$" + base.foo; // string.Format("${0}", base.foo);
        }
        public override void F() { Console.WriteLine("Son.f()"); }
        public override void V() { }

        public T G<T, U>(U parm) { return default(T);  }
    }

    class OtherSon : Dad {
        public override void F() { Console.WriteLine("OtherSon.f()"); }
    }

    class MyClass //: IComparable<MyClass>
    {
        int number;
        public int Number { get { return this.number; } }
        //public int CompareTo(MyClass other)
        //{
        //    return this.number - other.number;
        //}

        public static implicit operator MyClass(int n) { return new MyClass { number = n }; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Son o1 = new Son(5);
            Dad o3 = new OtherSon();
            Dad o2 = o1;
            // o1 = o3;
            // o1 = (Son)o3;
            o1 = o3 is Son ? (Son)o3 : null;
            o1 = o3 as Son;

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

            Console.WriteLine(o1.G<char, int>(5));
        }
    }
}
