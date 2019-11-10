using System;

namespace _5780lesson2
{
    struct MyStruct
    {
        public int f1;
        public string f2;
    }

    class MyClass
    {
        public static Random rnd = new Random(DateTime.Now.Millisecond);

        public int Number3;
        int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public DateTime Date
        {
            get
            {
                return DateTime.Now;
            }
        }

        public int Number2 { set; get; }

        public void func1(ref MyClass obj)
        {
            Console.WriteLine(obj.Number);
            obj = new MyClass() { Number = 1, Number2 = 2, Number3 = 3, number = 10 };
        }
        public void func2(out MyClass obj)
        {
            //Console.WriteLine(obj.Number);
            obj = new MyClass() { Number = 1, Number2 = 2, Number3 = 3, number = 10 };
            Console.WriteLine(obj.Number);
        }

        public static int Max(int first, int second, params int[] rest)
        {
            int max = first > second ? first : second;
            foreach (var num in rest)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }

        /// <summary>
        /// Find minimum between two number
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns>good value</returns>
        public static int Min(int first, int second)
        {
            return first < second ? first : second;
        }

        public static void fufu(int p1, int p2=8)
        {
            Console.WriteLine("{0},{1}", p1, p2);
        }

        override public string ToString()
        {
            return "test";
        }

        public MyClass() { }

        public static explicit operator MyClass(int number)
        {
            return new MyClass() { Number = number };
        }
    }

    /// <summary>
    /// The best program in the world
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MyStruct str = new MyStruct();
            str.f1 = 8;
            str.f2 = "Yossi";
            object[] obj = new object[1];
            obj[0] = str;
            Console.WriteLine(obj[0]);

            MyClass obj2 = new MyClass();
            obj2.Number = 8;

            Console.WriteLine(obj2.Date);

            MyClass obj3 = new MyClass() { Number3 = 2, Number = 1 };

            int[] numbers = new int[10];
            int[] numbers2 = new int[] { 1, 2, 3, 4, 5 };

            int[,,] arr3D = new int[,,]
            {
                {{1,2,3 }, {4,5,6 } },
                {{7,8,9 }, {1,3,6 } },
                {{4,8,4 }, {2,5,7 } },
                {{7,2,6 }, {1,1,1 } }
            };

            int[][] arrOfArrays;
            arrOfArrays = new int[10][];
            for (int i = 0; i < arrOfArrays.Length; ++i)
            {
                arrOfArrays[i] = new int[i + 1];
            }

            int[][,][][,,] blabla;

            MyClass obj4 = new MyClass() { Number = 9, Number2 = 9, Number3 = 9 };
            // Console.WriteLine(obj4.Number);
            obj2.func1(ref obj4);
            Console.WriteLine(obj4.Number);

            MyClass obj5;
            obj2.func2(out obj5);

            Console.WriteLine(MyClass.Max(3, 4, 9, 3, 6));

            Console.WriteLine(MyClass.Min(second: 8, first: 1));

            MyClass.fufu(1);
            MyClass.fufu(2, 3);

            int[] nums = new int[10];
            for (int i = 0; i < nums.Length; ++i)
            {
                nums[i] = MyClass.rnd.Next(2,10);
            }
            foreach (int num in nums)
                Console.Write(" " + num);
            Console.WriteLine();

            Console.WriteLine(obj2);

            MyClass obj8 = (MyClass)5;
        }
    }
}
