#define JACOB
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace attributes
{

    //[DebuggerDisplay("Name = {firstName,nq}, Id = {id,h}", Name = "Our best person", Type ="Person")]
    class Person
    {
        [DebuggerDisplay("{id}", Name = "Id Number", Type = "Israeli Id")]
        public int id;
        public string firstName;
        public string lastName;
        //[Obsolete("Stop using this function, use blabla instead of it", true)]
        [Conditional("JACOB")]
        public void Func(/*[DefaultParameterValue(5)]int parm*/)
        {
            Console.WriteLine(/*parm*/"test");
        }
        public override string ToString()
        {
            //throw new NullReferenceException();
            return "Id=" + id + "; Name=" + firstName + "; Family=" + lastName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person() { id = 111, firstName = "Yossi", lastName = "Levy" };
            Console.WriteLine(person);
            person.Func();
            Console.ReadKey();
        }
    }
}
