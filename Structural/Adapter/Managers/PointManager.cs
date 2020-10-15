using Structural.Adapter.Interfaces;
using Structural.Adapter.Models;

namespace Structural.Adapter.Managers
{
    public class PointManager : IDrawPoint
    {
        private static int count;
        public void Draw(Point p) => ++count;
        public int GetTotal() => count;
    }
}
