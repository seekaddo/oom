####Week 1

* Pitfalls to avoid
```c#
    class class  {...}      // Illegal
    class @class {...}      // Legal


```


```c#

string message = "Hello world";
string upperMessage = message.ToUpper(); Console.WriteLine (upperMessage);
int x = 2015;
message = message + x.ToString(); Console.WriteLine (message);
// HELLO WORLD
// Hello world2015



//converting type cast
    int x = 12345;       // int is a 32-bit integer
    long y = x;          // Implicit conversion to 64-bit integer
    short z = (short)x;  // Explicit conversion to 16-bit integer


public struct Point { public int X; public int Y; }
public struct Point { public int X, Y; }


      Point p1 = new Point();
      p1.X = 7;
      Point p2 = p1;             // Assignment causes copy
      Console.WriteLine (p1.X);  // 7
      Console.WriteLine (p2.X);  // 7
      p1.X = 9;                  // Change p1.X
      Console.WriteLine (p1.X);  // 9
      Console.WriteLine (p2.X);  // 7
      
      
      
      
      public class Point { public int X, Y; }
      
      Point p1 = new Point();
      p1.X = 7;
      Point p2 = p1;
// Copies p1 reference
      Console.WriteLine (p1.X);  // 7
      Console.WriteLine (p2.X);  // 7
      p1.X = 9;                  // Change p1.X
      Console.WriteLine (p1.X);  // 9
      Console.WriteLine (p2.X);  // 9
      
      
      
      class Point {...}
    ...
    Point p = null;
    Console.WriteLine (p == null);   // True
    // The following line generates a runtime error
    // (a NullReferenceException is thrown):
    Console.WriteLine (p.X);
    
    
    
    struct Point {...}
    ...
    Point p = null;  // Compile-time error
    int x = null;    // Compile-time error
    
    
    
    int i = 5;
    System.Int32 i = 5;

    int a = int.MinValue;
    a--;
    Console.WriteLine (a == int.MaxValue); // True
    
    
    int c = checked (a * b);
  checked {
    // Checks just the expression.
    // Checks all expressions
    // in statement block.
       ...
       c = a * b;
       ...
       }
       int x = int.MaxValue;
       int y = unchecked (x + 1); unchecked { int z = x + 1; }
       
       int x = int.MaxValue + 1;               // Compile-time error
       int y = unchecked (int.MaxValue + 1);   // No errors
       
       
       short x = 1, y = 1;
       short z = x + y;          // Compile-time error
       
       short z = (short) (x + y);   // OK
       
       
       Console.WriteLine ( 0.0 /  0.0);                  //  NaN
       Console.WriteLine ((1.0 /  0.0) − (1.0 / 0.0));   //  NaN
       
       
       
      Console.WriteLine (0.0 / 0.0 == double.NaN); // False
      Console.WriteLine (double.IsNaN (0.0 / 0.0)); // True
      Console.WriteLine (object.Equals (0.0 / 0.0, double.NaN));   // True
      
      
      public class Dude
      {
        public string Name;
        public Dude (string n) { Name = n; }
      }
...
      Dude d1 = new Dude ("John");
      Dude d2 = new Dude ("John");
      Console.WriteLine (d1 == d2);
      Dude d3 = d1;
      Console.WriteLine (d1 == d3);
      // False
      // True
      
      string a = "test";
      string b = "test"; 
      Console.Write (a == b); // True


```
* String

```c#
string a1 = "\\\\server\\fileshare\\helloworld.cs";
string a2 = @ "\\server\fileshare\helloworld.cs";

    string xml = @"<customer id=""123""></customer>";
    string s = "a" + 5; // a5
    int x = 4;
    Console.Write ($"A square has {x} sides"); // Prints: A square has 4 sides
    
    string s = $"255 in hex is {byte.MaxValue:X2}"; // X2 = 2-digit Hexadecimal // Evaluates to "255 in hex is FF"

```


* Array

```c#
    char[] vowels = new char[5];    // Declare an array of 5 characters
    char[] vowels = new char[] {'a','e','i','o','u'};
    char[] vowels = {'a','e','i','o','u'};
    
    
    public struct Point { public int X, Y; } ...
    Point[] a = new Point[1000];
    int x = a[500].X;                  // 0
    
    //Had Point been a class, creating the array would have merely allocated 1,000 null references:
    
    public class Point { public int X, Y; }
    Point[] a = new Point[1000];
    int x = a[500].X; // Runtime error, NullReferenceException
    
    
    
    //1-d arrays
    
    int[,] matrix = new int[3,3];
     for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i,j] = i * 3 + j;
            
   int[,] matrix = new int[,]
    {
      {0,1,2},
      {3,4,5},
      {6,7,8}
};

int[][] matrix = new int[3][];

for (int i = 0; i < matrix.Length; i++) {
  matrix[i] = new int[3];
  for (int j = 0; j < matrix[i].Length; j++)
    matrix[i][j] = i * 3 + j;
}

int[][] matrix = new int[][]
    {
      new int[] {0,1,2},
      new int[] {3,4,5},
      new int[] {6,7,8,9}
};

char[] vowels = {'a','e','i','o','u'};

var i = 3;           // i is implicitly of type int
    var s = "sausage";   // s is implicitly of type string
    
    
    ///heap
    
    using System;
    using System.Text;
class Test {
      static void Main()
      {
        StringBuilder ref1 = new StringBuilder ("object1");
        Console.WriteLine (ref1);
        // The StringBuilder referenced by ref1 is now eligible for GC.
        StringBuilder ref2 = new StringBuilder ("object2");
        StringBuilder ref3 = ref2;
        // The StringBuilder referenced by ref2 is NOT yet eligible for GC.
        Console.WriteLine (ref3);                   // object2
      }
}



```
* Default values

