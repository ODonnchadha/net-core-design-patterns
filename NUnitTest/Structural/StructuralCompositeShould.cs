using NUnit.Framework;
using NUnitTest.Extensions;
using Pattern.Structural.Composite.Models;

namespace NUnitTest.Structural
{
    public class StructuralCompositeShould
    {
        [SetUp()]
        public void Setup()
        {
        }

        [Test()]
        public void BuildCompositeGraph()
        {
            var drawing = new Graph { Name = "Unit Test Drawing" };

            drawing.Children.Add(new Circle { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new Graph { };
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            drawing.Children.Add(group);

            Assert.AreEqual(
                "UnitTestDrawing*RedCircle*YellowCircle*Group**BlueCircle**BlueSquare", 
                drawing.ToString().RemoveWhitespace());
        }
    }
}
