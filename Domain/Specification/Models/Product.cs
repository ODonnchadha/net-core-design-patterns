namespace Domain.Specification.Models
{
    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;
        public Product(string name, Color color, Size size)
        {
            this.Name = name; this.Color = color; this.Size = size;
        }
    }
}
