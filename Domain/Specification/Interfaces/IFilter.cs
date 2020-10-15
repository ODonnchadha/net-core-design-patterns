using System.Collections.Generic;

namespace Pattern.Domain.Specification.Interfaces
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }
}
