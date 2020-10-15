namespace Pattern.Creational.Prototype.Interfaces
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }
}
