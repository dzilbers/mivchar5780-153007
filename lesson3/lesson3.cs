using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3
{
    interface IDoing : IComparable<int>
    {
        void doSomething();
    }

    abstract class Dad { }

    class MyClass : Dad, IDoing, IEnumerable<int>
    {
        int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public int CompareTo(int obj)
        {
            throw new NotImplementedException();
        }

        public void doSomething()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return (IEnumerator<int>)array.GetEnumerator();
            //return new MyEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
            //return new MyEnumerator(this);
        }

        class MyEnumerator : IEnumerator<int>
        {
            private MyClass coll;
            internal MyEnumerator(MyClass me)
            {
                coll = me;
            }

            private int index = -1;
            public /*object*/ int Current {
                get { return coll.array[index]; }
            }

            public bool MoveNext()
            {
                return ++index < coll.array.Length;
            }

            object IEnumerator.Current => coll.array[index];

            public void Dispose() { }

            public void Reset() { }
        }
    }

    class MyClass<U> where U : new()
    {
        U field;
        public U f()
        {
            U temp = new U();
            field = default(U);
            return temp;
        }

    }
    class lesson3
    {
        static IEnumerable<int> func() //    פונקציה שמחזירה אוסף של מספרים
        {
            yield return 25;
            yield return 36;
        }

        static IEnumerable<int> func1() //    פונקציה שמחזירה אוסף של מספרים
        {
            for (int i = 1; i < 20; ++i)
            {
                Console.WriteLine("func1: " + i);
                yield return i;
            }
        }

        static IEnumerable<int> ArithSeq(int a0, int d)
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
            //MyClass coll = new MyClass();

            //IEnumerator<int> iter = coll.GetEnumerator();
            //while (iter.MoveNext())
            //    Console.WriteLine(iter.Current);

            //foreach(var i in coll)
            //    Console.WriteLine(i);

            //foreach (var i in func1())
            //{
            //    if (i > 10) break;
            //    Console.WriteLine("Loop" + i);
            //}

            int counter = 0;
            foreach (int a in ArithSeq(2, 4))
            {
                if (++counter >= 10) break;
                Console.Write(" " + a);
            }
            Console.WriteLine();
        }
    }
}
