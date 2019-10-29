using System;
using System.Linq;

namespace Point_in_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int topLeftX = coordinates[0];
            int topLeftY = coordinates[1];
            int bottomRightX = coordinates[2];
            int bottomRightY = coordinates[3];

            int nums = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums; i++)
            {
                var pointCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Point newPoint = new Point(pointCoordinates[0], pointCoordinates[1]);
                
            }
            Point point = new Point(5, 6);
        }
    }
}
