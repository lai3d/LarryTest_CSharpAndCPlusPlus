using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * If you do implement extension methods for a given type, remember the followingpoints:
 * 
1. An extension method will never be called if it has the same signature as a method defined in the type.

2. Extension methods are brought into scope at the namespace level. 
    For example, if you have multiple static classes that contain extension methods in a single namespace named Extensions, 
    they will all be brought into scope by the using Extensions; directive.
 */

/// <summary>
/// Extension Methods (C# Programming Guide)
/// https://msdn.microsoft.com/en-us//library/bb383977.aspx
/// </summary>
/// <remarks>Need to compare this with Apple Swift extention</remarks>
namespace _07_Extentions
{
    using ExtensionMethods;

    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 10, 45, 15, 39, 21, 26 };
            var result = ints.OrderBy(g => g);
            foreach (var i in result)
            {
                System.Console.Write(i + " ");
            }

            //=========================================

            string s = "Hello Extension Methods";
            int count = s.WordCount();
            Console.WriteLine("WordCount() : " + count);
        }
        // 10 15 21 26 39 45 WordCount() : 3
    }
}

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}


