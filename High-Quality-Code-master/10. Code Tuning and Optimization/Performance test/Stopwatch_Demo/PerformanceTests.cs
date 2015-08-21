namespace CompareMathOperations
{
    using System;
    using System.Diagnostics;

    public static class PerformanceTests
    {
        public const int TestCycleLenght = 10000000;

        public static void MakeAddTest(object dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = i + 2;
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Reset();
        }

        public static void MakeSubstractTest(object dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = i - 2;
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeIncrementTest(object dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = i++;
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeMultiplyTest(object dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = i * 2;
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }

        public static void MakeDivideTest(object dataType)
        {
            Stopwatch stopWatch = new Stopwatch();
            dataType = 1;
            stopWatch.Start();
            for (int i = 0; i < TestCycleLenght; i++)
            {
                dataType = i / 2;
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Reset();
        }
    }
}
