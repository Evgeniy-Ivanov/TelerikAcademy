using System;
using System.Collections.Generic;
using System.Text;
using Exceptions_Homework;

public class ExceptionsHomework
{
    public static void Main()
    {
        var substr = HelperMethods.Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = HelperMethods.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = HelperMethods.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = HelperMethods.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        string endCharacters = HelperMethods.ExtractEnding("I love C#", 2);
        Console.WriteLine(endCharacters);
        endCharacters = HelperMethods.ExtractEnding("Nakov", 4);
        Console.WriteLine(endCharacters);
        endCharacters = HelperMethods.ExtractEnding("beer", 4);
        Console.WriteLine(endCharacters);
        endCharacters = HelperMethods.ExtractEnding("Hi", 100);
        Console.WriteLine(endCharacters);

        try
        {
            HelperMethods.CheckPrime(23);
            Console.WriteLine("23 is a prime number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ErrorMessage: {0}", ex.Message);
        }

        try
        {
            HelperMethods.CheckPrime(33);
            Console.WriteLine("33 is a prime number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ErrorMessage: {0}", ex.Message);
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
