# C# Coding Conventions

The following are conventions that we want to try to stick to as a development team. Please try to follow them whenever possible. If you have any questions or concerns, please ask Chris Centrella.

## Naming Conventions
* For field names, start with a lowercase letter, and use camelCasing.
```c#
string modelNumber;
```

* For properties, use CamelCasing, and begin with a capital letter.
```c#
string ModelNumber {get; set;}
```
* For methods, use CamelCasing, and begin with a capital letter.
```c#
bool StartEngine() {

}
```
* If a namespace is going to be used more than once in a code file, import the namespace&mdash;unless it is already imported. To do this, add a `using` statement, followed by the namespace, and place this at the beginning of the document.
```c#
using System.Diagnostics;
```

## Layout Conventions
* Use the default code editor settings. Please format each document by pressing `Ctrl/Cmd + K, Ctrl/Cmd + D` in sequence, before pushing to Git.
* Write only one statement per line.
* Write only one declaration per line, unless you are declaring multiple variables of the same data type and not initializing them.
* Add at least one blank line between method and property definitions.
* Use parentheses to make clauses apparent if necessary, and also use braces in the expression body at all times.

```c#
if ((modelNumber == "V293234923023") && (modelYear > 2005)) {

}
```

## Commenting Conventions
* Place the comment on a separate line just before the statement(s) to which you are referring.
* End the comment with a period if and only if it is a complete sentence.
* Insert a space between the comment delimiter (//) and the comment.
* A comment should only occupy about 75% of the horizontal viewport, as to avoid a horizontal scrollbar.

```c#
// The model number of the vehicle
string ModelNumber;

// Maximum amount of characters on a single line:
// This function will start the engine, and will return true if the operation succeeded.
bool StartEngine();

```

## Language Guidelines (Advanced)
### String Data Type
* Use the new string <a target="_blank" href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated">interpolation</a> feature to concatenate short strings:

```c#
Console.WriteLine($"The starter is not working correctly.\n{ex.Message}");
```

* To append strings in loops, use a <a target="_blank" href="https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder">StringBuilder</a>.
```c#
var series = new StringBuilder();
var phrase = "I am the Way, the Truth, and the Life";
for (int i = 0; i < phrase.Length; i++) {
    series.Append(phrase[i])
}
```
### Implicit Typing
* Use implicit typing only when the left-hand side can easily be inferred:


```c#
var string1 = "Welcome! Please enter your name and press ENTER.";
```
* In `foreach` loops, do not use implicit typing, though you can in `for` loops.

```c#
var series = new StringBuilder();
var phrase = "I am the Way, the Truth, and the Life";
for (int i = 0; i < phrase.Length; i++) {
    series.Append(phrase[i])
}

foreach (char ch in phrase) {
   series.Append(ch);
}
```

### Unsigned Data Types
* Use the `int` data type for most integer numbers. Only use another type, like unsigned integers, if there is a good reason to.

### Arrays
* For initializing arrays, please use the following format, i.e., explicitly typed and without a `new` statement:
```c#
string[] words = {"I", "am", "the", "Way"};
```
### Delegates
* Use the concise syntax for delegates:
```c#
public delegate void PrintDelegate (string message);

// Delegate with matching signature
public static void PrintMethod(string message)
{
    Console.WriteLine($"Printing: {message}");
}

// We can create a delegate implicitly by setting the method equal to the delegate,
// without using a new statement or mentioning the name of the delegate again.
PrintDelegate del = PrintMethod;
```

* Use lambda expressions whenever possible.
```c#
int[] numbers = { 2, 3, 4, 5 };

var squaredNumbers = numbers.Select(x => x * x);
```
### Exception Handling
* Use try, catch for exception handling.
* DO NOT use the the sole keyword `catch` or `catch (Exception ex)`; only catch specific exceptions which you know how to handle.
```c#
try {
    StartEngine();
}
catch (StarterException ex)
{
    Console.WriteLine($"The starter is not working correctly.\n{ex.Message}");
}
```
* If you need to dispose objects, use a `using` statement instead of calling `Dispose()` in the `finally` clause of a `try...catch` statement.

```c#
using (StreamReader reader = new StreamReader("file.txt"));
{
    reader.ReadToEnd();
}
```

### Operators
* Use the shortcut operators `|` and `&` when performing comparisons, to increase performance and avoid errors.
* When initializing new classes, use explicit typing, especially if the class name is complicated.
* Use object initializers when creating objects:

```c#
// Using object initializers
var vehicle = new Vehicle() { MPG=40, Color="Blue", Manufacturer="Ford", ModelName="Fiesta" };

// Traditional instantiation
var vehicle = new Vehicle();
vehicle.MPG = 40;
vehicle.Color = "Blue";
vehicle.Manufacturer = "Ford";
vehicle.ModelName = "Fiesta";
```
### Event Handling
* Use lambda expressions when defining event handlers, unless you need to remove it later.
```c#
public NumericUpDown()
{
    this.ValueChanged += new EventHandler(NumericUpDown1_ValueChanged);
}
```

### Static Members
* When calling static members, include the class name. Be sure to use the name of the base class and not the derived class, unless the member is specifically defined in the derived class.
```c#
Vehicle.Go();
```

### LINQ Queries
* Use meaningful names for query variables.
* Make sure property names are not ambiguous.
* Use aliases so that the property names are capitalized like they should be, with camel casing:
```c#
var orders =
    from vehicle in vehicles
    join customer in customers on vehicle.OrderID equals customer.OrderID
    select new { Customer = customer, Vehicle = vehicle };
```
* Use implicit typing (`var` is not needed here, either.)
* Make sure that queries are formatted so that every new line is indented, and placed just below from, like the example above.
* Use `where` clauses before any other clauses (except `from`, of course) so the filtering results are accurate.
* For inner collections, a join is not required. Instead, use two `from` clauses.

```c#
var vehiclesQuery =
    from manufacturer in manufacturers
    from vehicle in vehicles
    where vehicle.Manufacturer == "Ford"
    select new { MPG = vehicle.MPG, Manufacturer = "Ford", vehicle };
```