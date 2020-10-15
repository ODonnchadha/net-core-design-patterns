using Pattern.Creational.Factory.Abstract.Managers;
using Pattern.Creational.Factory.Inner;
using Pattern.Creational.Factory.Method;
using NUnit.Framework;

namespace Creational.NUnitTest
{
    public class CreationalFactoryShould
    {
        [SetUp()]
        public void Setup()
        {
        }

        [Test()]
        public void BuildCartesianPoint()
        {
            var x = 4.5; var y = 2.5;
            var p = PointFactory.CartesianPoint(x, y);

            Assert.IsNotNull(p);
            Assert.AreEqual(x, p.X);
            Assert.AreEqual(y, p.Y);
        }

        [Test()]
        public void BuildPolarPoint()
        {
            var p = PointFactory.PolarPoint(1, 1);

            Assert.IsNotNull(p);
            Assert.AreEqual(0.54030230586813977, p.X);
            Assert.AreEqual(0.8414709848078965, p.Y);
        }

        [Test()]
        public void InnerFactoryPolarPoint()
        {
            var p = Point.InnerFactory.PolarPoint(1, 1);

            Assert.IsNotNull(p);
            Assert.AreEqual(0.54030230586813977, p.X);
            Assert.AreEqual(0.8414709848078965, p.Y);
        }

        [Test()]
        public void InnerFactoryOrigin()
        {
            var p = Point.Origin;

            Assert.IsNotNull(p);
            Assert.AreEqual(0, p.X);
            Assert.AreEqual(0, p.Y);
        }

        [Test()]
        public void AbstractBeverageManagerFactory()
        {
            var amount = 40;
            var manager = new BeverageManager { };
            var beverage = manager.Get(BeverageManager.Drinks.Coffee, amount);

            Assert.IsNotNull(beverage);
            Assert.AreEqual($"{amount} {beverage.GetType().Name}", beverage.Consume());

            Assert.AreEqual($"{amount} Tea", 
                manager.Get(BeverageManager.Drinks.Tea, amount).Consume());
        }

        [Test()]
        public void AbstractBeverageManagerOpenClosedFactory()
        {
            var amount = 40;
            var manager = new Pattern.Creational.Factory.OpenClosed.Managers.BeverageManager { };
            var beverage = manager.Get(0, amount);

            Assert.IsNotNull(beverage);
            Assert.AreEqual($"{amount} {beverage.GetType().Name}", beverage.Consume());
            Assert.AreEqual($"{amount} Tea", manager.Get(1, amount).Consume());
            Assert.AreEqual($"{amount} NoOp", manager.Get(-1, amount).Consume());
            Assert.AreEqual($"{amount} NoOp", manager.Get(100, amount).Consume());
        }
    }
}
