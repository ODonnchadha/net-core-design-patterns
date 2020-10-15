using Pattern.Structural.Bridge.Abstractions;
using Pattern.Structural.Bridge.Interfaces;

namespace Pattern.Structural.Bridge.Models
{
    public class Circle : Shape
    {
        public float Radius { get; private set; }
        public Circle(IRenderer renderer, float radius) : base(renderer) => this.Radius = radius;
        public override string Draw() => renderer.RenderCircle(Radius);
        public override void Resize(float factor) => Radius *= factor;
    }
}
