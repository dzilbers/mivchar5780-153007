using System;
using System.Collections;
using System.Collections.Generic;

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

        public T G<T, U>(U parm) { return default(T); }
    }

    class OtherSon : Dad
    {
        public override void F() { Console.WriteLine("OtherSon.f()"); }
    }

    class MyClass : IComparable<MyClass>
    {
        int number;
        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public int CompareTo(MyClass other)
        {
            return this.number - other.number;
        }

        public static implicit operator MyClass(int n) { return new MyClass { number = n }; }

        public override string ToString()
        {
            return " " + number;
        }
    }

    class MyCollection : IEnumerable<MyClass>
    {
        MyClass[] objects = new MyClass[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //public IEnumerator<MyClass> GetEnumerator()
        //{
        //    IEnumerable<MyClass> temp = objects;
        //    return temp.GetEnumerator();
        //    //return new Enumerator(this);
        //}
        public IEnumerator<MyClass> GetEnumerator()
        {
            foreach (var elem in objects)
                yield return elem;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return objects.GetEnumerator();
            //return new Enumerator(this);
        }

        //class Enumerator : IEnumerator<MyClass>
        //{
        //    MyCollection coll;
        //    int current = -1;

        //    public Enumerator(MyCollection myCollection)
        //    {
        //        this.coll = myCollection;
        //    }

        //    object IEnumerator.Current
        //    {
        //        get { return coll.objects[current]; }
        //    }

        //    MyClass IEnumerator<MyClass>.Current
        //    {
        //        get { return coll.objects[current]; }
        //    }

        //    public void Dispose()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public bool MoveNext()
        //    {
        //        return ++current < coll.objects.Length;
        //    }

        //    public void Reset() { }
        //}

    }

    class Program
    {

        public static IEnumerable<int> ArithSeq(int a0, int d)
        {
            yield return a0;
            while (true)
            {
                a0 += d;
                yield return a0;
            }
        }

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
            {
                Console.Write(" " + o.Number);
            }

            Console.WriteLine();

            //Console.WriteLine(o1.G<char, int>(5));

            MyClass o5 = 10;
            IComparable<MyClass> o6 = o5;

            Console.WriteLine(o6.CompareTo(new MyClass() { Number = 1 }));

            MyCollection coll = new MyCollection();

            Console.WriteLine("###################");
            IEnumerator iter = coll.GetEnumerator();
            while (iter.MoveNext())
            {
                Console.Write(iter.Current);
            }
            Console.WriteLine();
            Console.WriteLine("###################");
            foreach (var element in coll)
            {
                if (element.Number > 5) break;
                Console.Write(element.Number);
            }

            Console.WriteLine();


            int counter = 15;
            foreach (int a in ArithSeq(1, 2))
            {
                if (--counter == 0) break;
                Console.Write(" " + a);
            }
            Console.WriteLine();
        }
    }
}
