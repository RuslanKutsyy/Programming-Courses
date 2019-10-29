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
            int pointX = point.X;
            int pointY = point.Y;

            if (pointX >= this.points[0].X && pointX <= this.points[1].X)
            {
                if (pointY <= this.points[0].Y && pointY >= this.points[1].Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
