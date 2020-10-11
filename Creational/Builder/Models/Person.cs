using Creational.Builder.Builders;

namespace Creational.Builder.Models
{
    public class Person
    {
        public string Name;
        public string Position;
        public static Builder New => new Builder();
        public class Builder: PersonJobBuilder<Builder> { }
    }
}
