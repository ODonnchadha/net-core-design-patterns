using System.Collections.Generic;
using System.Text;

namespace Creational.Builder.Models
{
    public class HtmlElement
    {
        private const int INDENT_SIZE = 2;
        public string Name { get; set; }
        public string Text { get; set; }
        public List<HtmlElement> Elements = new List<HtmlElement>();

        public HtmlElement() { }
        public HtmlElement(string name, string text)
        {
            this.Name = name; this.Text = text;
        }

        private string ToStringImplementation(int indent)
        {
            var i = new string(' ', INDENT_SIZE * indent);
            var builder = new StringBuilder();

            builder.AppendLine($"{i}<{Name}>");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                builder.Append(new string(' ', INDENT_SIZE * (indent + 1)));
                builder.AppendLine(Text);
            }
            foreach(var child in Elements)
            {
                builder.Append(child.ToStringImplementation(indent + 1));
            }
            builder.AppendLine($"{i}</{Name}>");

            return builder.ToString();
        }
        public override string ToString() => ToStringImplementation(0);
    }
}
