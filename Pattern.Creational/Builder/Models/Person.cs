using Pattern.Creational.Builder.Builders;

namespace Pattern.Creational.Builder.Models
{
    public class Person
    {
        public string Name;
        public string Position;
        public static Builder Create => new Builder();
        public class Builder: PersonJobBuilder<Builder> { }
    }
}
