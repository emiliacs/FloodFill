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
/*Console.Write("  1 2 3 4 5 6 7\n");

            Random rnd = new Random();
            var numero1 = rnd.Next(1, 3) + 1;
            var numero2 = rnd.Next(1, 3) + 1;

            for (int i = 1; i < 7; i++)
            {

                Console.Write("{0} - ", i);

                //else if (i == numero1 || i == numero2)
                //{
                //    Console.Write("{0} o ", i);
                //}

                for (int j = 8; j > 1; j--)
                {

                    if (i == numero1 && j == numero2)
                    {
                        int ekatViivat = numero2 - 2;
                        int tokatViivat = 7 - numero2;
                        for (int x = 0; x < ekatViivat; x++)
                        {
                            Console.Write("- ");
                        }
                        Console.Write("o ");

                        for (int y = 0; y < tokatViivat; y++)
                        {
                            Console.Write("- ");

                            numero1 = rnd.Next(1, 6) + 1;
                            numero2 = rnd.Next(1, 6) + 1;
                        }
                    }


                    else if (i != numero1 && j != numero2)
                    {
                        Console.Write("- ");
                    }
                }
                Console.Write("\n");
            }*/
//public static void trying(int y, int x, char[][] matrix)
//{
//    Printing(matrix);
//    Waiting();

//    int[] lista = new int[100];

//    int i = 1;
//    int a = 1;
//    int alkup = y;
//    int alkupx = x;

//    while (i != 43)
//    {

//        int up = y - 1;
//        int down = y + 1;
//        int left = x - 1;
//        int right = x + 1;


//        FloodSteps(up, x, matrix);
//        FloodSteps(down, x, matrix);

//        FloodSteps(y, right, matrix);
//        FloodSteps(y, left, matrix);

//        FloodSteps(up, right, matrix);
//        FloodSteps(up, left, matrix);

//        FloodSteps(down, right, matrix);
//        FloodSteps(down, left, matrix);


//        //Printing(matrix);

//        //Waiting();

//        switch (i)
//        {
//            case 2:
//                y = y - a;
//                x = alkupx;
//                break;
//            case 3:
//                y = y + a;
//                x = alkupx + a;
//                break;
//            case 4:
//                y = alkup + a;
//                x = alkupx;
//                break;
//            case 5:
//                y = alkup;
//                x = alkupx - a;
//                break;
//            case 6:
//                y = alkup - a;
//                x = alkupx + a;
//                break;
//            case 7:
//                y = alkup + a;
//                x = alkupx + a;
//                break;
//            case 8:
//                y = alkup + a;
//                x = alkupx - a;
//                break;
//            case 9:
//                y = alkup - a;
//                x = alkupx - a;
//                a++;
//                break;
//            case 10:
//                y = y - a;
//                x = alkupx;
//                break;
//            case 11:
//                y = y + a;
//                x = alkupx + a;
//                break;
//            case 12:
//                y = alkup + a;
//                x = alkupx;
//                break;
//            case 13:
//                y = alkup;
//                x = alkupx - a;
//                break;
//            case 14:
//                y = alkup - a;
//                x = alkupx + a;
//                break;
//            case 15:
//                y = alkup + a;
//                x = alkupx + a;
//                break;
//            case 16:
//                y = alkup + a;
//                x = alkupx - a;
//                break;
//            case 17:
//                y = alkup - a;
//                x = alkupx - a;
//                a++;
//                break;
//            case 18:
//                y = y - a;
//                x = alkupx;
//                break;
//            case 19:
//                y = y + a;
//                x = alkupx + a;
//                break;
//            case 20:
//                y = alkup + a;
//                x = alkupx;
//                break;
//            case 21:
//                y = alkup;
//                x = alkupx - a;
//                break;
//            case 22:
//                y = alkup - a;
//                x = alkupx + a;
//                break;
//            case 23:
//                y = alkup + a;
//                x = alkupx + a;
//                break;
//            case 24:
//                y = alkup + a;
//                x = alkupx - a;
//                break;
//            case 25:
//                y = alkup - a;
//                x = alkupx - a;
//                a++;
//                break;
//            case 26:
//                y = y - a;
//                x = alkupx;
//                break;
//            case 27:
//                y = y + a;
//                x = alkupx + a;
//                break;
//            case 28:
//                y = alkup + a;
//                x = alkupx;
//                break;
//            case 29:
//                y = alkup;
//                x = alkupx - a;
//                break;
//            case 30:
//                y = alkup - a;
//                x = alkupx + a;
//                break;
//            case 31:
//                y = alkup + a;
//                x = alkupx + a;
//                break;
//            case 32:
//                y = alkup + a;
//                x = alkupx - a;
//                break;
//            case 33:
//                y = alkup - a;
//                x = alkupx - a;
//                a++;
//                break;
//            case 34:
//                y = y - a;
//                x = alkupx;
//                break;
//            case 35:
//                y = y + a;
//                x = alkupx + a;
//                break;
//            case 36:
//                y = alkup + a;
//                x = alkupx;
//                break;
//            case 37:
//                y = alkup;
//                x = alkupx - a;
//                break;
//            case 38:
//                y = alkup - a;
//                x = alkupx + a;
//                break;
//            case 39:
//                y = alkup + a;
//                x = alkupx + a;
//                break;
//            case 40:
//                y = alkup + a;
//                x = alkupx - a;
//                break;
//            case 41:
//                y = alkup - a;
//                x = alkupx - a;
//                a++;
//                Printing(matrix);
//                Waiting();
//                break;
//        }

