namespace Structural.Adapter.Models
{
    public class Line
    {
        public Point Start { get; private set; }
        public Point End { get; private set; }
        public Line(Point start, Point end)
        {
            this.Start = start; this.End = end;
        }
    }
}
