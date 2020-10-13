using Creational.Factory.Abstract.Interfaces;
using Creational.Factory.Abstract.Models;

namespace Creational.Factory.Abstract.Factories
{
    public class TeaFactory : IBeverageFactory
    {
        public IBeverage Prepare(int amount) => new Tea(amount);
    }
}
