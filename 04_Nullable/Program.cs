using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _04_Nullable
{
    class Program
    {
        public class Example
        {
            public int? MyMethod()
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
            Type t = typeof(Example);
            MethodInfo mi = t.GetMethod("MyMethod");
            Type retval = mi.ReturnType;
            Console.WriteLine("Return value type ... {0}", retval);
            Type answer = Nullable.GetUnderlyingType(retval);
            Console.WriteLine("Underlying type ..... {0}", answer);

            /**
             * 
             Return value type ... System.Nullable`1[System.Int32]
             Underlying type ..... System.Int32

             * */
        }
        /*
        This code example produces the following results:

        Return value type ... System.Nullable`1[System.Int32]
        Underlying type ..... System.Int32

        */
    }
}
