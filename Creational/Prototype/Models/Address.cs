using Creational.Prototype.Interfaces;

namespace Creational.Prototype.Models
{
    public class Address : IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

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
