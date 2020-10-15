using Pattern.Creational.Singleton.Databases;
using System.Collections.Generic;

namespace Pattern.Creational.Singleton
{
    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int totalPopulation = 0;

            foreach (var name in names)
            {
                totalPopulation += SingletonDatabase.Instance.GetPolulation(name);
            }

            return totalPopulation;
        }
    }
}
