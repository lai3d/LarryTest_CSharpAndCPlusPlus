using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://docs.microsoft.com/en-us/dotnet/api/system.object.finalize?view=netframework-4.7
/// </summary>
namespace _01_Test_Object_Finalize
{
    public class ExampleClass
    {
        Stopwatch sw;

        public ExampleClass()
        {
            sw = Stopwatch.StartNew();
            Console.WriteLine("Instantiated object");
        }

        public void ShowDuration()
        {
            Console.WriteLine("This instance of {0} has been in existence for {1}", this, sw.Elapsed);
        }

        /// <summary>
        /// Also note that the C# example provides a destructor instead of overriding the Finalize method.
        /// </summary>
        ~ExampleClass()
        {
            Console.WriteLine("Finalizing object");
            sw.Stop();
            Console.WriteLine("This instance of {0} has been in existence for {1}", this, sw.Elapsed);
        }
    }

    class ObjectFinalize
    {
        static void Main(string[] args)
        {
            ExampleClass ex = new ExampleClass();
            ex.ShowDuration();
        }
    }
}
