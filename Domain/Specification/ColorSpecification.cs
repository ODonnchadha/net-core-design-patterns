using Domain.Specification.Interfaces;
using Domain.Specification.Models;

namespace Domain.Specification
{
    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color) => this.color = color;
        public bool IsSatisfied(Product t) => t.Color == color;
    }
}
