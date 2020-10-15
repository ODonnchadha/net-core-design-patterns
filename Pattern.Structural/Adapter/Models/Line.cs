namespace Pattern.Structural.Adapter.Models
{
    public class Line
    {
        public Point Start { get; private set; }
        public Point End { get; private set; }
        public Line(Point start, Point end)
        {
            this.Start = start; this.End = end;
        }

        protected bool Equals(Line other) => Equals(Start, other.Start) && Equals(End, other.End);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((Line)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Start != null ? Start.GetHashCode() : 0) * 397) ^ (End != null ? End.GetHashCode() : 0);
            }
        }
    }
}
