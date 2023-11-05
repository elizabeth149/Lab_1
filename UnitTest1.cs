using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace TestProject1
{
    public class UnitTest1
    {
        [TestClass]
        public class ProgramTests
        {
            [Fact]
            public void TestSumNechet()
            {
                double[] arr = new double[] { 1, 2, 3, 4, 5 };
                double result = Program.Sum_Nechet(arr);
                Xunit.Assert.Equal(9, result);
            }
            [Fact]
            public void TestSumOtric()
            {
                double[] arr = new double[] { 1, -2, 3, -4, 5 };

                double result = Program.Sum_Otric(arr, 1, 3);

                Xunit.Assert.Equal(-3, result);
            }

            [Fact]
            public void TestZapolnenie()
            {
                int size = 5;

                double[] arr = Program.Zapolnenie(size);

                
                Xunit.Assert.Equal(size, arr.Length);
            }

            [Fact]
            public void TestZapolnenie_2()
            {
                int size = 4;

                int[,] matrix = Program.Zapolnenie_2(size);

                
                Xunit.Assert.Equal(size, matrix.GetLength(1));
            }

            [Fact]
            public void TestBezNegativa()
            {
                // Arrange
                int[,] matrix = new int[,]
                {
                    { 1, 2, 3 },
                    { -1, -2, -3 },
                    { 4, 5, 6 }
                };

                // Act
                int result = Program.BezNegativa(matrix);

                // Assert
                Xunit.Assert.Equal(720, result);
            }

            [Fact]
            public void TestDiagonale()
            {
                int[,] matrix = new int[,]
                {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
                };

                int result = Program.Diagonale(matrix);

                
                Xunit.Assert.Equal(15, result);
            }

        }
    }
}
