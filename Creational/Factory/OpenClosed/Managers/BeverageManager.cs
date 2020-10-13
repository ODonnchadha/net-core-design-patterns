using Creational.Factory.Abstract.Interfaces;
using Creational.Factory.OpenClosed.Models;
using System;
using System.Collections.Generic;

namespace Creational.Factory.OpenClosed.Managers
{
    public class BeverageManager
    {
        private List<Tuple<string, IBeverageFactory>> factories = new List<Tuple<string, IBeverageFactory>>();
        public BeverageManager()
        {
            foreach(var t in typeof(BeverageManager).Assembly.GetTypes())
            {
                if (typeof(IBeverageFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    var name = t.Name.Replace("Factory", string.Empty);
                    var value = (IBeverageFactory)Activator.CreateInstance(t);

                    factories.Add(new Tuple<string, IBeverageFactory>(name, value));
                }
            }
        }

        public IBeverage Get(int factoryIndex, int amount)
        {
            if (factoryIndex < 0 || factoryIndex > factories.Count)
            {
                return new NoOp(amount);
            }

            return factories[factoryIndex].Item2.Prepare(amount);
        }
    }
}
