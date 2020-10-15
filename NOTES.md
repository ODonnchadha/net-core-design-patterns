## Culled from a Udemy class entitled ".NET Design Patterns" by Dmitri Nesteruk.

- SOLID Design Principles
	- Creational
	- Structural
	- Behavioral

- Additional:
	- Heavy use of ReSharper.
	- Liberal use of public fields (Not a recommendation.)
	- Ad-hoc use of dependency injection (Autofac.)
	- Some 3rd part NuGet packages.
	- Other:
		1. Sequence Processing (LINQ/Rx)
		2. Concurrency (TPL)
		3. DI.

- SOLID:
	- Introduced by Robert C. Martin in a long-winded yet not-too-deep novel.
	1. Single Responsibility Principle:
		- Any paticular class should have a single reason to change.
		- e.g.: A journal that collected entries, displayed entries, and also loaded from/saved to file system.
		- e.g.: Resolve was to create a seperate Persistence class.
	
	2. Open/Closed Principle:
		- e.g.: Ordering system: Products. Categories. Traits. With filtering.
		```csharp
			public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
			{
				foreach(var p in products) if (p.Size == size) yield return p;
			}
		```
		- So, copy/paste in order to filter by color. And by both size and color. So, again, we open up the ProductFilter class.
		- Clases should be open for extension, but they should be closed for modification.
		- So the answer is inheritance. So we'll implement a specification pattern.
		- Extending a filter. We will never have to return to ProductFilter.
	
	3. Liskov Substitution Principle:
		- You should be able to substitue a base type for a subtype.
		- e.g.: Classic defination: Rectangles and squares. Static area calculation is width * height.
		- We now inherit a square from a rectangle yet enforce the idea that a square *must* be a square with the property 'setters.'
		- And then we fail. Rectange sq = new Square(); sq.Height = 4.
		- So we need to indicate the overrides with virtual properties on the base class.
		- e.g.: public override int Height;
	
	4. Interface Segregation Principle:
		- Stop implementing interfaces that are too large.
		- e.g.: You have an interface for a multi-functional printer: Print. Scan. Fax.

	5. Dependency Inversion Principle:
		- Allow high-level module to access some of the internals of the low-level module. System.ValueTuple.
		- e.g.: public properties and filtering. We end up accessing a low-lovel portion of the low-level module.
		- In practice, the low-level cannot change its mind. e.g.: Tuple versus Dictionary.
		- Instead, define an interface as the access control for data access.
		```csharp
			public interface IRelationship
			{
				IEnumerable<Person> FindAllChildrenOf(string name);
			}
		```
	
	- Summary:
		- Single Responsibility Principle:
			1. A class should have only one reason to change.
			2. Seperation of concerns - different classes handling ddifferent, independ tasks/problems.
		- Open-Closed Principle:
			1. Classes should be open for extension but closed for modification. e.g.: Specification pattern.
		- Liskov Substition Pattern:
			1. You should be able to subscribe a base type for a subtype.
		- Interface Segretion Principle:
			1. Don't put too much into an interface; split it up into seperate interfaces.
			2. YAGNI: You ain't going to need it.
		- Dependency Inversion Principle:
			1. High-level modules should not depend upon low-level modules. Use abstractions.


## Creational

- Builder:
	- When construction gets a little too complicated.
	- Some objects are simple and can be created in a single constructor call.
	- Other objects require a lot of ceremony to create.
	- Having an object with ten constructor arguments is not productive. Instead, opt for piecewise construction.
	- Builder provides an API for constructing an object step-by-step.
	- * Builder: When piecewise object construction is complicated, provide an API for doing it succinctly. *
- Life without Builder:
	- e.g.: Output a chunk of HTML. 
	```csharp
		StringBuilder.Append("<p>");
		StringBuilder.Append("Paragraph");
		StringBuilder.Append("</p>");
	```
- The Pattern:
	- e.g.: So we define a class called HtmlElement. And then we create an HtmlBuilder as an API.
	- Fluent builder: Chaining methods together.
	- Fluent builder(s) with inheritance. You are not allowed the containing type as the return type.
	- e.g.: A derived class needs to propogate its derived type via its base type. This is difficult and requires generic classes.
	- Faceted Builder: Building an address and employment information in a fluent manner. We want several builder facades.
	- e.g.: A person builder will maintain a reference to the sub-builders. The person builder conyains a *reference* to the person being built.
- Summary:
	- A builder is a seperate component for building an object.
	- It can either give builder a constructor or return it via a static function.
	- To make a builder fluent, return this.
	- Differet facets of an object can be built with different builders working in tandem via a base class.

- Factory:
	- Factory Method and Abstract Factory.
	- Object creation logic becomes too convoluted.
	- Constructor is not descriptive:
		1. The name is mandated by name of containing type.
		2. Cannot overload with same sets or arguments with different names.
		3. Can turn into 'optional parameter hell.'
	- Object creation (non-piecewise, unlike builder) can be outsourced to:
		1. A seperate function (Factory Method.)
		2. That may exist in a seperate class (Factory.)
		3. Can create hiearchy of factories with Abstract Factory.
	- Factory: A component responsible soley for the wholesale (not piecewise) creation of objects.
	- e.g.: Point example. Introducing different types to pass to a constructor. And a switch statement.
	- Abstract factory provides abstract objects. e.g. With method, abstract factory returned concrete point(s).
	- We will return abstract classes or interfaces. We will return two different objects with their own factories.
	- Tea and coffee. We will not return type T but an IHotDrink interface. But the associated enum breaks the open/closed principle.
	- So we scape the pbjects in a different manner and then use an int to obtain the provided factory. With OutOfIndex we return a NoOp IBeverage.
	- Summary:
		- A factory method is a static method that creates abjects.
		- A factory can take care of object creation.
		- A factory can be external or reside insode the object as an inner class.
		- Heirarchies of factories can be used to create related objects.

