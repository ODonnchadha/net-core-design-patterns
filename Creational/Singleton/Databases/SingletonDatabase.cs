using Creational.Singleton.Interfaces;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Creational.Singleton.Databases
{
    public class SingletonDatabase : IDatabase
    {
        private static int count;
        private Dictionary<string, int> capitals;
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;
        public static int Count => count;

        private SingletonDatabase()
        {
            count++;

            //this.capitals = File.ReadAllLines(Path.Combine(
            //    new FileInfo(typeof(SingletonDatabase).Assembly.Location).DirectoryName,
            //    "capitals.txt")).Batch(2).ToDictionary(
            //    list => list.ElementAt(0).Trim(),
            //    list => int.Parse(list.ElementAt(1))
            //);

            this.capitals = File.ReadAllLines(
                @"C:\ODonnchadha\net-core-design-patterns\Creational\Singleton\Databases\capitals.txt").Batch(2).ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1))
            );
        }
        public int GetPolulation(string name) => capitals[name];
    }
}
