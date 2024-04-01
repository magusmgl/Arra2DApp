using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if (array2D[i, j] < 0) counter++;
                }
            }

            Console.WriteLine($"\nКоличество отрицательных чисел в массиве - {counter}");
        }

        public static void OutputQuantityPositiveNumbersInArray2D(int[,] array2D)
        {
            int counter = 0;
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if (array2D[i, j] >= 0) counter++;
                }
            }

            Console.WriteLine($"\nКоличество положительных чисел в массиве - {counter}");
        }
        public static int[] QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex) return array;

            int pivot = GetPivot(array, leftIndex, rightIndex);
            QuickSort(array, leftIndex, pivot - 1);
            QuickSort(array, pivot + 1, rightIndex);

            return array;
        }

        private static int GetPivot(int[] array, int leftIndex, int rightIndex)
        {
            var pivot = leftIndex - 1;
            for (int i = leftIndex; i < rightIndex; i++)
            {
                if (array[i] < array[rightIndex])
                {
                    pivot++;
                    (array[i], array[pivot]) = (array[pivot], array[i]);
                }
            }
            pivot++;
            (array[rightIndex], array[pivot]) = (array[pivot], array[rightIndex]);
            return pivot;
        }

        public static void InvertSubarrayInArray2D(int[,] array2D, int indexSortingArray)
        {
            int[] arrayToInvert = GetSubarrayFromArray2D(array2D, indexSortingArray);

            invertElementsOfArray(arrayToInvert);

            UpdateSubarrayInArray(array2D, indexSortingArray, arrayToInvert);

        }

        private static void invertElementsOfArray(int[] arrayToInvert)
        {
            var length = arrayToInvert.Length;
            for (int i = 0; i < arrayToInvert.Length / 2; i++)
            {
                (arrayToInvert[i], arrayToInvert[length - 1 - i]) = (arrayToInvert[length - 1 - i], arrayToInvert[i]);
            }
        }

        private static void UpdateSubarrayInArray(int[,] array2D, int indexOfArray, int[] newArray)
        {
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                if (i == indexOfArray)
                {
                    for (int j = 0; j < array2D.GetLength(1); j++)
                    {
                        array2D[i, j] = newArray[j];
                    }
                }
            }
        }

        public static void SortSubarrayInArray2D(int[,] array2D, int indexSortingArray, bool isAscendingOrder = true)
        {
            int[] arrayToSort = GetSubarrayFromArray2D(array2D, indexSortingArray);

            QuickSort(arrayToSort, 0, arrayToSort.Length - 1);

            if (isAscendingOrder == false)
            {
                invertElementsOfArray(arrayToSort);
            }

            UpdateSubarrayInArray(array2D, indexSortingArray, arrayToSort);
        }

        private static int[] GetSubarrayFromArray2D(int[,] array2D, int indexOfArray)
        {
            return Enumerable.Range(0, array2D.GetLength(1)).Select(x => array2D[indexOfArray, x]).ToArray();
        }
    }
}
