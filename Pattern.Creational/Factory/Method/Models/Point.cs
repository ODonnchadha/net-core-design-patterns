﻿namespace Pattern.Creational.Factory.Method.Models
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point(double x, double y)
        {
            this.X = x; this.Y = y;
        }
    }
}
