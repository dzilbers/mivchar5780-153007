using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{
    public static class Cloning
    {
        public static Clonable Clone(this Clonable original)
        {
            Clonable target1 = (Clonable)original.GetType().GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
            Clonable target2 = (Clonable)Activator.CreateInstance(original.GetType());
            return target2;
        }
    }
}
