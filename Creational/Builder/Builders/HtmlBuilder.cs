using Creational.Builder.Models;

namespace Creational.Builder.Builders
{
    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();
        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public void AddChild(string childName, string childText)
        {
            var element = new HtmlElement(childName, childText);
            root.Elements.Add(element);
        }

        public void Clear()
        {
            root = new HtmlElement{ Name = rootName };
        }

        public override string ToString() => root.ToString();
    }
}
