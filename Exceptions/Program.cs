using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        static void Main(string[] args)
        {
            int i = 0;
            try
            {
                i = int.Parse("abc");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ooops" + e.Message);
                throw new MyException("boom", e);
            }
            if (i < 0) throw new MyException("Oh-la-la");
        }
    }

    [Serializable]
    class MyException : Exception, ISerializable
    {
        //[NonSerialized]
        public int SpecialInfo;

        public MyException() : this("")
        {
        }

        public MyException(string msg) : this(msg, null)
        {
        }

        public MyException(string msg, Exception other) : base(msg, other)
        {
            SpecialInfo = 999;
        }

        public MyException(int info) : this("Blabla", null)
        {
            SpecialInfo = info;
        }
    }
}
