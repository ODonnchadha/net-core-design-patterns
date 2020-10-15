using Pattern.Structural.Bridge.Interfaces;

namespace Pattern.Structural.Bridge.Managers
{
    public class VectorRenderer : IRenderer
    {
        public string RenderCircle(float radius) => $"{this.GetType().Name} {radius}";
    }
}