//        i++;

//    }


//}


//public static void Calculating(int y, int x, char[][] matrix)
//{
//    int up, down, left, right, lounasY, luodeY, kaakkoX, lounasX;

//    Printing(matrix);

//    Waiting();

//    up = y - 1;
//    down = y + 1;
//    left = x - 1;
//    right = x + 1;


//    FloodSteps(up, x, matrix);
//    FloodSteps(down, x, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(y, left, matrix);

//    Printing(matrix);

//    Waiting();


//    int alkup = y;
//    int alkupX = x;

//    y = up;

//    up = y - 1;
//    down = y + 1;
//    left = x - 1;
//    right = x + 1;

//    FloodSteps(up, x, matrix);
//    FloodSteps(down, x, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(y, left, matrix);

//    Printing(matrix);

//    Waiting();


//    y = alkup;
//    x = right;

//    up = y - 1;
//    down = y + 1;
//    left = x - 1;
//    right = x + 1;

//    FloodSteps(up, x, matrix);
//    FloodSteps(down, x, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(y, left, matrix);


//    Printing(matrix);

//    Waiting();

//    y = down;
//    x = alkupX;

//    up = y - 1;
//    down = y + 1;
//    left = x - 1;
//    right = x + 1;

//    FloodSteps(up, x, matrix);
//    FloodSteps(down, x, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(y, left, matrix);


//    Printing(matrix);

//    Waiting();

//    y = alkup;
//    x = left;

//    up = y - 1;
//    down = y + 1;
//    left = x - 1;
//    right = x + 1;

//    FloodSteps(up, x, matrix);
//    FloodSteps(down, x, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(y, left, matrix);

//    Printing(matrix);

//    Waiting();

//    y = alkup - 1;
//    x = alkupX + 1;

//    up = y - 1;
//    right = x + 1;

//    FloodSteps(up, x, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(up, right, matrix);


//    Printing(matrix);

//    Waiting();

//    y = alkup + 1;
//    x = alkupX + 1;

//    down = y + 1;
//    right = x + 1;

//    FloodSteps(down, x, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(down, right, matrix);


//    Printing(matrix);

//    Waiting();

//    y = alkup + 1;
//    x = alkupX - 1;

//    down = y + 1;
//    left = x - 1;

//    FloodSteps(down, x, matrix);
//    FloodSteps(y, left, matrix);
//    FloodSteps(down, left, matrix);


//    Printing(matrix);

//    Waiting();

//    y = alkup - 1;
//    x = alkupX - 1;

//    up = y - 1;
//    left = x - 1;

//    FloodSteps(up, x, matrix);
//    FloodSteps(y, left, matrix);
//    FloodSteps(up, left, matrix);


//    Printing(matrix);

//    Waiting();


//    y = alkup - 2;
//    x = alkupX;

//    up = y - 1;
//    left = x - 1;
//    right = x + 1;

//    FloodSteps(up, x, matrix);
//    FloodSteps(y, left, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(up, left, matrix);
//    FloodSteps(up, right, matrix);


//    Printing(matrix);

//    Waiting();


//    y = alkup;
//    x = alkupX + 2;

//    up = y - 1;
//    down = y + 1;
//    right = x + 1;


//    FloodSteps(up, x, matrix);
//    FloodSteps(down, x, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(up, right, matrix);
//    FloodSteps(down, right, matrix);


//    Printing(matrix);

//    Waiting();

//    y = alkup;
//    x = alkupX - 2;

//    left = x - 1;
//    lounasY = y + 1;
//    luodeY = y - 1;

//    FloodSteps(y, left, matrix);
//    FloodSteps(luodeY, left, matrix);
//    FloodSteps(lounasY, left, matrix);


//    Printing(matrix);

//    Waiting();

//    y = alkup + 2;
//    x = alkupX;

//    down = y + 1;
//    kaakkoX = x + 1;
//    lounasX = x - 1;

//    FloodSteps(down, x, matrix);
//    FloodSteps(down, kaakkoX, matrix);
//    FloodSteps(down, lounasX, matrix);


//    Printing(matrix);

//    Waiting();

//    y = alkup - 2;
//    x = alkupX + 2;

//    up = y - 1;
//    right = x + 1;

//    FloodSteps(up, x, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(up, right, matrix);


//    Printing(matrix);

//    Waiting();

//    y = alkup + 2;
//    x = alkupX + 2;

//    down = y + 1;
//    right = x + 1;

//    FloodSteps(down, x, matrix);
//    FloodSteps(y, right, matrix);
//    FloodSteps(down, right, matrix);


//    Printing(matrix);

//    Waiting();

//    y = alkup + 2;
//    x = alkupX - 2;

//    down = y + 1;
//    left = x - 1;

//    FloodSteps(down, x, matrix);
//    FloodSteps(y, left, matrix);
//    FloodSteps(down, left, matrix);


//    Printing(matrix);

//    Waiting();

//    y = alkup - 2;
//    x = alkupX - 2;

//    up = y - 1;
//    left = x - 1;

//    FloodSteps(up, x, matrix);
//    FloodSteps(y, left, matrix);
//    FloodSteps(up, left, matrix);

//    Printing(matrix);

//    Waiting();


//}