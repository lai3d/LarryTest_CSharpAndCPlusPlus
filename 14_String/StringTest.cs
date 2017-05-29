using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_String
{
    class StringTest
    {
        static void Main(string[] args)
        {
            string query = @"SELECT foo, bar
FROM table
WHERE id = 42";

            Console.WriteLine(query);
        }
    }

//SELECT foo, bar
//FROM table
//WHERE id = 42

}