- Prototype:
	- When it's easier to copy an existing object to fully initialize a new one.
	- Motivation: Complicated objects are not designed from scratch.
		1. Reiterate existing designs.
	- An existing, partially or fully constructed, design is a prototype.
	- We make a copy, clone, of the prototype and customize it.
		1. Required 'deep copy' support.
	- Make the cloning convenient.
	- A partially or fully initiazed object that you copy (clone) and make use of.
	- Be careful that you are not 'cloning' by simply copying the reference. e.g.: Both Names[0] are now "Y."
	```csharp
		var x = new Person(new[] { "X", "XYZ" }, new Address("Duluth Avenue", 40));
        var y = x;
        y.Names[0] = "Y";
	```
	- *NOTE:* ICloneable is bad. The ieda is that the .NET framework offers up this interface.
	- The problem? Is it deep cloning or simply shallow cloning? Be careful about reference cloning. ICloneable returns an object... so, before generics. So cast to type.
	- ICloneable is a shallow copy. We copied a memory pointer with Address until we add ICloneable to the nested Address as well. Also, the Names[] offers only shallow copy.

	- One approach: Use a copy constructor. A C++ term.
	- Another: Create a DeepCopy() method via an interface<T>.
	- A serializer will obtain the entire tree. This is a better example of real-word deep copy. We stay away from interfaces in order *not* to mrak all of our (nested) classes.
	- Instead, build an extension method. And we'll need [Serializable()] decorators for binary serialization.
	- But not for XmlSerialization. However, we will need parameterless constructors for XML serialization.
	- Summary:
		- To implement a prototype, partially construct an onject and store it somewhere.
		- Clone the prototype:
			1. Implement your own functionality; or
			2. Serialize and deserialize. Guarenteed to traverse the entire object graph.

- Singleton:
	- The design pattern everyone loves to hate... but is it really that bad?
	- Motivation: It does make sense to have only one instance in the system. e.g.: a database loaded completely into memory. Also, object factory. A factory should not have any state.
	- e.g.: a lazy-loaded, thread-safe component. The argument is that we do not need multiple instances of the resourse. We want to provent anyone from making more than one instance.
	- 1. Make the constructor private. Serve up an instance. Make the thing lazy-loading using Lazy<T>. Note: Use a Lambda to new up the resource.
	```csharp
		private static Lazy<T> instance = new Lazy<T>(() => new T());
		public static T Instance => instance.Value;
	```
	- Beware unit testing of a wrapper class with a hard-coded reference to the static database.
	```csharp
    	foreach (var name in names)
        {
            totalPopulation += SingletonDatabase.Instance.GetPolulation(name);
        }
	```
	- So singleton with mocking and unit testing.
	- A static class with static members is terrible because it has not constructors. There is no dependency injection.
	- The Monostate pattern. e.g.: There can only be one CEO at the company at a given time. So static state exposed in a non-static manner.
	- We end up referencing the same data regardless of how many "different" objects that we create.
	- Summary:
		1. Making a 'safe' singleton is easy: construct a static Lazy<T> and return its value.
		2. Singletons are difficult to test.
		3. Instead of directly using a singleton, consider depending on an abstraction.
		4. Consider defining singleton lifetime in a DI container.


## Structural

- Adapter:
	- Getting the interface you want from the interface you have. e.g.: An adapter with the associated different power requirements.
	- A construct which adapts an existing interface X to conform to the required interface Y.
	- e.g.: A simple drawing application. Drawing pixels. With a DrawPoint(Point) method. And now vertor is introduced. Vectors are a collection of lines.
	- We need to adapt a given line into a set of points. An adapter can generate a lot of unnecessary information.
	- Adapter caching. Preserve information stored for future use. Use GetHashCode(). Avoid regeneration.
	- Summary:
		1. Implementing an adapter is easy.
		2. Determine the API you have and the API you need.
		3. Create a component which aggregates (has a reference to, ...) the adaptee.
		4. Intermediate representations can pile up; use caching and other optimizations.

- Bridge:
	- Connecting components together through abstractions.
	- Motivation: The bridge prevents a 'Cartesian product' complexity explosion.
	- Example:
		1. Base class ThreadSAcheduler.
		2. Can be preemptive or cooperative.
		3. Can run on Windows or Unix.
		4. You'll end up with a 2x2 scenario: WindowsPTS, UnixPTS, WindowsCTS, UnixCTS.
	- Bridge pattern avoid this entity explosion.
	- Bridge is: A mechanism that decouples an interface (hierarchy) from an implementation (hiererchy.)
	- Summary:
		1. Decouple abstraction from implementation.
		2. Both can exist as hierarchies.
		3. A stronger form of encapsulation. Less state explosion.
