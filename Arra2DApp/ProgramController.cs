using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Arra2DApp
{
    public static class ProgramController
    {
        public static void InitializeProgram()
        {
            ConsoleInterface.OutputOfProgramTitle();

            var array2D = ConsoleInterface.BuildArray2D();

            while (true)
            {
                ConsoleInterface.ProgramControlOutput(array2D);
                var numberOfOperation = Console.ReadLine();

                if (numberOfOperation.ToLower() == "q") break;

                MakeOperationOnArray(numberOfOperation, array2D);
            }
        }



        private static void MakeOperationOnArray(string operation, int[,] array2D)
        {
            switch (operation)
            {
                case "1":
                    Array2D.OutputQuantityNegativeNumbersInArray2D(array2D);
                    break;
                case "2":
                    Array2D.OutputQuantityPositiveNumbersInArray2D(array2D);
                    break;
                case "3":
                    Array2D.SortArray();
                    break;
                case "4":
                    Array2D.InvertArray();
                    break;
            }



        }
    }
}
