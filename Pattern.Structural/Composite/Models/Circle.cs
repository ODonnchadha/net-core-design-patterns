namespace Pattern.Structural.Composite.Models
{
    public class Circle : GraphComposite
    {
        public override string Name => $"{this.GetType().Name}";
    }
}
