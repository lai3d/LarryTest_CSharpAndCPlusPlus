using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Attribute_Custom
{
    [Developer("Joan Smith", "42", Reviewed = true)]
    class CustomAttributeTest
    {
        static void Main(string[] args)
        {
            // Call function to get and display the attribute.
            GetAttribute(typeof(CustomAttributeTest));
        }

        public static void GetAttribute(Type t)
        {
            // Get instance of the attribute.
            DeveloperAttribute MyAttribute = (DeveloperAttribute)Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute));

            if (MyAttribute == null)
            {
                Console.WriteLine("The attribute was not found.");
            }
            else
            {
                // Get the Name value.
                Console.WriteLine("The Name Attribute is: {0}.", MyAttribute.Name);
                // Get the Level value.
                Console.WriteLine("The Level Attribute is: {0}.", MyAttribute.Level);
                // Get the Reviewed value.
                Console.WriteLine("The Reviewed Attribute is: {0}.", MyAttribute.Reviewed);
            }
        }
    }
}

[AttributeUsage(AttributeTargets.All)]
public class DeveloperAttribute : Attribute
{
    // Private fields.
    private string name;
    private string level;
    private bool reviewed;

    // This constructor defines two required parameters: name and level.

    public DeveloperAttribute(string name, string level)
    {
        this.name = name;
        this.level = level;
        this.reviewed = false;
    }

    // Define Name property.
    // This is a read-only attribute.

    public virtual string Name
    {
        get { return name; }
    }

    // Define Level property.
    // This is a read-only attribute.

    public virtual string Level
    {
        get { return level; }
    }

    // Define Reviewed property.
    // This is a read/write attribute.

    public virtual bool Reviewed
    {
        get { return reviewed; }
        set { reviewed = value; }
    }
}