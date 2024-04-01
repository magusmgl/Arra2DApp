using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Arra2DApp
{
    public static class ProgramController
    {
        public static void RunProgram()
        {
            ConsoleInterface.OutputOfProgramTitle();

            var array2D = ConsoleInterface.BuildArray2D();

            while (true)
            {
                ConsoleInterface.arrayOperationsMenu(array2D);
                string numberOfOperation = Console.ReadLine();

                if (numberOfOperation.ToLower() == "q") break;

                ConsoleInterface.MakeOperationOnArray2D(numberOfOperation, array2D);
            }
        }
    }
}
