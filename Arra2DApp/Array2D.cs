using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arra2DApp
{
    public static class Array2D
    {
        public static void Print2DArray(int[,] arr)
        {
            var result = new StringBuilder();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                result.Append("|");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result.Append($" {arr[i, j],5} |");
                }

                result.AppendLine();
            }

            Console.WriteLine(result.ToString());
        }

        public static void OutputQuantityNegativeNumbersInArray2D(int[,] array2D)
        {
            int counter = 0;
            for (int i = 0; i < array2D.GetUpperBound(0); i++)
            {
                for (int j = 0; j < array2D.GetUpperBound(1); j++)
                {
                    if (array2D[i, j] < 0) counter++;
                }
            }

            Console.WriteLine($"Количество отрицательных чисел в массиве - {counter}");
        }

        public static void OutputQuantityPositiveNumbersInArray2D(int[,] array2D)
        {
            int counter = 0;
            for (int i = 0; i < array2D.GetUpperBound(0); i++)
            {
                for (int j = 0; j < array2D.GetUpperBound(1); j++)
                {
                    if (array2D[i, j] >= 0) counter++;
                }
            }

            Console.WriteLine($"Количество положительных чисел в массиве - {counter}");
        }

        private static Random random = new Random();
        private static int Partition(int left, int right, int[] arr)
        {
            var pivot = arr[random.Next(left, right)];
            var m = left;
            for (int i = left; i < right; i++)
            {
                if (arr[i] < pivot)
                {
                    (arr[i], arr[m]) = (arr[m], arr[i]);
                    m++;
                }

            }
            return m;
        }

        internal static void SortArray()
        {
            throw new NotImplementedException();
        }

        internal static void InvertArray()
        {
            throw new NotImplementedException();
        }
    }
}
