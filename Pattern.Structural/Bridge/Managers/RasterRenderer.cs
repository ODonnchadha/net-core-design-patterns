using Pattern.Structural.Bridge.Interfaces;

namespace Pattern.Structural.Bridge.Managers
{
    public class RasterRenderer : IRenderer
    {
        public string RenderCircle(float radius) => $"{this.GetType().Name} {radius}";
    }
}
