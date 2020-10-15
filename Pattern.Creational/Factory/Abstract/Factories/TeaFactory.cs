using Pattern.Creational.Factory.Abstract.Interfaces;
using Pattern.Creational.Factory.Abstract.Models;

namespace Pattern.Creational.Factory.Abstract.Factories
{
    public class TeaFactory : IBeverageFactory
    {
        public IBeverage Prepare(int amount) => new Tea(amount);
    }
}
