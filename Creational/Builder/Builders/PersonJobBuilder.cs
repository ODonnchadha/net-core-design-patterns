namespace Creational.Builder.Builders
{
    public class PersonJobBuilder<SELF>: PersonInformationBuilder<PersonJobBuilder<SELF>> where SELF: PersonJobBuilder<SELF>
    {
        public SELF AndWorksAs(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
}
