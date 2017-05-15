using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Explicit Interface Implementation (C# Programming Guide) 
 * 
 * https://docs.microsoft.com/en-us/dotnet/articles/csharp/programming-guide/interfaces/explicit-interface-implementation
 * 
 * **/

namespace _13_Interfaces_0
{
    interface IControl
    {
        void Paint();
    }
    interface ISurface
    {
        void Paint();
    }
    class SampleClass : IControl, ISurface
    {
        // Both ISurface.Paint and IControl.Paint call this method. 
        public void Paint()
        {
            Console.WriteLine("Paint method in SampleClass");
        }
    }

    public class SampleClass2 : IControl, ISurface
    {
        void IControl.Paint()
        {
            System.Console.WriteLine("IControl.Paint");
        }
        void ISurface.Paint()
        {
            System.Console.WriteLine("ISurface.Paint");
        }
    }

    interface ILeft
    {
        int P { get; }
    }
    interface IRight
    {
        int P();
    }

    class Middle : ILeft, IRight
    {
        public int P() { return 0; }
        int ILeft.P { get { return 0; } }

        //int P { get { return 0; } } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            SampleClass sc = new SampleClass();
            IControl ctrl = (IControl)sc;
            ISurface srfc = (ISurface)sc;

            // The following lines all call the same method.
            sc.Paint();
            ctrl.Paint();
            srfc.Paint();

            SampleClass2 obj = new SampleClass2();
            //obj.Paint();  // Compiler error.

            IControl c = (IControl)obj;
            c.Paint();  // Calls IControl.Paint on SampleClass.

            ISurface s = (ISurface)obj;
            s.Paint(); // Calls ISurface.Paint on SampleClass.
        }
    }
}
