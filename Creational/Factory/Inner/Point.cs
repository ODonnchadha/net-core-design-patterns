using System;

namespace Creational.Factory.Inner
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        private Point(double x, double y)
        {
            this.X = x; this.Y = y;
        }
        // Instantiate each time asked.
        // public static Point Origin => new Point(0, 0);

        // Initialize static field once.
        public static Point Origin = new Point(0, 0);
        public static class InnerFactory
        {
            public static Point CartesianPoint(double x, double y) =>
                new Point(x, y);
            public static Point PolarPoint(double rho, double theta) =>
                new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
}
