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