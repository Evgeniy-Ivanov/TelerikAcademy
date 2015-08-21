namespace RotatingWalkInMatrix
{
    using System;

    public class MatrixDemo
    {
        public static int InputMatrixSize(int size)
        {
            IConsole console = new ConsoleWrapper();
            string input;
            int matrixSize;
            do
            {
                Console.WriteLine("Please type a valid matrix size. (0 < size <= {0}):", size);
                input = console.ReadLine();
                
            }
            while (!int.TryParse(input, out matrixSize) || matrixSize < 1 || matrixSize > size);

            return matrixSize;
        }

        public static void Main()
        {
            int matrixSize = InputMatrixSize(Matrix.MaxSize);

            Matrix matrix = new Matrix(matrixSize);

            matrix.RotatingWalk();

            Console.WriteLine(matrix);
        }
    }
}