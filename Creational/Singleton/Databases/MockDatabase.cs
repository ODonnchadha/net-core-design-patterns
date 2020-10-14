using Creational.Singleton.Interfaces;
using System.Collections.Generic;

namespace Creational.Singleton.Databases
{
    public class MockDatabase : IDatabase
    {
        private static int count;
        public static int Count => count;
        public MockDatabase() => count++;
        public int GetPolulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["Alpha"] = 1,
                ["Beta"] = 2,
                ["Gamma"] = 3
            }[name];
        }
    }
}
