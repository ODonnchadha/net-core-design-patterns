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
	
	Summary:
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