using Pattern.Creational.Builder.Builders;
using Pattern.Creational.Builder.Models;
using NUnit.Framework;
using NUnitTest.Extensions;

namespace Creational.NUnitTest
{
    public class CreationalBuilderShould
    {
        private const string ROOT_NAME = "ul";
        private HtmlBuilder htmlBuilder;
        private FluentHtmlBuilder fluentHtmlBuilder;

        [SetUp()]
        public void Setup()
        {
            htmlBuilder = new HtmlBuilder(ROOT_NAME);
            fluentHtmlBuilder = new FluentHtmlBuilder(ROOT_NAME);

            htmlBuilder.Clear();
            fluentHtmlBuilder.Clear();
        }

        [Test()]
        public void BuildHtml()
        {
            htmlBuilder.AddChild("li", "Hello");
            htmlBuilder.AddChild("li", "World");

            Assert.AreEqual(
                "<ul><li>Hello</li><li>World</li></ul>", 
                htmlBuilder.ToString().RemoveWhitespace());
        }

        [Test()]
        public void BuildFluentHtml()
        {
            fluentHtmlBuilder.AddChild("li", "Hello").AddChild("li", "World");

            Assert.AreEqual(
                "<ul><li>Hello</li><li>World</li></ul>",
                fluentHtmlBuilder.ToString().RemoveWhitespace());
        }

        [Test()]
        public void BuildFluentPerson()
        {
            string name = "ODonnchadha";
            string position = "Janitor";

            var person = Person.Create.IsCalled(name).AndWorksAs(position).Build();

            Assert.IsNotNull(person);
            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(position, person.Position);
        }

        [Test()]
        public void FacetedBuilder()
        {
            // Address
            string address = "200 Duluth Avenue";
            string postalCode = "55803";
            string city = "Duluth";

            // Employment
            string works = "Fly By Night, Inc.";
            string position = "Janitor";
            int income = 3000;

            Pattern.Creational.Builder.FacetedBuilder.Builders.PersonBuilder builder 
                = new Pattern.Creational.Builder.FacetedBuilder.Builders.PersonBuilder();

            Pattern.Creational.Builder.FacetedBuilder.Models.Person person =
                builder
                .Living.At(address).WithPostalCode(postalCode).In(city)
                .Works.At(works).AsA(position).Earning(income);

            Assert.IsNotNull(person);
            Assert.AreEqual(postalCode, person.PostalCode);
            Assert.AreEqual(income, person.AnnualIncome);
        }
    }
}
