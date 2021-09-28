using System;

namespace ConsoleApp1
{
    class Printing
    {
        public static void PrintingMatrix(char[][] matrix)
        {
            Console.WriteLine("");
            Console.WriteLine("  X 1 2 3 4 5 6 7");
            Console.Write("Y ");
            int i = 1;
            foreach (var row in matrix)
            {
                if (i == 1)
                {
                    Console.Write(i + " ");
                }
                else
                {
                    Console.Write("  " + i + " ");
                }

                foreach (var sign in row)
                {

                    Console.Write(sign + " ");
                }

                Console.Write("\n");

                i++;

            }
            Console.WriteLine("");
        }
    }
}
