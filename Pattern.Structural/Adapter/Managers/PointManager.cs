using Pattern.Structural.Adapter.Interfaces;
using Pattern.Structural.Adapter.Models;

namespace Pattern.Structural.Adapter.Managers
{
    public class PointManager : IDrawPoint
    {
        private static int count;
        public void Draw(Point p) => ++count;
        public int GetTotal() => count;
    }
}
