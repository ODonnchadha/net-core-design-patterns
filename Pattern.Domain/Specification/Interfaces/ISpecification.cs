namespace Pattern.Domain.Specification.Interfaces
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
