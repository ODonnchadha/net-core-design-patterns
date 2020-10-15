namespace Pattern.Creational.Builder.FacetedBuilder.Builders
{
    public class PersonBuilder
    {
        protected FacetedBuilder.Models.Person person = 
            new FacetedBuilder.Models.Person();

        public static implicit operator FacetedBuilder.Models.Person(
            PersonBuilder builder) => builder.person;

        public FacetedBuilder.Builders.PersonJobBuilder Works =>
            new FacetedBuilder.Builders.PersonJobBuilder(person);
        public FacetedBuilder.Builders.PersonAddressBuilder Living =>
            new FacetedBuilder.Builders.PersonAddressBuilder(person);
    }
}
