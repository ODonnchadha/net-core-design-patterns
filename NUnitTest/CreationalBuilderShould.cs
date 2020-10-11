using Creational.Builder.Builders;
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
        public void Build()
        {
            htmlBuilder.AddChild("li", "Hello");
            htmlBuilder.AddChild("li", "World");

            Assert.AreEqual(
                "<ul><li>Hello</li><li>World</li></ul>", 
                htmlBuilder.ToString().RemoveWhitespace());
        }

        [Test()]
        public void BuildFluent()
        {
            fluentHtmlBuilder.AddChild("li", "Hello").AddChild("li", "World");

            Assert.AreEqual(
                "<ul><li>Hello</li><li>World</li></ul>",
                fluentHtmlBuilder.ToString().RemoveWhitespace());
        }
    }
}
