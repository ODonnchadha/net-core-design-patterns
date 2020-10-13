using Creational.Prototype.Interfaces;
using System;

namespace Creational.Prototype.Models
{
    [Serializable()]
    public class Address : IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address() { }
        public Address(string streetName, int houseNumber)
        {
            this.StreetName = streetName; this.HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            this.StreetName = other.StreetName;
            this.HouseNumber = other.HouseNumber;
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }
    }
}