```c#
//You can obtain the default value for any type with the default keyword 

decimal d = default (decimal);
```

* Parameters, Pass by Value and Pass by reference

```c#
//pass by value
class Test {
  static void Foo (int p)
  {
    p = p + 1;
    Console.WriteLine (p);
     static void Main()
     {
    // Increment p by 1
    // Write p to screen
    // Make a copy of x
    // x will still be 8
    int x = 8;
    Foo (x);
    Console.WriteLine (x);

     } 
}


///pass by reference with the ref

class Test {
static void Foo (ref int p) {
}
    p = p + 1;
  Console.WriteLine (p);
}
  
static void Main()
    {
// Increment p by 1
// Write p to screen
// Ask Foo to deal directly with x
// x is now 9
         int x = 8;
        Foo (ref x); Console.WriteLine (x);
   }
 }
 
 //out modifier
 The out modifier is most commonly used to get multiple return values back from a method
 An out argument is like a ref argument, except it:
• Need not be assigned before going into the function
• Must be assigned before it comes out of the function
 class Test {
      static void Split (string name, out string firstNames,
                         out string lastName)
 {
   int i = name.LastIndexOf (' ');
   firstNames = name.Substring (0, i);
   lastName   = name.Substring (i + 1);
}
static void Main()
    {
    string a, b;
    Split ("Stevie Ray Vaughan", out a, out b);
    Console.WriteLine (a);
    Console.WriteLine (b);
    }

}


//params
class Test {

static int Sum (params int[] ints) {
    int sum = 0;
    for (int i = 0; i < ints.Length; i++)
        sum += ints[i]; return sum;
}
  static void Main()
  {
    int total = Sum (1, 2, 3, 4); Console.WriteLine (total);
    // Increase sum by ints[i]
    // 10
    } 
}


//Named arguements

void Foo (int x, int y) { Console.WriteLine (x + ", " + y); }
void Test() {
Foo (x:1, y:2); // 1, 2
}

Named arguments can occur in any order. The following calls to Foo are semanti‐ cally identical:
Foo (x:1, y:2); Foo (y:2, x:1);

int a = 0;
Foo (y: ++a, x: --a); // ++a is evaluated first





```

* NUll operators from C#6
```c#
    string s1 = null;
    string s2 = s1 ?? "nothing";   // s2 evaluates to "nothing"
    
   // The ?. operator is the null-conditional or “Elvis” operator,
   
    System.Text.StringBuilder sb = null;
    string s = sb?.ToString(); // No error; s instead evaluates to null
    
    System.Text.StringBuilder sb = null;
    string s = sb?.ToString().ToUpper(); // s evaluates to null without error
    
    
    `Achtung`
    System.Text.StringBuilder sb = null;
    int length = sb?.ToString().Length; // Illegal : int cannot be null
    
    int? length = sb?.ToString().Length; // OK : int? can be null
    
    
    
System.Text.StringBuilder sb = null;
string s = sb?.ToString() ?? "nothing"; // s evaluates to "nothing"

The last line is equivalent to:
    string s = (sb == null ? "nothing" : sb.ToString());
    
    
```
* switch with goto case anf goto default von [msdn](https://msdn.microsoft.com/en-us/library/06tc147t.aspx)

```c#
      class Program
    {
        static void Main(string[] args)
        {
            int switchExpression = 3;
            switch (switchExpression)
            {
                // A switch section can have more than one case label.
                case 0:
                case 1:
                    Console.WriteLine("Case 0 or 1");
                    // Most switch sections contain a jump statement, such as
                    // a break, goto, or return. The end of the statement list
                    // must be unreachable.
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                    // The following line causes a warning.
                    Console.WriteLine("Unreachable code");
                // 7 - 4 in the following line evaluates to 3.
                case 7 - 4:
                    Console.WriteLine("Case 3");
                    break;
                // If the value of switchExpression is not 0, 1, 2, or 3, the
                // default case is executed.
                default:
                    Console.WriteLine("Default case (optional)");
                    // You cannot "fall through" any switch section, including
                    // the last one.
                    break;
            }
        }
    }
    
    
    //goto case example this is not even possible in `Java`
        class SwitchTest
    {
        static void Main()
        {
            Console.WriteLine("Coffee sizes: 1=small 2=medium 3=large");
            Console.Write("Please enter your selection: ");
            string str = Console.ReadLine();
            int cost = 0;

            // Notice the goto statements in cases 2 and 3. The base cost of 25
            // cents is added to the additional cost for the medium and large sizes.
            switch (str)
            {
                case "1":
                case "small":
                    cost += 25;
                    break;
                case "2":
                case "medium":
                    cost += 25;
                    goto case "1";
                case "3":
                case "large":
                    cost += 50;
                    goto case "1";
                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                    break;
            }
            if (cost != 0)
            {
                Console.WriteLine("Please insert {0} cents.", cost);
            }
            Console.WriteLine("Thank you for your business.");
        }
    }
    /*
        Sample Input: 2
     
        Sample Output:
        Coffee sizes: 1=small 2=medium 3=large
        Please enter your selection: 2
        Please insert 50 cents.
        Thank you for your business.
    */
    
```

* NameSpace


```c#
namespace Outer.Middle.Inner
    {
      class Class1 {}
      class Class2 {}
    }
    
    
    //Repeated namespaces
//You can repeat a namespace declaration, as long as the type names within the name‐ spaces don’t conflict:

```




* Classes

