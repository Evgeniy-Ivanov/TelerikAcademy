namespace CompareAdvancedMath
{
    using System;
    using System.Diagnostics;

    public static class AdvancedMathTests
    {
        public const int TestCycleLenght = 10000000;

        public static void MakeSqrtTest(float dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = (float)Math.Sqrt(dataType);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeSqrtTest(double dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = (double)Math.Sqrt(dataType);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeSqrtTest(decimal dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = (decimal)Math.Sqrt((double)dataType);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeLogTest(float dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = (float)Math.Log(dataType);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeLogTest(double dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = (double)Math.Log(dataType);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeLogTest(decimal dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = (decimal)Math.Log((double)dataType);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeSinTest(float dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = (float)Math.Sqrt(dataType);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeSinTest(double dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = (double)Math.Sqrt(dataType);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeSinTest(decimal dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = (decimal)Math.Sqrt((double)dataType);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }
    }
}
