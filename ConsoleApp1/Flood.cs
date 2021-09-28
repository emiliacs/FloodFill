using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp1
{
    class Flood
    {

        public static void Waiting()
        {
            Console.WriteLine("Continue by pressing enter");

            while (!(Console.ReadKey(true).Key == ConsoleKey.Enter)) { }

            Console.Clear();
        }
      
        public static void PrintingWithWaiting(char[][] matrix)
        {
            Console.WriteLine("");
            Console.WriteLine("  1 2 3 4 5 6 7");
            int i = 1;
            foreach (var row in matrix)
            {
                Console.Write(i + " ");

                foreach (var sign in row)
                {
                    Console.Write(sign + " ");
                    Thread.Sleep(100);
                }

                Console.Write("\n");
                i++;

            }
            Console.WriteLine("");
        }
        public static void FloodSteps(int y, int x, char[][] matrix)
        {
            if (y >= 6)
            {
                y = 6;
            }
            else if (y < 0)
            {
                y = 1;
            }
            if (x >= 7)
            {
                x = 6;
            }
            else if (x < 0)
            {
                x = 1;
            }

            if (matrix[y][x] != 'o' && matrix[y][x] != 'x')
            {
                matrix[y][x] = '~';
            }
        }
        public static void Flooding()
        {
            int y, x;
            Random rnd = new Random();

            char[][] matrix = new char[][] { new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
            };

            for (int i = 0; i < 15; i++)
            {
                var esteetY = rnd.Next(0, 7);
                var esteetX = rnd.Next(0, 7);
                matrix[esteetY][esteetX] = 'o';
            }

            Printing.PrintingMatrix(matrix);

            Console.WriteLine("\nFirst give a location where to start the flood.\n");
            Console.Write("\nGive a first number between 1 and 7  axel to start the flood (Y axel) :  ");

            y = int.Parse(Console.ReadLine()) - 1;
            while (y + 1 > 7 || y + 1 < 0)
            {
                Console.WriteLine("Invalid number, please give another");
                y = int.Parse(Console.ReadLine()) - 1;
            }

            Console.Write("\nGive a second number between 1 and 7 to start the flood (X axel) : ");
            x = int.Parse(Console.ReadLine()) - 1;
            while (x + 1 > 7 || x + 1 < 0)
            {
                Console.WriteLine("Invalid number, please give another");
                x = int.Parse(Console.ReadLine()) - 1;
            }

            Console.WriteLine("Your starging point is {" + (y + 1) + "," + (x + 1) + "}");
            matrix[y][x] = 'x';
            Flooding(y, x, matrix);

        }
        public static void Flooding(int y, int x, char[][] matrix)
        {
            Printing.PrintingMatrix(matrix);
            Waiting();
            List<int> locations = new List<int>();
            int i = 1;

            while (matrix.Any(row => row.Contains('-')))
            {
                int up = y - i;
                int down = y + i;
                int left = x - i;
                int right = x + i;

                locations.Add(up);
                locations.Add(down);
                locations.Add(left);
                locations.Add(right);
                locations.Add(up - i);
                locations.Add(down - i);
                locations.Add(left - i);
                locations.Add(right - i);
                locations.Add(up + i);
                locations.Add(down + i);
                locations.Add(left + i);
                locations.Add(right + i);
                i++;

                foreach (var item in locations)
                {
                    FloodSteps(item, right, matrix);
                    FloodSteps(up, item, matrix);
                    FloodSteps(down, item, matrix);
                    FloodSteps(item, left, matrix);
                    FloodSteps(item, item, matrix);

                }
                Printing.PrintingMatrix(matrix);
                Waiting();
            }

        }
    }
}
