using Pattern.Domain.Specification.Interfaces;
using Pattern.Domain.Specification.Models;

namespace Pattern.Domain.Specification
{
    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;
        public SizeSpecification(Size size) => this.size = size;
        public bool IsSatisfied(Product t) => t.Size == size;
    }
}
