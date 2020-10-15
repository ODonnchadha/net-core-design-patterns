using Pattern.Domain.Specification.Interfaces;
using Pattern.Domain.Specification.Models;

namespace Pattern.Domain.Specification
{
    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color) => this.color = color;
        public bool IsSatisfied(Product t) => t.Color == color;
    }
}
