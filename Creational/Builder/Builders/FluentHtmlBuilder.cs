using Creational.Builder.Models;

namespace Creational.Builder.Builders
{
    public class FluentHtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();
        public FluentHtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        /// <summary>
        /// Chain several calls by returning a reference to the object that 
        /// you are working with.
        /// </summary>
        /// <param name="childName"></param>
        /// <param name="childText"></param>
        /// <returns></returns>
        public FluentHtmlBuilder AddChild(string childName, string childText)
        {
            var element = new HtmlElement(childName, childText);
            root.Elements.Add(element);
            return this;
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }

        public override string ToString() => root.ToString();
    }
}
