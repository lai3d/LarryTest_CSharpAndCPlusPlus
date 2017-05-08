//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _11_GC_Re​Register​For​Finalize
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//        }
//    }
//}

using System;

namespace ReRegisterForFinalizeExample
{
    class MyMainClass
    {
        static void Main()
        {
            // Create a MyFinalizeObject.
            MyFinalizeObject mfo = new MyFinalizeObject();

            // Release the reference to mfo.
            mfo = null;

            Console.WriteLine("After null assigned!");

            // Force a garbage collection.
            GC.Collect();

            Console.WriteLine("After first GC Collect!");

            // At this point mfo will have gone through the first Finalize.
            // There should now be a reference to mfo in the static
            // MyFinalizeObject.currentInstance field.  Setting this value
            // to null and forcing another garbage collection will now
            // cause the object to Finalize permanently.
            MyFinalizeObject.currentInstance = null;

            Console.WriteLine("After null assigned to currentInstance!");

            GC.Collect();

            Console.WriteLine("After second GC Collect!");
        }
        /**           Different between debug and release
         * 
         C:\Develop\LarryTest\11_GC_Re​Register​For​Finalize\bin\Debug>_11_GC_Re​Register​For​Finalize.exe
            After null assigned!
            After first GC Collect!
            After null assigned to currentInstance!
            First finalization
            After second GC Collect!
            Second finalization


        C:\Develop\LarryTest\11_GC_Re​Register​For​Finalize\bin\Release>_11_GC_Re​Register​For​Finalize.exe
            After null assigned!
            After first GC Collect!
            First finalization
            After null assigned to currentInstance!
            After second GC Collect!
            Second finalization
        */
    }

    class MyFinalizeObject
    {
        public static MyFinalizeObject currentInstance = null;
        private bool hasFinalized = false;

        ~MyFinalizeObject()
        {
            if (hasFinalized == false)
            {
                Console.WriteLine("First finalization");

                // Put this object back into a root by creating
                // a reference to it.
                MyFinalizeObject.currentInstance = this;

                // Indicate that this instance has finalized once.
                hasFinalized = true;

                // Place a reference to this object back in the
                // finalization queue.
                GC.ReRegisterForFinalize(this);
            }
            else
            {
                Console.WriteLine("Second finalization");
            }
        }
    }
}