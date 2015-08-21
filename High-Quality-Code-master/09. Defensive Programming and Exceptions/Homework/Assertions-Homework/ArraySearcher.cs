namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    public class ArrayElementSearcher
    {
        public static int SearchValueInArray<T>(T[] arr, T value) where T : IComparable<T>
        {
            return SearchForValue(arr, value, 0, arr.Length - 1);
        }

        private static int SearchForValue<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");
            Debug.Assert(value != null, "Search value is null.");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index is out of range.");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "End index is out of range.");
            Debug.Assert(startIndex <= endIndex, "Start index can not be greater than end index.");
                       
            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    startIndex = midIndex + 1;
                }
                else if (arr[midIndex].CompareTo(value) > 0)
                {
                    endIndex = midIndex - 1;
                }
            }
           
            return -1;
        }
    }
}
