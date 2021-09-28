using System;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
   
            Console.Write("Do you want to play flooding game (0) or pathfinder (1)?  ");

            int answer = int.Parse(Console.ReadLine());

            if (answer == 0)
            {
                Flood.Flooding();
            }
            else if (answer == 1)
            {
                PathFinder.PathFinding();
            }
            else
            {
                Console.WriteLine("Goodbye");
            }

        }

    }


}

