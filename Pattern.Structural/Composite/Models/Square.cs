namespace Pattern.Structural.Composite.Models
{
    public class Square : GraphComposite
    {
        public override string Name => $"{this.GetType().Name}";
    }
}
