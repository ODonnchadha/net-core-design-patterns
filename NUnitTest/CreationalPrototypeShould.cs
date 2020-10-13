using Creational.Prototype.Models;
using NUnit.Framework;

namespace NUnitTest
{
    public class CreationalPrototypeShould
    {
        [SetUp()]
        public void Setup()
        {
        }

        [Test()]
        public void CopyConstructorPrototype()
        {
            int xHouseNumber = 40;
            int yHouseNumber = 400;

            var x = new Person(new[] { "X", "XYZ" }, new Address("Duluth Avenue", xHouseNumber));

            var y = new Person(x);
            y.Address.HouseNumber = yHouseNumber;

            Assert.IsNotNull(x.Address);
            Assert.IsNotNull(y.Address);
            Assert.AreEqual(xHouseNumber, x.Address.HouseNumber);
            Assert.AreEqual(yHouseNumber, y.Address.HouseNumber);
        }

        [Test()]
        public void DeepCopyPrototype()
        {
            int xHouseNumber = 40;
            int yHouseNumber = 400;

            var x = new Person(new[] { "X", "XYZ" }, new Address("Duluth Avenue", xHouseNumber));

            var y = x.DeepCopy();
            y.Address.HouseNumber = yHouseNumber;

            Assert.IsNotNull(x.Address);
            Assert.IsNotNull(y.Address);
            Assert.AreEqual(xHouseNumber, x.Address.HouseNumber);
            Assert.AreEqual(yHouseNumber, y.Address.HouseNumber);
        }
    }
}
