namespace Creational.Builder.FacetedBuilder.Builders
{
    public class PersonJobBuilder: FacetedBuilder.Builders.PersonBuilder
    {
        public PersonJobBuilder(FacetedBuilder.Models.Person p)
        {
            this.person = p;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }
}
