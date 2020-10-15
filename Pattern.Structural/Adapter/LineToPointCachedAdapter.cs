using Pattern.Structural.Adapter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pattern.Structural.Adapter
{
    public class LineToPointCacheAdapter : IEnumerable<Point>
    {
        static Dictionary<int, List<Point>> cache = new Dictionary<int, List<Point>> { };
        public LineToPointCacheAdapter(Line line)
        {
            var hash = line.GetHashCode();
            if (cache.ContainsKey(hash))
            {
                return;
            }

            var points = new List<Point>();

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
                    points.Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = top; x <= right; x++)
                {
                    points.Add(new Point(x, top));
                }
            }

            cache.Add(hash, points);
        }

        public IEnumerator<Point> GetEnumerator() => cache.Values.SelectMany(c => c).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
