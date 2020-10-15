using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Creational.Builder.FacetedBuilder.Builders
{
    public class PersonAddressBuilder : FacetedBuilder.Builders.PersonBuilder
    {
        public PersonAddressBuilder(FacetedBuilder.Models.Person p)
        {
            this.person = p;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostalCode(string postalCode)
        {
            person.PostalCode = postalCode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }
}
