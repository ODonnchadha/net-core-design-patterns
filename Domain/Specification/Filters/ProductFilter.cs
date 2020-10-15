using Pattern.Domain.Specification.Interfaces;
using Pattern.Domain.Specification.Models;
using System.Collections.Generic;

namespace Pattern.Domain.Specification.Filters
{
    public class ProductFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(
            IEnumerable<Product> items, ISpecification<Product> specification)
        {
            foreach (var item in items)
            {
                if (specification.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }
}
