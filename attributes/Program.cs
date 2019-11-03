using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace attributes
{

    [DebuggerDisplay("Name = {firstName}, Id = {id}")]
    class Person
    {
        public int id;
        public string firstName;
        public string lastName;
        public override string ToString()
        {
            // throw new NullReferenceException();
            return "Id=" + id + "; Name=" + firstName + "; Family=" + lastName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person() { id = 111, firstName = "Yossi", lastName = "Levy" };
            Console.WriteLine(person);
            Console.ReadKey();
        }
    }
}
