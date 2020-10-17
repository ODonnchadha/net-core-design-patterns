using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.Structural.Composite.Models
{
    public class Graph
    {
        private Lazy<List<Graph>> children = new Lazy<List<Graph>> { };
        public virtual string Name { get; set; } = "Group";
        public string Color;
        public List<Graph> Children => children.Value;

        private void Print(StringBuilder builder, int depth)
        {
            builder
                .Append(new string('*', depth))
                .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
                .AppendLine(Name);

            foreach(var child in Children)
            {
                child.Print(builder, depth + 1);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Print(builder, 0);

            return builder.ToString();
        }
    }
}
