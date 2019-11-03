using System;

namespace lesson2
{
    class MyClass
    {
        public int field;
        public int Foo
        {
            get
            {
                return boo + 1;
            }
            set
            {
                boo = value * 2;
            }
        }
        private int boo = 8;

        public int Yossi { get; private set; }

        public override string ToString()
        {
            return "This is me!!!";
        }
        public MyClass(int parm)
        {
            Foo = parm;
            boo = parm;
        }

        public MyClass() { }

        //private bool check;
        public bool Check { get; protected set; }

    }

    struct Yehuda
    {
        public int i, j;
        public Yehuda(int parm)
        {
            i = 1;
            j = 2;
        }
        public void f(out MyClass obj, int number = 0)
        {
            obj = new MyClass();
            obj.Foo = number;
        }

        public int Max(int first, int second, params int[] rest)
        {
            int max = first > second ? first : second;
            foreach (int num in rest)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }

        public int Max(int first, int second)
        {
            int max = first > second ? first : second;
   
            return max;
        }
    }

    enum Weekday { Sun, Mon, Tue, Wed, Thu, Fri, Sat }

    class lesson2
    {
        static void Main(string[] args)
        {
            int i = 3;
            int[] arr = new int[8];
            int[] numbers = new int[] { 1, 2, 4, 8 };
            for (int j = 0; j < numbers.Length; j++)
            {
                Console.WriteLine(numbers[j]);
            }

            foreach (var k in numbers)
            {
                Console.WriteLine(k);
            }

            int[,,] matrix3D = new int[,,]
            {
                {{1,1},{2,2},{3,3}},
                {{1,1},{2,2},{3,3}},
                {{1,1},{2,2},{3,3}},
                {{3,5},{5,6},{7,8}}
            };

            Console.WriteLine(matrix3D[3, 2, 1]);

            int[][] matrix = new int[][]
            {
                new int[] {1,2},
                new int[] {4}
            };
            if (matrix[0] == null)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                Console.WriteLine("Not Empty");
            }

            matrix[0] = new int[] { 1, 2, 3 };

            int[][,][] complexMatrix;

            Console.WriteLine(numbers[0]);
            MyClass obj;// = new MyClass(5);
            MyClass other;// = obj;
            MyClass obj2 = new MyClass() { field = 8 };
            Yehuda ye = new Yehuda(0);
            ye.i = 2;
            ye.j = 3;
            ye.f(out obj);
            Console.WriteLine(ye.Max(1, 2, 3, 4, 5));
            Random r = new Random((int)DateTime.Now.Ticks);

            //Console.WriteLine(obj);
            //Console.WriteLine(ye);

            //MyClass o = new MyClass(2);
            ////o.Check = true;
            ////o.check = false;

            //Weekday day = Weekday.Sun;

            //switch (day)
            //{
            //    case Weekday.Sun:
            //        break;
            //}

            ye.Max(second: 2, first: 3);
        }
    }
}
