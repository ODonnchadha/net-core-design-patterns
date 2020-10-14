using Autofac;
using Creational.Singleton;
using Creational.Singleton.Databases;
using Creational.Singleton.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

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

        [Test()]
        public void GetTotalPopulationMock()
        {
            SingletonRecordFinderConfigurable finder = new SingletonRecordFinderConfigurable(new MockDatabase { });

            int totalPopulation = finder.GetTotalPopulation(new List<string>() { "Alpha", "Beta", "Gamma" });

            Assert.AreEqual(6, totalPopulation);
        }

        [Test()]
        public void GetTotalPopulationMockDependencyInjection()
        {
            var builder = new ContainerBuilder { };

            builder.RegisterType<MockDatabase>().As<IDatabase>().SingleInstance();
            builder.RegisterType<SingletonRecordFinderConfigurable>();

            using(var container = builder.Build())
            {
                var finder = container.Resolve<SingletonRecordFinderConfigurable>();
                int totalPopulation = finder.GetTotalPopulation(new List<string>() { "Alpha", "Beta", "Gamma" });

                Assert.AreEqual(6, totalPopulation);

                var instance1 = container.Resolve<IDatabase>();
                var instance2 = container.Resolve<IDatabase>();

                Assert.That(instance1, Is.SameAs(instance2));
            }
        }

        [Test()]
        public void SingletonMonostate()
        {
            var s1 = new SingletonMonostate { };
            s1.Age = 40;
            s1.Name = "Daniel";

            var s2 = new SingletonMonostate { };
            s2.Age = 20;
            s2.Name = "Patrick";

            Assert.AreEqual(s1.Age, 20);
            Assert.AreEqual(s1.Name, "Patrick");
        }
    }
}
