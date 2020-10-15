using Pattern.Creational.Factory.Abstract.Interfaces;
using Pattern.Creational.Factory.Abstract.Models;

namespace Pattern.Creational.Factory.Abstract.Factories
{
    public class CoffeeFactory : IBeverageFactory
    {
        public IBeverage Prepare(int amount) => new Coffee(amount);
    }
}
