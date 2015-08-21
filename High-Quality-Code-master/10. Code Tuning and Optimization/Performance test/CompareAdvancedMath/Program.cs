using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAdvancedMath
{
    public class Program
    {
        public static void Main(string[] args)
        {
            float floatData = 69.0f;
            double doubleData = 69.0d;
            decimal decimalData = 69.0m;

            Console.WriteLine("Square root float:");
            AdvancedMathTests.MakeSqrtTest(floatData);
            Console.WriteLine("Square root double:");
            AdvancedMathTests.MakeSqrtTest(doubleData);
            Console.WriteLine("Square root decimal:");
            AdvancedMathTests.MakeSqrtTest(decimalData);
            Console.WriteLine(" ");

            Console.WriteLine("Natural logarithm float:");
            AdvancedMathTests.MakeSqrtTest(floatData);
            Console.WriteLine("Natural logarithm double:");
            AdvancedMathTests.MakeSqrtTest(doubleData);
            Console.WriteLine("Natural logarithm decimal:");
            AdvancedMathTests.MakeSqrtTest(decimalData);
            Console.WriteLine(" ");

            Console.WriteLine("Sinus float:");
            AdvancedMathTests.MakeSqrtTest(floatData);
            Console.WriteLine("Sinus double:");
            AdvancedMathTests.MakeSqrtTest(doubleData);
            Console.WriteLine("Sinus decimal:");
            AdvancedMathTests.MakeSqrtTest(decimalData);
            Console.WriteLine(" ");
        }
    }
}
