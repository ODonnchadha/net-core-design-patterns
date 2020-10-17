namespace Pattern.Structural.Composite.Models
{
    public class Square : Graph
    {
        public override string Name => $"{this.GetType().Name}";
    }
}
