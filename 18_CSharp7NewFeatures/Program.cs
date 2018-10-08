using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_CSharp7NewFeatures {
    class Program {

        static void GetValue(out int outVal) {
            outVal = 12;
        }

        static int Fibonacci (int x) {
            if (x < 0) throw new ArgumentException ("Less negativity please!", nameof (x));
            return Fib (x).current;

            (int current, int previous) Fib (int i) {
                if (i == 0) return (1, 0);
                var (p, pp) = Fib (i - 1);
                return (p + pp, p);
            }
        }

        static void Main (string[] args) {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine ("Hello World!");
            //Console.ReadKey ();

            GetValue (out int val);

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }

    class Person {
        public string Name { get; }
        public Person (string name) => Name = name ?? throw new ArgumentNullException (nameof (name));
        public string GetFirstName () {
            var parts = Name.Split (' ');
            return (parts.Length > 0) ? parts[0] : throw new InvalidOperationException ("No name!");
        }
        public string GetLastName () => throw new NotImplementedException ();
    }


}
