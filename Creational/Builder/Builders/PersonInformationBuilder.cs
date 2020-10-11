using Creational.Builder.Abstractions;

namespace Creational.Builder.Builders
{
    public class PersonInformationBuilder<SELF> : PersonBuilder where SELF : PersonInformationBuilder<SELF>
    {
        public SELF IsCalled(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }
}
