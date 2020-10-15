using Structural.Adapter.Models;
using System;
using System.Collections.ObjectModel;

namespace Structural.Adapter
{
    public class LineToPointAdapter : Collection<Point>
    {
        public LineToPointAdapter(Line line)
        {
            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);

            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);

            // Either vertical or horizontal.
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; y++)
                {
                    Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = top; x <= right; x++)
                {
                    Add(new Point(x, top));
                }
            }
        }
    }
}
