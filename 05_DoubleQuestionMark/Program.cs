using LINQPad;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// http://stackoverflow.com/questions/11412639/double-question-marks-vs-if-when-assigning-same-var
/// </summary>
namespace _05_DoubleQuestionMark
{
    class Program
    {
        static void Main(string[] args)
        {
            object ALarry = null;
            object BLarry = null;
            object CLarry = new object();

            BLarry = ALarry ?? CLarry;

            //========
            var A = new object();
            var B = new object();

            var iterations = 1000000000;

            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < iterations; i++)
            {
                if (i == 1) sw.Start();
                if (A == null)
                {
                    A = B;
                }
            }
            sw.Stop();
            TimeSpan first = sw.Elapsed;

            sw.Reset();
            for (int i = 0; i < iterations; i++)
            {
                if (i == 1) sw.Start();
                A = A ?? B;
            }
            sw.Stop();
            TimeSpan second = sw.Elapsed;

            first.Dump();
            second.Dump();

            (first.TotalMilliseconds / second.TotalMilliseconds).Dump("Ratio");

            //==============

            new TimeSpan(1, 2, 3, 4, 5).ToFriendlyDisplay(3).Dump();
            new TimeSpan(0, 5, 3, 4, 5).ToFriendlyDisplay(3).Dump();
        }
    }

    /// <summary>
    /// http://stackoverflow.com/questions/1138723/timespan-to-friendly-string-library-c
    /// </summary>
    public static class TimeSpanExtensions
    {
        private enum TimeSpanElement
        {
            Millisecond,
            Second,
            Minute,
            Hour,
            Day
        }

        public static string ToFriendlyDisplay(this TimeSpan timeSpan, int maxNrOfElements)
        {
            maxNrOfElements = Math.Max(Math.Min(maxNrOfElements, 5), 1);
            var parts = new[]
                            {
                            Tuple.Create(TimeSpanElement.Day, timeSpan.Days),
                            Tuple.Create(TimeSpanElement.Hour, timeSpan.Hours),
                            Tuple.Create(TimeSpanElement.Minute, timeSpan.Minutes),
                            Tuple.Create(TimeSpanElement.Second, timeSpan.Seconds),
                            Tuple.Create(TimeSpanElement.Millisecond, timeSpan.Milliseconds)
                        }
                                        .SkipWhile(i => i.Item2 <= 0)
                                        .Take(maxNrOfElements);

            return string.Join(", ", parts.Select(p => string.Format("{0} {1}{2}", p.Item2, p.Item1, p.Item2 > 1 ? "s" : string.Empty)));
        }
    }
}
