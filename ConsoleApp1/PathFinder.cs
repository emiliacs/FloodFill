using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class PathFinder
    {
       
        public static void PathFinding()
        {
            Random rnd = new Random();
            int xStart, yStart, yEnd, xEnd;

            char[][] matrix = new char[][] { new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},
                                       new char[] {'-', '-', '-', '-', '-', '-', '-'},};

            for (int i = 0; i < 15; i++)
            {
                var obstacleY = rnd.Next(0, 7);
                var obstacleX = rnd.Next(0, 7);

                matrix[obstacleY][obstacleX] = 'o';
            }

            Printing.PrintingMatrix(matrix);

            Console.Write("Give me a start position (Y axel): ");
            yStart = int.Parse(Console.ReadLine());
            NumberCheck(yStart);
            Console.Write("\nGive me a start position (X axel): ");
            xStart = int.Parse(Console.ReadLine());
            NumberCheck(xStart);
            Console.Write("\nGive me a end position (Y axel): ");
            yEnd = int.Parse(Console.ReadLine());
            NumberCheck(yEnd);
            Console.Write("\nGive me a start position (X axel): ");
            xEnd = int.Parse(Console.ReadLine());
            NumberCheck(xEnd);


            Console.WriteLine("\nStarting at location {" + yStart + "," + xStart + "}." +
                " And ending at location {" + yEnd + "," + xEnd + "}");

            yStart = yStart - 1;
            yEnd = yEnd - 1;
            xStart = xStart - 1;
            xEnd = xEnd - 1;

            matrix[yStart][xStart] = 'A';
            matrix[yEnd][xEnd] = 'B';
           Printing.PrintingMatrix(matrix);
            var starting = matrix.FirstOrDefault(x => x.Contains('A'));
            var ending = matrix.FirstOrDefault(x => x.Contains('B'));

            var start = new Location();
            start.Y = yStart;
            start.X = xStart;

            var finish = new Location();
            finish.Y = yEnd;
            finish.X = xEnd;

            start.SetDistance(finish.X, finish.Y);

            var activeLocations = new List<Location>();
            activeLocations.Add(start);
            var visitedLocations = new List<Location>();

            while (activeLocations.Any())
            {
                var checkLocation = activeLocations.OrderBy(x => x.CostOfDistance).First();

                if (checkLocation.X == finish.X && checkLocation.Y == finish.Y)
                {
                    var location = checkLocation;

                    while (true)
                    {

                        if (matrix[location.Y][location.X] == '-')
                        {
                            var newMapRow = matrix[location.Y];
                            newMapRow[location.X] = '*';
                            matrix[location.Y] = (newMapRow).ToArray();
                        }
                        location = location.PreviousLocation;
                        if (location == null)
                        {
                            Console.WriteLine("Here is your path");
                            Printing.PrintingWithWaiting(matrix);
                            Console.WriteLine("Done!");
                            return;
                        }
                    }

                }
                visitedLocations.Add(checkLocation);
                activeLocations.Remove(checkLocation);

                var walkableLocations = Routes(matrix, checkLocation, finish);

                foreach (var walkableLocation in walkableLocations)
                {

                    if (visitedLocations.Any(x => x.X == walkableLocation.X && x.Y == walkableLocation.Y))
                    {
                        continue;
                    }

                    if (activeLocations.Any(x => x.X == walkableLocation.X && x.Y == walkableLocation.Y))
                    {
                        var existingLocation = activeLocations.First(x => x.X == walkableLocation.X && x.Y == walkableLocation.Y);
                        if (existingLocation.CostOfDistance > checkLocation.CostOfDistance)
                        {
                            activeLocations.Remove(existingLocation);
                            activeLocations.Add(walkableLocation);
                        }
                    }
                    else
                    {
                        activeLocations.Add(walkableLocation);
                    }

                }
            }
            Console.WriteLine("No path found");

        }
        public static int NumberCheck(int number)
        {
            while (number < 1 || number > 7)
            {
                Console.WriteLine("Number needs to be between 1 and 7");
                number = int.Parse(Console.ReadLine());
            }

            return number;
        }
        private static List<Location> Routes(char[][] matrix, Location Current, Location Target)
        {
            var possibleLocations = new List<Location>()
            {
                new Location { X = Current.X, Y = Current.Y - 1, PreviousLocation = Current, Moves = Current.Moves + 1 },
                new Location { X = Current.X, Y = Current.Y + 1, PreviousLocation = Current, Moves = Current.Moves + 1},
                new Location { X = Current.X - 1, Y = Current.Y, PreviousLocation = Current, Moves = Current.Moves + 1 },
                new Location { X = Current.X + 1, Y = Current.Y, PreviousLocation = Current, Moves = Current.Moves + 1 },
            };

            possibleLocations.ForEach(location => location.SetDistance(Target.X, Target.Y));
            var maxX = matrix.First().Length - 1;
            var maxY = matrix.First().Length - 1;

            return possibleLocations.Where(location => location.X >= 0 && location.X <= maxX)
            .Where(loaction => loaction.Y >= 0 && loaction.Y <= maxY)
            .Where(location => matrix[location.Y][location.X] == '-' || matrix[location.Y][location.X] == 'B')
            .ToList();
        }
        class Location
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Moves { get; set; }
            public int Distance { get; set; }
            public int CostOfDistance => Moves + Distance;
            public Location PreviousLocation { get; set; }

            public void SetDistance(int targetX, int targetY)
            {
                this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
            }
        }
    }
}



