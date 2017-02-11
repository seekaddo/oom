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
* Defaul values

```c#
//You can obtain the default value for any type with the default keyword 

decimal d = default (decimal);
```

