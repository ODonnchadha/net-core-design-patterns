using Domain.Specification.Interfaces;
using Domain.Specification.Models;

namespace Domain.Specification
{
    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;
        public SizeSpecification(Size size) => this.size = size;
        public bool IsSatisfied(Product t) => t.Size == size;
    }
}
