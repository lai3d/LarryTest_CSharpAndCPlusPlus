using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }

    public class Part : IEquatable<Part>
    {
        public string PartName { get; set; }
        public int PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return PartId;
        }
        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.PartId.Equals(other.PartId));
        }
        // Should also override == and != operators.
    }

    class Machine
    {
        private static int _score0 = 0;
        private static int _score39 = 39;

        public static int Score0 { get { return _score0; } set { _score0 = value; } }
        public static int Score39 { get { return _score39; } set { _score39 = value; } }
    }

    public class HockeyTeam
    {
        private string _name;
        private int _founded;

        public HockeyTeam(string name, int year)
        {
            _name = name;
            _founded = year;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Founded
        {
            get { return _founded; }
        }
    }

    class Program
    {
        public static object Enumerations { get; private set; }

        public enum BasePayType
        {
            [Description("Online")]
            Online_1 = 1,
            [Description("WeChat")]
            WeChat_2 = 2,
            [Description("Alipay")]
            Alipay_3 = 3,
            [Description("CardPoint")]
            CardPoint_4 = 4
        }

        public static Point PointFToPoint(PointF pf)
        {
            return new Point(((int)pf.X), ((int)pf.Y));
        }

        public class BASE_RISKLEVEL
        {
            public string FDESC { get; set; }
            public string FDOMAINNAME { get; set; }
            public string FID { get; set; }
        }

        static void Main(string[] args)
        {
            var riskLevel = new BASE_RISKLEVEL();
            Console.WriteLine("fid:{0} fdesc:{1}", riskLevel.FID, riskLevel.FDESC);

            #region Static Value alternate 

            if(Machine.Score39 == 39)
            {
                Console.WriteLine("Bingo!");
            }

            Machine.Score0 = -1;

            Console.WriteLine(Machine.Score0);

            Machine.Score39 = 35;

            Console.WriteLine(Machine.Score39);

            #endregion

            #region Enum description

            // Enumerations.GetEnumDescription((BasePayType)BasePayType.Alipay_3)
            string enumDesc = EnumHelper.GetEnumDescription(BasePayType.Alipay_3);
            Console.WriteLine(enumDesc);

            #endregion

            #region Predicate<T>

            Random rnd = new Random();
            List<HockeyTeam> teams = new List<HockeyTeam>();
            teams.AddRange(new HockeyTeam[] { new HockeyTeam("Detroit Red Wings", 1926),
                                         new HockeyTeam("Chicago Blackhawks", 1926),
                                         new HockeyTeam("San Jose Sharks", 1991),
                                         new HockeyTeam("Montreal Canadiens", 1909),
                                         new HockeyTeam("St. Louis Blues", 1967) });

            int[] years = { 1920, 1930, 1980, 2000 };
            int foundedBeforeYear = years[rnd.Next(0, years.Length)];
            Console.WriteLine("Teams founded before {0}:", foundedBeforeYear);
            foreach (var team in teams.FindAll(x => x.Founded <= foundedBeforeYear))
                Console.WriteLine("{0}: {1}", team.Name, team.Founded);

            #endregion Predicate<T>

            #region Array.ConvertAll

            // Create an array of PointF objects.
            PointF[] apf = {
            new PointF(27.8F, 32.62F),
            new PointF(99.3F, 147.273F),
            new PointF(7.5F, 1412.2F)
            };

            // Display each element in the PointF array.
            Console.WriteLine();
            foreach (PointF p in apf)
                Console.WriteLine(p);

            // Convert each PointF element to a Point object.
            //Point[] ap = Array.ConvertAll(apf, new Converter<PointF, Point>(PointFToPoint));
            // replace method with lambda expression
            Point[] ap = Array.ConvertAll( apf, new Converter<PointF, Point>(pf => new Point(((int)pf.X), ((int)pf.Y))) );

            // Display each element in the Point array.
            Console.WriteLine();
            foreach (Point p in ap)
            {
                Console.WriteLine(p);
            }

            #endregion

            // Create a list of parts.
            List<Part> parts = new List<Part>();

            // Add parts to the list.
            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
            parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
            parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 });

            // Write out the parts in the list. This will call the overridden ToString method
            // in the Part class.
            Console.WriteLine();
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            // Check the list for part #1734. This calls the IEquatable.Equals method
            // of the Part class, which checks the PartId for equality.
            Console.WriteLine("Contains: Part with Id = 1734: { 0}", parts.Contains(new Part { PartId = 1734, PartName = "" }));

            // Find items where name contains "seat".
            Console.WriteLine("Find: Part where name contains \"seat\": {0}",
                parts.Find(x => x.PartName.Contains("seat")));

            // Check if an item with Id 1444 exists.
            Console.WriteLine("Exists: Part with Id = 1444: { 0}", 
            parts.Exists(x => x.PartId == 1444));

            /*This code example produces the following output:

            ID: 1234   Name: crank arm
            ID: 1334   Name: chain ring
            ID: 1434   Name: regular seat
            ID: 1444   Name: banana seat
            ID: 1534   Name: cassette
            ID: 1634   Name: shift lever

            Contains: Part with Id=1734: False

            Find: Part where name contains "seat": ID: 1434   Name: regular seat

            Exists: Part with Id=1444: True 
             */

            int i = 0;
        }
    }
}
