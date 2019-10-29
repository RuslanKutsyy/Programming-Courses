using System;
using System.Linq;

namespace Point_in_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            coordinates = CoordinatesCheck(coordinates);

            int topLeftX = coordinates[0];
            int topLeftY = coordinates[1];
            int bottomRightX = coordinates[2];
            int bottomRightY = coordinates[3];

            
            Point a = new Point(topLeftX, topLeftY);
            Point b = new Point(bottomRightX, bottomRightY);

            Rectangle rectangle = new Rectangle(a, b);

            int nums = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums; i++)
            {
                var pointCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Point newPoint = new Point(pointCoordinates[0], pointCoordinates[1]);
                Console.WriteLine(rectangle.Contains(newPoint));
            }
        }

        static int[] CoordinatesCheck(int[] coordinates)
        {
            int topLeftX = coordinates[0];
            int topLeftY = coordinates[1];
            int bottomRightX = coordinates[2];
            int bottomRightY = coordinates[3];

            if (topLeftX > bottomRightX)
            {
                int temp = bottomRightX;
                bottomRightX = topLeftX;
                topLeftX = temp;
            }

            if (topLeftY < bottomRightY)
            {
                int temp = bottomRightY;
                bottomRightY = topLeftY;
                topLeftY = temp;
            }
            coordinates[0] = topLeftX;
            coordinates[1] = topLeftY;
            coordinates[2] = bottomRightX;
            coordinates[3] = bottomRightY;

            return coordinates;
        }
    }
}
