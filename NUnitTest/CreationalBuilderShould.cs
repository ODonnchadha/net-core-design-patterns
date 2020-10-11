using Creational.Builder.Builders;
using Creational.Builder.Models;
using NUnit.Framework;
using NUnitTest.Extensions;

namespace NUnitTest
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

            var person = Person.New.IsCalled(name).AndWorksAs(position).Build();

            Assert.IsNotNull(person);
            Assert.AreEqual(name, person.Name);
            Assert.AreEqual(position, person.Position);
        }
    }
}
