using Pattern.Creational.Factory.Abstract.Interfaces;

namespace Pattern.Creational.Factory.OpenClosed.Models
{
    public class NoOp : IBeverage
    {
        private int amount;
        public NoOp(int amount) => this.amount = amount;
        public string Consume() => $"{amount} {this.GetType().Name}";
    }
}
