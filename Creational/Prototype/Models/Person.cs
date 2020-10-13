using Creational.Prototype.Interfaces;

namespace Creational.Prototype.Models
{
    public class Person : IPrototype<Person>
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            this.Names = names; this.Address = address;
        }

        public Person(Person other)
        {
            this.Names = other.Names;
            this.Address = new Address(other.Address);
        }

        public Person DeepCopy()
        {
            return new Person(Names, Address.DeepCopy());
        }
    }
}
