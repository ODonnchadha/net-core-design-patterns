using Pattern.Creational.Factory.Abstract.Interfaces;

namespace Pattern.Creational.Factory.Abstract.Models
{
    internal class Tea : IBeverage
    {
        private int amount;
        public Tea(int amount) => this.amount = amount;
        public string Consume() => $"{amount} {this.GetType().Name}";
    }
}