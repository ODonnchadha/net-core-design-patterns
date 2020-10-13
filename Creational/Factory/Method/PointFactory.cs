using Creational.Factory.Method.Models;
using System;

namespace Creational.Factory.Method
{
    public static class PointFactory
    {
        public static Point CartesianPoint(double x, double y) =>
            new Point(x, y);
        public static Point PolarPoint(double rho, double theta) =>
            new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }
}
