using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Arra2DApp
{
    internal class ConsoleInterface
    {
        private const string EmptyStringError = "Введена пустая строка. Введите данные еще раз:\t";
        private const string WrongStringError = "Некорректная строка. Введите данные еще раз:\t";
        private const string NegativeNumbersError = "Значения измерений не может быть отрицательным числом. Введите данные еще раз:\t";

        public static void OutputOfProgramTitle()
        {
            Console.Clear();
            var programName = "Программа для создания и работы с двухмерными массивами\r";
            Console.WriteLine(programName);
            Console.WriteLine(new string('-', programName.Length));
            Console.WriteLine();
        }
        public static int[,] BuildArray2D()
        {
            Console.Write("Для начала введите длину первого и второго измерения через пробел: ");
            var listOfDimensionLengths = getNumbersFromInput();
            var lengthOfOneDimension = listOfDimensionLengths[0];
            var lengthOfTwoDimension = listOfDimensionLengths[1];

            var array2D = new int[lengthOfOneDimension, lengthOfTwoDimension];

            for (var i = 0; i < lengthOfOneDimension; i++)
            {
                Console.Write($"Введите через пробел {lengthOfTwoDimension} чисел для {i + 1} массива матрицы: ");

                List<int>? elementsArray = getNumbersFromInput(lengthOfTwoDimension);
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i, j] = elementsArray[j];
                }
            }

            return array2D;
        }

        public static void ProgramControlOutput(int[,] array2D)
        {
            Console.Clear();
            ConsoleInterface.OutputOfProgramTitle();

            Array2D.Print2DArray(array2D);
            Console.WriteLine("""
                              Выберите операцию из следующего списка:
                              1 - Найти количество положительных чисел в матрице
                              2 - Найти количество отрицательных чисел в матрице
                              3 - Сортировка элементов матрицы построчно
                              4 - Инверсия элементов матрицы построчно
                              """);

        }

        private static void WriteErrorInConsole(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Ошибочный ввод: {msg}");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private static List<int>? ConvertAllElementsInListToNumbers(List<string> listOfStrings)
        {
            var isAllNumbers = listOfStrings.All(s => int.TryParse(s, out _));
            return isAllNumbers ? listOfStrings.Select(int.Parse).ToList() : null;
        }

        private static List<int>? getNumbersFromInput(int requiredNumberOfElements = 2, bool isNegativeNumbersAllow = false)
        {
            char[] separators = { ' ', ',', '.', '/' };
            do
            {
                var input = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    WriteErrorInConsole(EmptyStringError);
                    continue;
                }

                var listOfStrings = new List<string>(input.Split(separators));
                var listNumbers = ConvertAllElementsInListToNumbers(listOfStrings);

                if (listNumbers.Count != requiredNumberOfElements)
                {
                    WriteErrorInConsole(WrongStringError);
                    continue;
                }

                if (isNegativeNumbersAllow == false && listNumbers.Any(numbers => numbers < 0))
                {
                    WriteErrorInConsole(NegativeNumbersError);
                    continue;
                }

                return listNumbers;
            } while (true);
        }
    }
}
