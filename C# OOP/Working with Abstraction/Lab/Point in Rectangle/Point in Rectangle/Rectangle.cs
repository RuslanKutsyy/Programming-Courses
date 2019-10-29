using System;
using System.Collections.Generic;
using System.Text;

namespace Point_in_Rectangle
{
    class Rectangle
    {
        private Point[] points;

        public Rectangle(Point topPoint, Point bottomPoint)
        {
            this.points = new Point[2];
            this.points[0] = topPoint;
            this.points[1] = bottomPoint;
        }

        public bool Contains(Point point)
        {
            if (point.X >= this.points[0].X && point.X <= this.points[1].X && point.Y <= this.points[0].Y && point.Y >= this.points[1].Y)
            {
                return true;
            }
            return false;
        }
    }
}
