using Creational.Factory.Abstract.Interfaces;

namespace Creational.Factory.OpenClosed.Models
{
    public class NoOp : IBeverage
    {
        private int amount;
        public NoOp(int amount) => this.amount = amount;
        public string Consume() => $"{amount} {this.GetType().Name}";
    }
}
