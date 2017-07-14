using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            GetAttributeMethodLevel(typeof(CustomAttributeTest));

            //The Name Attribute is: Joan Smith.

            //The Level Attribute is: 42.
            //The Reviewed Attribute is: True.
            //The Name Attribute on the class level is: Joan Smith.
            //The Level Attribute on the class level is: 42.
            //The Reviewed Attribute on the class level is: True.

            //No attribute in member function Void GetAttribute(System.Type).

            //No attribute in member function Void GetAttribute2(System.Type).

            //No attribute in member function System.String ToString().

            //No attribute in member function Boolean Equals(System.Object).

            //No attribute in member function Int32 GetHashCode().

            //No attribute in member function System.Type GetType().
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

        public static void GetAttributeMethodLevel(Type t)
        {
            DeveloperAttribute att;

            // Get the class-level attributes.

            // Put the instance of the attribute on the class level in the att object.
            att = (DeveloperAttribute)Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute));

            if (att == null)
            {
                Console.WriteLine("No attribute in class {0}.\n", t.ToString());
            }
            else
            {
                Console.WriteLine("The Name Attribute on the class level is: {0}.", att.Name);
                Console.WriteLine("The Level Attribute on the class level is: {0}.", att.Level);
                Console.WriteLine("The Reviewed Attribute on the class level is: {0}.\n", att.Reviewed);
            }

            // Get the method-level attributes.

            // Get all methods in this class, and put them
            // in an array of System.Reflection.MemberInfo objects.
            MemberInfo[] MyMemberInfo = t.GetMethods();

            // Loop through all methods in this class that are in the
            // MyMemberInfo array.
            for (int i = 0; i < MyMemberInfo.Length; i++)
            {
                att = (DeveloperAttribute)Attribute.GetCustomAttribute(MyMemberInfo[i], typeof(DeveloperAttribute));
                if (att == null)
                {
                    Console.WriteLine("No attribute in member function {0}.\n", MyMemberInfo[i].ToString());
                }
                else
                {
                    Console.WriteLine("The Name Attribute for the {0} member is: {1}.",
                        MyMemberInfo[i].ToString(), att.Name);
                    Console.WriteLine("The Level Attribute for the {0} member is: {1}.",
                        MyMemberInfo[i].ToString(), att.Level);
                    Console.WriteLine("The Reviewed Attribute for the {0} member is: {1}.\n",
                        MyMemberInfo[i].ToString(), att.Reviewed);
                }
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
 