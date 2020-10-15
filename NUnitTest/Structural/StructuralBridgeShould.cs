using Autofac;
using NUnit.Framework;
using Pattern.Structural.Bridge.Interfaces;
using Pattern.Structural.Bridge.Managers;
using Pattern.Structural.Bridge.Models;

namespace NUnitTest.Structural
{
    public class StructuralBridgeShould
    {
        IRenderer renderer;

        [SetUp()]
        public void Setup()
        {
        }

        [Test()]
        public void CircleRenderer()
        {
            renderer = new RasterRenderer { };
            var circle1 = new Circle(renderer, 5);

            Assert.IsNotNull(circle1);
            Assert.AreEqual("RasterRenderer 5", circle1.Draw());

            circle1.Resize(4);
            Assert.AreEqual((float)20.0, circle1.Radius);
            Assert.AreEqual("RasterRenderer 20", circle1.Draw());

            renderer = new VectorRenderer { };
            var circle2 = new Circle(renderer, 5);

            Assert.IsNotNull(circle2);
            Assert.AreEqual("VectorRenderer 5", circle2.Draw());

            circle2.Resize(4);
            Assert.AreEqual((float)20.0, circle2.Radius);
            Assert.AreEqual("VectorRenderer 20", circle2.Draw());
        }

        [Test()]
        public void CircleRendererContainer()
        {
            var builder = new ContainerBuilder { };
            builder.RegisterType<VectorRenderer>().As<IRenderer>().SingleInstance();

            builder.Register((context, parameter) =>
            new Circle(
                context.Resolve<IRenderer>(),
                parameter.Positional<float>(0)));

            using (var container = builder.Build())
            {
                var circle = container.Resolve<Circle>(new PositionalParameter(0, (float)5));

                Assert.IsNotNull(circle);
                Assert.AreEqual("VectorRenderer 5", circle.Draw());

                circle.Resize(4);
                Assert.AreEqual((float)20.0, circle.Radius);
                Assert.AreEqual("VectorRenderer 20", circle.Draw());
            }
        }
    }
}
