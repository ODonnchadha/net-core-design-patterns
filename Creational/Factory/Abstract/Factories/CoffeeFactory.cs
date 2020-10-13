using Creational.Factory.Abstract.Interfaces;
using Creational.Factory.Abstract.Models;

namespace Creational.Factory.Abstract.Factories
{
    public class CoffeeFactory : IBeverageFactory
    {
        public IBeverage Prepare(int amount) => new Coffee(amount);
    }
}
