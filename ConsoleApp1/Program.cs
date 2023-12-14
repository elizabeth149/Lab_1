using System.Drawing;
using System.Numerics;
//Вариант 3
namespace ConsoleApp1
{
    public class Program
    {
        // Объявление публичного статического массива
        public static int[] arr;

        // Основной метод, точка входа в программу
        static void Main(string[] args)
        {
            Console.WriteLine("Вариант 3");
            Console.WriteLine("Часть 1");
            Console.WriteLine("");
            Console.Write("Введите размер массива: ");

            int N = int.Parse(Console.ReadLine());

            // Вызов метода Zapolnenie для заполнения массива случайными значениями типа double
            double[] arr = Zapolnenie(N);

            Console.WriteLine("Исходный массив:" );
            PrintArray(arr);

            // Вычисление и вывод суммы элементов с нечетными индексами
            double t = Sum_Nechet(arr);
            Console.WriteLine($"Сумма элементов с нечетными номерами: {t}");
            // Переменные отвечают за поиск первого и последнего отрицательных элементов в массиве
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
            // Вычисление и вывод суммы элементов между первым и последним отрицательными
            double r = Sum_Otric(arr, firstNegativeIndex, lastNegativeIndex);
            Console.WriteLine($"Сумма элементов между первым и последним отрицательными элементами: {r}");

            //  Удаление элементов, модуль которых не превышает единицу
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
            // Вычисление и вывод произведения элементов в строках без отрицательных элементов
            int e = BezNegativa(matrix);
            Console.WriteLine($"Произведение элементов в строках без отрицательных элементов: {e}");
            // Вычисление и вывод максимума среди сумм элементов диагоналей, параллельных главной диагонали
            int q = Diagonale(matrix);
            Console.WriteLine($"Максимум среди сумм элементов диагоналей, параллельных главной диагонали: {q}");


        }
        // Метод вычисляет сумму элементов между первым и последним отрицательными элементами
        public static double Sum_Otric(double[] a, int firstNegativeIndex, int lastNegativeIndex)
        {
            double sum_otric_chisel = 0;
            if (firstNegativeIndex != -1 && lastNegativeIndex != -1)
            {
                for(int i = firstNegativeIndex; i<= lastNegativeIndex; i++)
                {
                    sum_otric_chisel += a[i];
                }
            }
            return sum_otric_chisel;
        }

        //Метод нахождения суммы элементов массива с нечектными номерами
        public static double Sum_Nechet(double[] a)
        {
            double znach_1 = 0;
            for (int i = 0;i<a.Length; i += 2)
            {
                znach_1 += a[i];
            }
            return znach_1;
        }

        //Метод заполнения массива, состоящего из N вещественных элементов
        public static double[] Zapolnenie(int size) { 
            var random= new Random();
            double[] arr = new double[size];
            for (int i = 0; i< arr.Length; i++)
            {
                arr[i] = random.NextDouble() * 10;
            }
            return arr;
        }
        //Метод заполнения матрицы, состоящей из N*N целочисленных элементов
        public static int[,] Zapolnenie_2(int size)
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
        public static void PrintArray(double[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        // Метод для вывода матрицы
        public static void PrintMatrix(int[,] matrix, int size)
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
        public static int BezNegativa(int[,] matrix)
        {
            int productWithoutNegatives = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // Флаг, указывающий, есть ли отрицательные числа в текущей строке
                bool isNegative = false;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        // Если элемент отрицателен, устанавливаем флаг и прерываем цикл
                        isNegative = true;
                        break;
                    }
                }

                // Проверка флага после завершения внутреннего цикла
                if (!isNegative)
                {
                    // Если нет отрицательных элементов в строке, умножаем текущий элемент на общее произведение
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        productWithoutNegatives *= matrix[i, j];
                    }
                }
            }

            return productWithoutNegatives;
        }

        // Метод нахождения максимума среди сумм элементов диагоналей, параллельных главной диагонали матрицы
        public static int Diagonale(int[,] matrix)
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

            return maxSum; 

        }
    }
}
