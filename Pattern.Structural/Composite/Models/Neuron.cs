using System.Collections;
using System.Collections.Generic;

namespace Pattern.Structural.Composite.Models
{
    public class Neuron : IEnumerable<Neuron>
    {
        public float Value { get; set; }
        public List<Neuron> Incoming = new List<Neuron> { };
        public List<Neuron> Outgoing = new List<Neuron> { };

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class ExtensionMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other))
            {
                return;
            }

            foreach(var from in self)
            {
                foreach(var to in other)
                {
                    from.Outgoing.Add(to);
                    to.Incoming.Add(from);
                }
            }
        }
    }
}
