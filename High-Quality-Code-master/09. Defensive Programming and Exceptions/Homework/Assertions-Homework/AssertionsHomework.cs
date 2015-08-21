using System;
using Assertions_Homework;

public class AssertionsHomework
{
    public static void Main()
    {
        int[] numbers = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        var numbersValues = string.Join(", ", numbers);
        Console.WriteLine("numbers = [{0}]", numbersValues);
        SelectionSorter.SelectionSort(numbers);
        numbersValues = string.Join(", ", numbers);
        Console.WriteLine("sorted = [{0}]", numbersValues);

        SelectionSorter.SelectionSort(new int[0]);
        SelectionSorter.SelectionSort(new int[1]);

        var searchResult = ArrayElementSearcher.SearchValueInArray(numbers, -1000);
        Console.WriteLine(searchResult);
        searchResult = ArrayElementSearcher.SearchValueInArray(numbers, 0);
        Console.WriteLine(searchResult);
        searchResult = ArrayElementSearcher.SearchValueInArray(numbers, 17);
        Console.WriteLine(searchResult);
        searchResult = ArrayElementSearcher.SearchValueInArray(numbers, 10);
        Console.WriteLine(searchResult);
        searchResult = ArrayElementSearcher.SearchValueInArray(numbers, 1000);
        Console.WriteLine(searchResult);
    }
}
