using Structural.Adapter.Models;

namespace Structural.Adapter.Interfaces
{
    public interface IDrawPoint
    {
        void Draw(Point p);
        int GetTotal();
    }
}
