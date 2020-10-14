using Creational.Singleton.Interfaces;
using System.Collections.Generic;

namespace Creational.Singleton
{
    public class SingletonRecordFinderConfigurable
    {
        private readonly IDatabase database;

        public SingletonRecordFinderConfigurable(IDatabase database) => this.database = database;

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int totalPopulation = 0;

            foreach (var name in names)
            {
                totalPopulation += database.GetPolulation(name);
            }

            return totalPopulation;
        }
    }

}
