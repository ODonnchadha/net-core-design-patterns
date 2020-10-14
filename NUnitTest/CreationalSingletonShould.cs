using Creational.Singleton;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTest
{
    public class CreationalSingletonShould
    {
        private const string NEW_YORK = "New York";
        private const int NEW_YORK_POPULATION = 17800000;

        private SingletonDatabase instance;

        [SetUp()]
        public void Setup()
        {
            instance = SingletonDatabase.Instance;
        }
        
        /// <summary>
        /// Ensure referencial equality; that both instances reference the same object.
        /// </summary>
        [Test()]
        public void SingleInstance()
        {
            SingletonDatabase instance2 = SingletonDatabase.Instance;
            SingletonDatabase instance3 = SingletonDatabase.Instance;

            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
            Assert.That(instance2, Is.SameAs(instance));
            Assert.That(instance3, Is.SameAs(instance));
        }

        [Test()]
        public void GetPolulation()
        {
            Assert.AreEqual(NEW_YORK_POPULATION, instance.GetPolulation(NEW_YORK));
        }

        [Test()]
        public void GetTotalPopulation()
        {
            SingletonRecordFinder finder = new SingletonRecordFinder { };

            int totalPopulation = finder.GetTotalPopulation(new List<string>() { "Tokyo", NEW_YORK, "Mexico City" });

            Assert.AreEqual(68400000, totalPopulation);
        }
    }
}
