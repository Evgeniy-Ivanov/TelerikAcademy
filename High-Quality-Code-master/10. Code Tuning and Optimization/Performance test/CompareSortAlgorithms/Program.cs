using System;
using System.Diagnostics;

namespace CompareSortAlgorithms
{
    class SortAlgorithmsComparisonTest
    {
        const int startIndex = 0;
        const int RIGHT_INDEX = 9;
        
        // Random
        static readonly int[] RandomInts = { 8, 3, 4, 1, 5, 6, 9, 7, 10, 2 };

        static readonly double[] RandomDoubles = { 8.0, 3.0, 4.0, 1.0, 5.0, 6.0, 9.0, 7.0, 10.0 };

        static readonly string[] RandomStrings = { "a", "c", "d", "b", "e", "g", "f", "j", "i", "h" };
		
        // Sorted
        static readonly int[] SortedInts = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        static readonly double[] SortedDoubles = { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };

        static readonly string[] SortedStrings = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
		
        // Sorted in reversed order
        static readonly int[] ReversedInts = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
		
        static readonly double[] ReversedDoubles = { 10.0, 9.0, 8.0, 7.0, 6.0, 5.0, 4.0, 3.0, 2.0, 1.0 };

        static readonly string[] ReversedStrings = { "j", "i", "h", "g", "f", "e", "d", "c", "b", "a" };
		
        public static void Main()
        {
            Console.WriteLine("Compare sorting algorithms performance (int, double, string). ");
            Console.WriteLine(" ");

            Console.Write("Insertion sort- Random Int:   ");
            SortPerformance(() => { Algorithms.InsertionSort(RandomInts); });

            Console.Write("Insertion sort- Sorted Int:   ");
            SortPerformance(() => { Algorithms.InsertionSort(RandomInts); });

            Console.Write("Insertion sort- Reversed Int: ");
            SortPerformance(() => { Algorithms.InsertionSort(RandomInts); });
            Console.WriteLine(" ");

            Console.Write("Insertion sort- Random Double:    ");
            SortPerformance(() => { Algorithms.InsertionSort(RandomDoubles); });

            Console.Write("Insertion sort- Sorted Double:    ");
            SortPerformance(() => { Algorithms.InsertionSort(RandomDoubles); });

            Console.Write("Insertion sort- Reversed Double:  ");
            SortPerformance(() => { Algorithms.InsertionSort(RandomInts); });
            Console.WriteLine(" ");

            Console.Write("Insertion sort- Random String:    ");
            SortPerformance(() => { Algorithms.InsertionSort(RandomStrings); });

            Console.Write("Insertion sort- Sorted String:    ");
            SortPerformance(() => { Algorithms.InsertionSort(RandomStrings); });

            Console.Write("Insertion sort- Reversed String:  ");
            SortPerformance(() => { Algorithms.InsertionSort(RandomStrings); });
            Console.WriteLine(" ");

            Console.Write("Selection sort Random Int:   ");
            SortPerformance(() => { Algorithms.SelectionSort(RandomInts); });

            Console.Write("Selection sort- Sorted Int:   ");
            SortPerformance(() => { Algorithms.SelectionSort(RandomInts); });

            Console.Write("Selection sort- Reversed Int: ");
            SortPerformance(() => { Algorithms.SelectionSort(RandomInts); });
            Console.WriteLine(" ");

            Console.Write("Selection sort- Random Double:    ");
            SortPerformance(() => { Algorithms.SelectionSort(RandomDoubles); });

            Console.Write("Selection sort- Sorted Double:    ");
            SortPerformance(() => { Algorithms.SelectionSort(RandomDoubles); });

            Console.Write("Selection sort- Reversed Double:  ");
            SortPerformance(() => { Algorithms.SelectionSort(RandomInts); });
            Console.WriteLine(" ");

            Console.Write("Selection sort- Random String:    ");
            SortPerformance(() => { Algorithms.SelectionSort(RandomStrings); });

            Console.Write("Selection sort- Sorted String:    ");
            SortPerformance(() => { Algorithms.SelectionSort(RandomStrings); });

            Console.Write("Selection sort- Reversed String:  ");
            SortPerformance(() => { Algorithms.SelectionSort(RandomStrings); });
            Console.WriteLine(" ");

            Console.Write("Quick sort- Random Int:   ");
            SortPerformance(() => { Algorithms.QuickSort(RandomInts, startIndex, RIGHT_INDEX); });

            Console.Write("Quick sort- Sorted Int:   ");
            SortPerformance(() => { Algorithms.QuickSort(RandomInts, startIndex, RIGHT_INDEX); });

            Console.Write("Quick sort- Reversed Int: ");
            SortPerformance(() => { Algorithms.QuickSort(RandomInts, startIndex, RIGHT_INDEX); });
            Console.WriteLine(" ");

            Console.Write("Quick sort- Random Double:    ");
            SortPerformance(() => { Algorithms.QuickSort(RandomInts, startIndex, RIGHT_INDEX); });

            Console.Write("Quick sort- Sorted Double:    ");
            SortPerformance(() => { Algorithms.QuickSort(RandomInts, startIndex, RIGHT_INDEX); });

            Console.Write("Quick sort- Reversed Double:  ");
            SortPerformance(() => { Algorithms.QuickSort(RandomInts, startIndex, RIGHT_INDEX); });
            Console.WriteLine(" ");

            Console.Write("Quick sort- Random String:    ");
            SortPerformance(() => { Algorithms.QuickSort(RandomInts, startIndex, RIGHT_INDEX); });

            Console.Write("Quick sort- Sorted String:    ");
            SortPerformance(() => { Algorithms.QuickSort(RandomInts, startIndex, RIGHT_INDEX); });

            Console.Write("Quick sort- Reversed String:  ");
            SortPerformance(() => { Algorithms.QuickSort(RandomInts, startIndex, RIGHT_INDEX); });
            Console.WriteLine(" ");
        }

        public static void SortPerformance(Action action)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            action();
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }
    }
}
