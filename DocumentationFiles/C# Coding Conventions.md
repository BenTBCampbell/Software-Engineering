# C# Coding Conventions

The following are conventions that we want to try to stick to as a development team. Please try to follow them whenever possible. If you have any questions or concerns, please ask Christopher Centrella.

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
* If a namespace is going to be used more than once in a code file, import the namespace--unless it is already imported. To do this, add a `using` statement, followed by the namespace, and place this at the beginning of the document.
```c#
using System.Diagnostics;
```

## Layout Conventions
* Use the default code editor settings. Please format each document by pressing `Ctrl/Cmd + K, Ctrl/Cmd + D` in sequence, before pushing to Git.
* Write only one statement per line.
* Write only one declaration per line, unless you are declaring multiple variables of the same data type and not initializing them.
* Add at least one blank line between method and property definitions.
* Use parentheses to make clauses apparent when necessary, and also use braces in the expression body at all times.

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
string displayName = $"{nameList[n].LastName}, {nameList[n].FirstName}";
```

* To append strings in loops, use a <a target="_blank" href="https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder">StringBuilder</a>.
```c#
var phrase = "lalalalalalalalalalalalalalalalalalalalalalalalalalalalalala";
var manyPhrases = new StringBuilder();
for (var i = 0; i < 10000; i++)
{
    manyPhrases.Append(phrase);
}
```
### Implicit Typing
* Use implicit typing only when the left-hand side can easily be inferred:


```c#
var string1 = "Hello World";
```
* In `foreach` loops, do not use implicit typing, though you can in `for` loops.

```c#
for (var i = 0; i < 10000; i++)
{
    manyPhrases.Append(phrase);
}

foreach (char ch in laugh)
{
    if (ch == 'h')
        Console.Write("H");
    else
        Console.Write(ch);
}
Console.WriteLine();
```

### Unsigned Data Types
* Use the `int` data type for most integer numbers. Only use another type, like unsigned integers, if there is a good reason to.

### Arrays
* For initializing arrays, please use the following format, i.e., explicitly typed and without a `new` statement:
```c#
string[] vowels1 = { "a", "e", "i", "o", "u" };
```
### Delegates
* Use the concise syntax for delegates:
```c#
// We have already created a delegate type Del and its matching method DelMethod, which are not shown here.

// Preferred: Create an instance of Del by using condensed syntax.
Del exampleDel2 = DelMethod;

// The following declaration uses the full syntax.
Del exampleDel1 = new Del(DelMethod);
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
* If you need to dispose objects, use a using statement instead of calling Dispose in the `finally `clause of a try catch statement.

```c#
using (Font font2 = new Font("Arial", 10.0f))
{
    byte charset = font2.GdiCharSet;
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
public Form1()
{
    this.Click += new EventHandler(Form1_Click);
}
```

### Static Members
* When calling static members, include the name of the <strong>base</strong> class.
```c#
Vehicle.Go();
```

### LINQ Queries
* Use meaningful names for query variables.
* Make sure property names are not ambiguous.
* Use aliases so that the property names are capitalized like they should be, with camel casing:
```c#
var localDistributors =
    from customer in customers
    join distributor in distributors on customer.City equals distributor.City
    select new { Customer = customer, Distributor = distributor };
```
* Use implicit typing (`var` is not needed here, either.)
* Make sure that queries are formatted so that every new line is indented, and placed just below from, like the example above.
* Use `where` clauses before any other clauses (except `from`, of course) so the filtering results are accurate.
* For inner collections, a join is not required. Instead, use two `from` clauses.

```c#
var scoreQuery = from student in students
                 from score in student.Scores
                 where score > 90
                 select new { Last = student.LastName, score };
```