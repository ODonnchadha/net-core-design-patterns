using Pattern.Structural.Bridge.Interfaces;

namespace Pattern.Structural.Bridge.Abstractions
{
    public abstract class Shape
    {
        protected IRenderer renderer;
        public Shape(IRenderer renderer) => this.renderer = renderer;
        public abstract string Draw();
        public abstract void Resize(float factor);
    }
}
