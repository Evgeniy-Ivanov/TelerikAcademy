namespace CompareMathOperations
{
    using System;
    using System.Diagnostics;

	public class CompareSimpleMath
	{
        public static void Main(string[] args)
		{
            int testInt = 1;
            long testLong = 1;
            float testFloat = 1.0f;
            double testDouble = 1.0d;
            decimal testDecimal = 1.0m;

            Stopwatch stopWatch = new Stopwatch();
            
            Console.WriteLine("Add int ");
            PerformanceTests.MakeAddTest(testInt);
            Console.WriteLine("Add long");
            PerformanceTests.MakeAddTest(testLong);
            Console.WriteLine("Add float");
            PerformanceTests.MakeAddTest(testFloat);
            Console.WriteLine("Add double");
            PerformanceTests.MakeAddTest(testDouble);
            Console.WriteLine("Add decimal");
            PerformanceTests.MakeAddTest(testDecimal);
            Console.WriteLine(" ");

            Console.WriteLine("Substract int");
            PerformanceTests.MakeSubstractTest(testInt);
            Console.WriteLine("Substract long");
            PerformanceTests.MakeSubstractTest(testLong);
            Console.WriteLine("Substract float");
            PerformanceTests.MakeSubstractTest(testFloat);
            Console.WriteLine("Substract double");
            PerformanceTests.MakeSubstractTest(testDouble);
            Console.WriteLine("Substract decimal");
            PerformanceTests.MakeSubstractTest(testDecimal);
            Console.WriteLine(" ");

            Console.WriteLine("Increment int");
            PerformanceTests.MakeIncrementTest(testInt);
            Console.WriteLine("Increment long");
            PerformanceTests.MakeIncrementTest(testLong);
            Console.WriteLine("Increment float");
            PerformanceTests.MakeIncrementTest(testFloat);
            Console.WriteLine("Increment double");
            PerformanceTests.MakeIncrementTest(testDouble);
            Console.WriteLine("Increment decimal");
            PerformanceTests.MakeIncrementTest(testDecimal);
            Console.WriteLine(" ");

            Console.WriteLine("Multiply int");
            PerformanceTests.MakeMultiplyTest(testInt);
            Console.WriteLine("Multiply long");
            PerformanceTests.MakeMultiplyTest(testLong);
            Console.WriteLine("Multiply float");
            PerformanceTests.MakeMultiplyTest(testFloat);
            Console.WriteLine("Multiply double");
            PerformanceTests.MakeMultiplyTest(testDouble);
            Console.WriteLine("Multiply decimal");
            PerformanceTests.MakeMultiplyTest(testDecimal);
            Console.WriteLine(" ");

            Console.WriteLine("Divide int");
            PerformanceTests.MakeDivideTest(testInt);
            Console.WriteLine("Divide long");
            PerformanceTests.MakeDivideTest(testLong);
            Console.WriteLine("Divide float");
            PerformanceTests.MakeDivideTest(testFloat);
            Console.WriteLine("Divide double");
            PerformanceTests.MakeDivideTest(testDouble);
            Console.WriteLine("Divide decimal");
            PerformanceTests.MakeDivideTest(testDecimal);
		}
	}
}
