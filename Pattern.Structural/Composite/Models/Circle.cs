namespace Pattern.Structural.Composite.Models
{
    public class Circle : Graph
    {
        public override string Name => $"{this.GetType().Name}";
    }
}
