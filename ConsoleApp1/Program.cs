
using System.Drawing;
using System.Numerics;
//Вариант 3
namespace ConsoleApp1
{
    class Program
    {
        private static int[] arr;

        static void Main(string[] args)
        {
            Console.WriteLine("Вариант 3");
            Console.WriteLine("Часть 1");
            Console.WriteLine("");
            Console.Write("Введите размер массива: ");
            int N = int.Parse(Console.ReadLine());
            double[] arr = Zapolnenie(N);
            Console.WriteLine("Исходный массив:" );
            PrintArray(arr);
            double t = Sum_Nechet(arr);
            Console.WriteLine($"Сумма элементов с нечетными номерами: {t}");
            // Найдем первый и последний отрицательные элементы
            int firstNegativeIndex = -1;
            int lastNegativeIndex = -1;
            for (int i = 0; i < N; i++)
            {
                if (arr[i] < 0)
                {
                    if (firstNegativeIndex == -1)
                    {
                        firstNegativeIndex = i;
                    }
                    lastNegativeIndex = i;
                }
            }
            double r = Sum_Otric(arr, firstNegativeIndex, lastNegativeIndex);
            Console.WriteLine($"Сумма элементов между первым и последним отрицательными элементами: {r}");
            // Удалим элементы, модуль которых не превышает единицу
            for (int i = 0; i < N; i++)
            {
                if (Math.Abs(arr[i]) <= 1)
                {
                    arr[i] = 0;
                }
            }
            // Выведем измененный массив
            Console.WriteLine("Измененный массив после удаления элементов с модулем <= 1:");
            PrintArray(arr);
            Console.WriteLine("");
            Console.WriteLine("Часть 2");
            Console.Write("Введите размер матрицы: ");
            int N_1 = int.Parse(Console.ReadLine());
            int[,] matrix = Zapolnenie_2(N_1);
            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix,N_1);
            BezNegativa(matrix);
            Diagonale(matrix);


        }
        // Метод вычисляет сумму элементов между первым и последним отрицательными элементами
        private static double Sum_Otric(double[] a, int firstNegativeIndex, int lastNegativeIndex)
        {
            double sum_otric_chisel = 0;
            if (firstNegativeIndex != -1 && lastNegativeIndex != -1)
            {
                for(int i = firstNegativeIndex; i< lastNegativeIndex; i++)
                {
                    sum_otric_chisel += a[i];
                }
            }
            return sum_otric_chisel;
        }

        //Метод нахождения суммы элементов массива с нечектными номерами
        private static double Sum_Nechet(double[] a)
        {
            double znach_1 = 0;
            for (int i = 0;i<a.Length; i += 2)
            {
                znach_1 += a[i];
            }
            return znach_1;
        }

        //Метод заполнения массива, состоящего из N вещественных элементов
        private static double[] Zapolnenie(int size) { 
            var random= new Random();
            double[] arr = new double[size];
            for (int i = 0; i< arr.Length; i++)
            {
                arr[i] = random.NextDouble() * 10;
            }
            return arr;
        }
        //Метод заполнения матрицы, состоящей из N*N целочисленных элементов
        private static int[,] Zapolnenie_2(int size)
        {
            Random random = new Random();
            int[,] matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++) 
                {
                    matrix[i, j] = random.Next(-10,11);
                }
                    
            }
            return matrix;
        }

        // Метод для вывода массива
        private static void PrintArray(double[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        // Метод для вывода матрицы
        private static void PrintMatrix(int[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        // Метод вычисления произведения элементов в строках без отрицательных элементов
        private static void BezNegativa(int[,] matrix)
        {
            int productWithoutNegatives = 1;
            int vremenProverka = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool isNegative = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    vremenProverka *= matrix[i, j];
                    if (matrix[i, j] < 0)
                    {
                        isNegative = true;
                        break;
                    }
                }
            if (!isNegative)
                {
                    productWithoutNegatives *= vremenProverka;
                    vremenProverka = 1;
                }
            }
            Console.WriteLine($"Произведение элементов в строках без отрицательных элементов: {productWithoutNegatives}");
        }
        // Метод нахождения максимума среди сумм элементов диагоналей, параллельных главной диагонали матрицы
        private static void Diagonale(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int maxSum = int.MinValue;

            // Суммируем элементы выше главной диагонали
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < n - i; j++)
                {
                    sum += matrix[j, i + j];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            // Суммируем элементы ниже главной диагонали (без учета главной диагонали)
            for (int i = 1; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < n - i; j++)
                {
                    sum += matrix[i + j, j];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            Console.WriteLine($"Максимум среди сумм элементов диагоналей, параллельных главной диагонали: {maxSum}");

        }
    }
}