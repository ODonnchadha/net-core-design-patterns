using NUnit.Framework;
using NUnitTest.Extensions;
using Pattern.Structural.Composite;
using Pattern.Structural.Composite.Models;

namespace NUnitTest.Structural
{
    public class StructuralCompositeShould
    {
        [Test()]
        public void BuildCompositeGraph()
        {
            var drawing = new GraphComposite { Name = "Unit Test Drawing" };
            drawing.Children.Add(new Circle { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new GraphComposite { };
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            drawing.Children.Add(group);

            Assert.AreEqual(
                "UnitTestDrawing*RedCircle*YellowCircle*Group**BlueCircle**BlueSquare", 
                drawing.ToString().RemoveWhitespace());
        }

        [Test()]
        public void BuildNeuronGraph()
        {
            var n1 = new Neuron { Value = 1 };
            var n2 = new Neuron { Value = 2 };

            n1.ConnectTo(n2);

            var layer = new NeuronLayer { new Neuron { Value = 3 } };
            n1.ConnectTo(layer);

            Assert.AreEqual(0, n1.Incoming.Count);
            Assert.AreEqual(2, n1.Outgoing.Count);

            n2.ConnectTo(n1);

            Assert.AreEqual(1, n1.Incoming.Count);
            Assert.AreEqual(2, n1.Outgoing.Count);
        }
    }
}
