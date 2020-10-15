using Pattern.Structural.Adapter.Models;

namespace Pattern.Structural.Adapter.Interfaces
{
    public interface IDrawPoint
    {
        void Draw(Point p);
        int GetTotal();
    }
}
