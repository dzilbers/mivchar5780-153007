using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Anonymous
{

    class MyClass : IClonable
    {
        /// <summary>
        /// asdasd
        /// </summary>
        public int/*?*/ Id;
        public string Name;
        public override string ToString()
        {
            return "{ Id = " + Id + ", Name = \"" + Name + "\" }";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    static class MyTools
    {
        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }

        public static IClonable Clone(this IClonable obj)
        {
            IClonable newObj = (IClonable)Activator.CreateInstance(obj.GetType());
            foreach (var field in obj.GetType().GetFields())
                field.SetValue(newObj, field.GetValue(obj));
            return newObj;
        }

        /// <summary>
        /// fg sdfkdflk jdf;lhdf 
        /// sd
        /// ghdf
        /// dfhh
        /// h
        /// </summary>
        /// <typeparam name="T"> sdflk gsdklfgj </typeparam>
        /// <param name="t">asd dafg </param>
        public static void ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (var item in t.GetType().GetProperties())
                str += "\n" + item.Name + ": " + item.GetValue(t);
            Console.WriteLine(str);
        }
    }

    interface IClonable { }

    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //var lect1 = new { ID = 29, Name = "Avrumi" };
            //Console.WriteLine(lect1.Name);
            //Console.WriteLine(lect1);
            //Console.WriteLine(lect1.GetType().Name);
            //var more = new { Number = 1, Index = 0 };
            //Console.WriteLine(more.GetType().Name);
            //var nully = new { };
            //Console.WriteLine(nully.GetType().Name);
            //var lect2 = new { ID = 29, Name = "Avrumi" };
            //var lect3 = new { ID = 32, Name = true };
            //Console.WriteLine(lect2.GetType().Name);
            //Console.WriteLine(lect3.GetType().Name);
            //Console.WriteLine(lect1 == lect2);
            //Console.WriteLine("Lect1 hash: " + lect1.GetHashCode());
            //Console.WriteLine("Lect2 hash: " + lect2.GetHashCode());
            //Console.WriteLine(lect1.Equals(lect2));

            //PrintInfo("", typeof(MyClass));
            //Console.WriteLine("--------------------------------");
            //var lecturer = new { Id = 29, Name = "Avrumi" };
            //PrintInfo("", lecturer.GetType());
            //Console.WriteLine("--------------------------------");

            //int i = "123".ToInt();

            MyClass obj1 = new MyClass() { Id = 5, Name = "Israel" };
            Console.WriteLine(obj1);
            //var obj2 = new { Id = 5, Name = "Israel" };
            //PrintInfo("", typeof(MyClass));
            //PrintInfo("", obj2.GetType());
            MyClass obj2 = (MyClass)obj1.Clone();
            Console.WriteLine(obj2);
            Console.WriteLine(obj1 == obj2);
            Console.WriteLine(obj1.Name == obj2.Name);

            //DateTime.Now.ToStringProperty();
            //1.ToStringProperty();

            //MyClass nullo = new MyClass();
            //Console.WriteLine(nullo);
            //Console.WriteLine(nullo.Id ?? 999);

            int? a = null;
            int i = 3;
            a = i;
            i = (int)a;
            i = a ?? 0;
        }

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
}
