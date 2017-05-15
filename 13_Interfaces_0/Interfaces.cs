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
 * 
 * How to: Explicitly Implement Members of Two Interfaces (C# Programming Guide)
 * 
 * https://docs.microsoft.com/en-us/dotnet/articles/csharp/programming-guide/interfaces/how-to-explicitly-implement-members-of-two-interfaces
 * 
 * How to: Explicitly Implement Interface Members (C# Programming Guide)
 * 
 * https://docs.microsoft.com/en-us/dotnet/articles/csharp/programming-guide/interfaces/how-to-explicitly-implement-interface-members
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

    //=============================================

    // Declare the English units interface:
    interface IEnglishDimensions
    {
        float Length();
        float Width();
    }

    // Declare the metric units interface:
    interface IMetricDimensions
    {
        float Length();
        float Width();
    }

    // Declare the Box class that implements the two interfaces:
    // IEnglishDimensions and IMetricDimensions:
    class Box : IEnglishDimensions, IMetricDimensions
    {
        float lengthInches;
        float widthInches;

        public Box(float length, float width)
        {
            lengthInches = length;
            widthInches = width;
        }

        // Explicitly implement the members of IEnglishDimensions:
        float IEnglishDimensions.Length()
        {
            return lengthInches;
        }

        float IEnglishDimensions.Width()
        {
            return widthInches;
        }

        // Explicitly implement the members of IMetricDimensions:
        float IMetricDimensions.Length()
        {
            return lengthInches * 2.54f;
        }

        float IMetricDimensions.Width()
        {
            return widthInches * 2.54f;
        }
    }

    class Box2 : IEnglishDimensions, IMetricDimensions
    {
        float lengthInches;
        float widthInches;

        public Box2(float length, float width)
        {
            lengthInches = length;
            widthInches = width;
        }

        // Normal implementation:
        public float Length()
        {
            return lengthInches;
        }
        public float Width()
        {
            return widthInches;
        }

        // Explicit implementation:
        float IMetricDimensions.Length()
        {
            return lengthInches * 2.54f;
        }
        float IMetricDimensions.Width()
        {
            return widthInches * 2.54f;
        }
    }

    //=====================================

    interface IDimensions
    {
        float getLength();
        float getWidth();
    }

    class Box3 : IDimensions
    {
        float lengthInches;
        float widthInches;

        public Box3(float length, float width)
        {
            lengthInches = length;
            widthInches = width;
        }
        // Explicit interface member implementation: 
        float IDimensions.getLength()
        {
            return lengthInches;
        }
        // Explicit interface member implementation:
        float IDimensions.getWidth()
        {
            return widthInches;
        }
    }

    class Interfaces
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


            //=======================================================

            // Declare a class instance box1:
            Box box1 = new Box(30.0f, 20.0f);

            // Declare an instance of the English units interface:
            IEnglishDimensions eDimensions = (IEnglishDimensions)box1;

            // Declare an instance of the metric units interface:
            IMetricDimensions mDimensions = (IMetricDimensions)box1;

            // Print dimensions in English units:
            System.Console.WriteLine("Length(in): {0}", eDimensions.Length());
            System.Console.WriteLine("Width (in): {0}", eDimensions.Width());

            // Print dimensions in metric units:
            System.Console.WriteLine("Length(cm): {0}", mDimensions.Length());
            System.Console.WriteLine("Width (cm): {0}", mDimensions.Width());

            //=======================================================

            Box2 box2 = new Box2(30.0f, 20.0f);
            IMetricDimensions mDimensions2 = (IMetricDimensions)box2;

            System.Console.WriteLine("Length(in): {0}", box2.Length());
            System.Console.WriteLine("Width (in): {0}", box2.Width());
            System.Console.WriteLine("Length(cm): {0}", mDimensions2.Length());
            System.Console.WriteLine("Width (cm): {0}", mDimensions2.Width());

            //=======================================================

            // Declare a class instance box1:
            Box3 box3 = new Box3(30.0f, 20.0f);

            // Declare an interface instance dimensions:
            IDimensions dimensions = (IDimensions)box3;

            // The following commented lines would produce compilation 
            // errors because they try to access an explicitly implemented
            // interface member from a class instance:                   
            //System.Console.WriteLine("Length: {0}", box1.getLength());
            //System.Console.WriteLine("Width: {0}", box1.getWidth());

            // Print out the dimensions of the box by calling the methods 
            // from an instance of the interface:
            System.Console.WriteLine("Length: {0}", dimensions.getLength());
            System.Console.WriteLine("Width: {0}", dimensions.getWidth());
        }
    }
}
