namespace Pattern.Creational.Factory.Abstract.Interfaces
{
    public interface IBeverageFactory
    {
        IBeverage Prepare(int amount);
    }
}
