using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace lesson4
{
    class MyClass
    {
        public int Id;
        public string Name;
    }

    public delegate int MyDelegate(int counter);
    
    class Program
    {
        static MyDelegate doIt = null;
        
        static int func1(int cntr)
        {
            Console.WriteLine("func1");
            return 1;
        }
        static int func2(int cntr)
        {
            Console.WriteLine("func2");
            return 2;
        }
        static int func3(int cntr)
        {
            Console.WriteLine("func3");
            return 3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //MyClass obj = new MyClass();
            //Type metaData1 = obj.GetType();
            //Type metaData2 = typeof(MyClass);
            ////Type metaData3 = typeof(obj);

            //PrintInfo("", typeof(MyClass));
            //Console.WriteLine("-----------------------------------");
            //var anonymousObject = new { Id = 2222, Name = "Yossi" };
            //PrintInfo("", anonymousObject.GetType());
            //Console.WriteLine("-----------------------------------");

            //var obj1 = new { Id = 2222, Name = "Yossi", Age = 2 };
            //var obj2 = new { Id = 2222, Name = "Yossi", Age = 2 };
            //PrintInfo("", obj1.GetType());
            //PrintInfo("", obj2.GetType());
            //Console.WriteLine("== " + (obj1 == obj2));
            //Console.WriteLine("Equals " + (obj1.Equals(obj2)));
            //Console.WriteLine("HashCode " + (obj1.GetHashCode() == obj2.GetHashCode()));


            //string str = "123";
            //int i = str.ToInt();
            //int j = "123".ToInt();

            //DateTime.Now.ToStringProperty();
            //1.ToStringProperty();
            //1.5.ToStringProperty();

            //int b = 8;
            //int? a = b;
            //a = null;
            ////b = (int)a;
            ////b = null;
            //b = a ?? 10;
            //Console.WriteLine("a=" + a + "; b=" + b);


            //int i = Int32.Parse("Dani");

            //doIt = null;
            //doIt = func1;
            //doIt += func2;

            //Console.WriteLine("-------------------");
            //Console.WriteLine(doIt(10));

            //Console.WriteLine("-------------------");
            //foreach (MyDelegate d in doIt.GetInvocationList())
            //{
            //    Console.WriteLine(d.Method);
            //    Console.WriteLine(d(15));
            //}
            //int abc = ((MyDelegate)doIt.GetInvocationList()[1])(11);

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (int num in numbers.FindAll(even))
            {
                Console.Write("" + num + "; ");
            }
            Console.WriteLine();

            //myFunction += func1;
            //myFunction += func2;

            //MyDelegate del;
            //del = func1;
            //del += func2;
            //del += func3;

            //int result = del(11);

            //Console.WriteLine(result);
        }

        static Func<int, int> myFunction = null;

        static bool even(int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        ///    Print the reflection info about a Type
        /// </summary>
        /// <param name="suffix">Indentation</param>
        /// <param name="type">typeof of the Type </param>
        static void PrintInfo(string suffix, Type type)
        {
            Console.WriteLine(suffix + "Type Name: " + type.Name);
            Console.WriteLine(suffix + "Base Type: ");
            if (type.BaseType == null)
                Console.WriteLine(suffix + suffix + "None");
            else
                PrintInfo(suffix + "  ", type.BaseType);
            Console.WriteLine(suffix + "Member Info:");
            MemberInfo[] members = type.GetMembers();
            foreach (var item in members)
                Console.WriteLine(suffix + "name: {0,-15} type: {2,-11} in: {1}",
                                  item.Name, item.DeclaringType.Name, item.MemberType);
        }
    }

    static class MyTools
    {
        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }

        public static void ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetProperties())
                str += "\n" + item.Name + ": " + item.GetValue(t, null);
            Console.WriteLine(str);
        }

    }

}
