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
        int[] array = new int[10];

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
            return new MyEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        class MyEnumerator : IEnumerator<int>
        {
            private MyClass coll;
            internal MyEnumerator(MyClass me)
            {
                coll = me;
            }

            private int index = -1;
            public int Current {
                get { return coll.array[index]; }
            }

            public bool MoveNext()
            {
                index++;
                return index < coll.array.Length;
            }

            object IEnumerator.Current => index;

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
        static void Main(string[] args)
        {
            MyClass coll = new MyClass();

            IEnumerator<int> iter = coll.GetEnumerator();
            while (iter.MoveNext())
                Console.WriteLine(iter.Current);

            foreach(int i in coll)
                Console.WriteLine(i);

        }
    }
}
