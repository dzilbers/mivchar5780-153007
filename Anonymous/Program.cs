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
        public int? Id;
        public string Name;
        public override string ToString()
        {
            return "{ Id = " + Id + ", Name = \"" + Name + "\" }";
        }
    }

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
        static void Main(string[] args)
        {
            var lect1 = new { ID = 29, Name = "Avrumi" };
            //Console.WriteLine(lect1.Name);
            //Console.WriteLine(lect1);
            //Console.WriteLine(lect1.GetType().Name);
            //var more = new { Number = 1, Index = 0 };
            //Console.WriteLine(more.GetType().Name);
            //var nully = new { };
            //Console.WriteLine(nully.GetType().Name);
            var lect2 = new { ID = 29, Name = "Avrumi" };
            //var lect3 = new { Name = true, ID = 32 };
            //Console.WriteLine(lect2.GetType().Name);
            //Console.WriteLine(lect3.GetType().Name);
            Console.WriteLine(lect1 == lect2);
            Console.WriteLine("Lect1 hash: " + lect1.GetHashCode());
            Console.WriteLine("Lect2 hash: " + lect2.GetHashCode());
            Console.WriteLine(lect1.Equals(lect2));

            //PrintInfo("", typeof(MyClass));
            //Console.WriteLine("--------------------------------");
            //var lecturer = new { Id = 29, Name = "Avrumi" };
            //PrintInfo("", lecturer.GetType());
            //Console.WriteLine("--------------------------------");

            int i = "123".ToInt();

            //MyClass obj1 = new MyClass() { Id = 5, Name = "Israel" };
            //Console.WriteLine(obj1);
            //MyClass obj2 = (MyClass)obj1.Clone();
            //Console.WriteLine(obj2);
            //Console.WriteLine(obj1 == obj2);
            //Console.WriteLine(obj1.Name == obj2.Name);

            DateTime.Now.ToStringProperty();

            MyClass nullo = new MyClass();
            Console.WriteLine(nullo);
            Console.WriteLine(nullo.Id ?? 999);
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
