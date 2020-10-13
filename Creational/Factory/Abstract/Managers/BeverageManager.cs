using Creational.Factory.Abstract.Interfaces;
using System;
using System.Collections.Generic;

namespace Creational.Factory.Abstract.Managers
{
    public class BeverageManager
    {
        public enum Drinks { Coffee, Tea }

        private Dictionary<Drinks, IBeverageFactory> factories = 
            new Dictionary<Drinks, IBeverageFactory>();

        public BeverageManager()
        {
            foreach(Drinks drink in Enum.GetValues(typeof(Drinks)))
            {
                var factory = (IBeverageFactory)Activator
                    .CreateInstance(Type.GetType("Creational.Factory.Abstract.Factories."
                    + Enum.GetName(typeof(Drinks), drink) + "Factory"));

                factories.Add(drink, factory);
            }
        }
        public IBeverage Get(Drinks drink, int amount) => factories[drink].Prepare(amount);
    }
}
