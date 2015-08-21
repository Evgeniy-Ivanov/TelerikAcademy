namespace MatrixRotatingWalkTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RotatingWalkInMatrix;

    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MatrixWithZeroSizeThrowsException()
        {
            Matrix matrix = new Matrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IfMatrixSizeIsBigerThanMaxSizeThrowsException()
        {
            Matrix matrix = new Matrix(Matrix.MaxSize + 1);
        }

        [TestMethod]
        public void TestShouldReturnCorrectMatrixOfSize3()
        {
            Matrix matrix = new Matrix(3);
            matrix.RotatingWalk();
            string expected = 
                "  1  7  8\r\n" +
                "  6  2  9\r\n" +
                "  5  4  3";
            string actual = matrix.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestShouldReturnCorrectMatrixOfSize6()
        {
            Matrix matrix = new Matrix(6);
            matrix.RotatingWalk();
            string expected = 
                "  1 16 17 18 19 20\r\n" +
                " 15  2 27 28 29 21\r\n" +
                " 14 31  3 26 30 22\r\n" +
                " 13 36 32  4 25 23\r\n" +
                " 12 35 34 33  5 24\r\n" +
                " 11 10  9  8  7  6";
            string actual = matrix.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestShouldReturnCorrectInputMatrixSize()
        {
            var console = new ConsoleWrapper();
            console.LinesToRead.Add("6");

            string expected = console.ReadLine();
            int actual = MatrixDemo.InputMatrixSize(6);

            Assert.AreEqual(expected, actual);
        }
    }
}
