using Pattern.Creational.Prototype.Extensions;
using Pattern.Creational.Prototype.Models;
using NUnit.Framework;

namespace NUnitTest.Creational
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

        [Test()]
        public void BinarySerializationPrototype()
        {
            string xFirstName = "X";
            string yLastName = "Y";
            int xHouseNumber = 40;
            int yHouseNumber = 400;

            var x = new Person(new[] { xFirstName, "XYZ" }, new Address("Duluth Avenue", xHouseNumber));

            var y = x.DeepCopyBinary();
            y.Names[0] = yLastName;
            y.Address.HouseNumber = yHouseNumber;

            Assert.IsNotNull(x.Names[0]);
            Assert.IsNotNull(y.Names[0]);
            Assert.IsNotNull(x.Address);
            Assert.IsNotNull(y.Address);

            Assert.AreEqual(xFirstName, x.Names[0]);
            Assert.AreEqual(yLastName, y.Names[0]);
            Assert.AreEqual(xHouseNumber, x.Address.HouseNumber);
            Assert.AreEqual(yHouseNumber, y.Address.HouseNumber);
        }

        [Test()]
        public void XmlSerializationPrototype()
        {
            string xFirstName = "X";
            string yLastName = "Y";
            int xHouseNumber = 40;
            int yHouseNumber = 400;

            var x = new Person(new[] { xFirstName, "XYZ" }, new Address("Duluth Avenue", xHouseNumber));

            var y = x.DeepCopyXml();
            y.Names[0] = yLastName;
            y.Address.HouseNumber = yHouseNumber;

            Assert.IsNotNull(x.Names[0]);
            Assert.IsNotNull(y.Names[0]);
            Assert.IsNotNull(x.Address);
            Assert.IsNotNull(y.Address);

            Assert.AreEqual(xFirstName, x.Names[0]);
            Assert.AreEqual(yLastName, y.Names[0]);
            Assert.AreEqual(xHouseNumber, x.Address.HouseNumber);
            Assert.AreEqual(yHouseNumber, y.Address.HouseNumber);
        }
    }
}
