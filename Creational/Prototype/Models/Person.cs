using Creational.Prototype.Interfaces;
using System;

namespace Creational.Prototype.Models
{
    [Serializable()]
    public class Person : IPrototype<Person>
    {
        public string[] Names;
        public Address Address;

        public Person() { }
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
