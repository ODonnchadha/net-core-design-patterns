using Creational.Builder.Models;

namespace Creational.Builder.Abstractions
{
    public abstract class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build() => person;
    }
}
