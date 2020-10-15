using Pattern.Creational.Builder.Models;

namespace Pattern.Creational.Builder.Abstractions
{
    public abstract class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build() => person;
    }
}
