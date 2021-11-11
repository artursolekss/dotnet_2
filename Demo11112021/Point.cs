using System;

namespace Demo11112021
{
    class Point
    {
        private readonly double x;
        public double X { get { return x; } }

        private readonly double y;
        public double Y { get { return y; } }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        //private void RandomMethod()
        //{
        //    this.x = 332;
        //}
    }
}
