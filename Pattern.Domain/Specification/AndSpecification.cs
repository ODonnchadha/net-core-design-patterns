﻿using Pattern.Domain.Specification.Interfaces;

namespace Pattern.Domain.Specification
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first;
        private ISpecification<T> second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first; this.second = second;
        }
        public bool IsSatisfied(T t) => first.IsSatisfied(t) && second.IsSatisfied(t);
    }
}
