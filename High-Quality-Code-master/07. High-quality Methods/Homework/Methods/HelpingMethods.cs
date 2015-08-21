namespace HelpingMethods
{
    using System;
 
    public class АuxiliaryMethods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a), "Triangle sides should be positive integers.");
            }
            else if ((a >= (b + c)) || (b >= (c + a)) || (c >= (a + b)))
            {
                throw new ArgumentOutOfRangeException(nameof(a), "The given sides cannot construct a valid triangle.");
            }
            
            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        public static string ConvertDigitToString(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("This is invalid number!");
            }
        }

        public static int FindBigestElementIndex(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                Console.Error.WriteLine("There are no elements.");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        public static void PrintFormattedNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }

            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }

            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }

        public static double CalculateDistanceAndDirection(double x1, double y1, double x2, double y2, 
                                out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (System.Math.Abs(y1 - y2) < 1);
            isVertical = System.Math.Abs(x1 - x2) < 1;

            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertDigitToString(5));

            Console.WriteLine(FindBigestElementIndex(5, -1, 3, 2, 14, 2, 3));

            PrintFormattedNumber(1.3, "f");
            PrintFormattedNumber(0.75, "%");
            PrintFormattedNumber(2.30, "r");

            bool horizontal, vertical;
            double distance = CalculateDistanceAndDirection(3, -1, 3, 2.5, out horizontal, out vertical);
            Console.WriteLine(distance);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 3, 11), "Vidin", "gamer, high results");
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
