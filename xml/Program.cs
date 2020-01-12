using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace xml
{
    public class Student
    {
        public int Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {FirstName} {LastName}";
        }
    }

    class Program
    {
        public static List<Student> list = new List<Student>()
        {
            new Student() {Id=1, FirstName = "Avrumi", LastName="Rosenberg"},
            new Student() {Id=2, FirstName = "Israel", LastName="Hartuv"},
            new Student() {Id=3, FirstName = "Yehonathan", LastName="Eliahu"}
        };

        static void Main(string[] args)
        {
            string path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            path += @"\students.xml";
            FileStream fsout = new FileStream(path, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(IEnumerable<Student>));
            xs.Serialize(fsout, list);
            fsout.Close();
            FileStream fsin = new FileStream(path, FileMode.Open);
            var result = (IEnumerable<Student>)xs.Deserialize(fsin);
            fsin.Close();
            foreach (var stud in result)
                Console.WriteLine(stud);
        }
    }
}
