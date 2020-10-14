namespace Creational.Singleton
{
    public class SingletonMonostate
    {
        private static int age;
        private static string name;

        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
    }
}
