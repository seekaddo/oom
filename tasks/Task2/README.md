### WELCOME to CLASSES


```
Preceding the keyword  `class Attributes` and *class* modi ers. The non-nested class modi ers are `public`, `internal`,`abstract`,`sealed`,`static`,`unsafe`, and `partial`

`Within the braces Class members`   *(these are methods, properties, indexers, events,  elds,
constructors, overloaded operators, nested types, and a  nalizer)*
```

* Class Fields

```
Static modifier     `static`
Access modifiers    `public internal private protected new`
Inheritance modifier `new`
Unsafe code modifier `unsafe`
Read-only modifier  `readonly`
Threading modifier   `volatile`

* A read-only field can be assigned only in its declaration or within the enclosing type’s constructor.*
*An uninitialized field has a default value (0, \0, null, false)*


```
* Methods

```
Static modifier       `static`
Access modifiers      `public internal private protected`
Inheritance modifiers `new virtual abstract override sealed`
Partial method modifier  `partial`
Unmanaged code modifiers  `unsafe extern`
Asynchronous code modifier `async`
````

```c#
int Foo (int x) { return x * 2; }
int Foo (int x) => x * 2;
void Foo (int x) => Console.WriteLine (x);

//Achtung hier
    void Foo (int x) {...}
    void Foo (ref int x) {...}     // OK so far
    void Foo (out int x) {...}     // Compile-time error

```

* Constructors

```c#
public class Panda
{
  string name;
  public Panda (string n)   // the same name and return type als the class
  {
    name = n;

    Panda p = new Panda ("Petey");

  }
}


/*
Access modifiers  public internal private protected 
Unmanaged     code modi ers unsafe extern


A class or struct may overload constructors. 
To avoid code duplication, one con‐ structor may call another, using the this keyword:
*/

using System;
    public class Wine
    {
          public decimal Price;
          public int Year;
          public Wine (decimal price) { Price = price; }
          public Wine (decimal price, int year) : this (price) { Year = year; }  // this is c# style java is different
}
//pass expression to anoth constructor
public Wine (decimal price, DateTime year) : this (price, year.Year) { }

// when no constructor is specified the compiler generate a parameterless one ---> like in java



 public class Bunny
    {
      public string Name;
      public bool LikesCarrots;
      public bool LikesHumans;
      public Bunny () {}
      public Bunny (string n) { Name = n; }
    }
    
    
    // Note parameterless constructors can omit empty parentheses
    Bunny b1 = new Bunny { Name="Bo", LikesCarrots=true, LikesHumans=false };
    Bunny b2 = new Bunny ("Bo")     { LikesCarrots=true, LikesHumans=false };
    
    
    //c#3.0 java like approach
    public Bunny (string name, bool likesCarrots = false, bool likesHumans = false)
    {
        Name = name;
        LikesCarrots = likesCarrots; LikesHumans = likesHumans;
     }
     
     
      Bunny b1 = new Bunny (name: "Bo", likesCarrots: true);
      
      
      //The this
      //The this reference is valid only within nonstatic members of a class or struct.
       public class Test
      {
          string name;
          public Test (string name) { this.name = name; }
    }



```

* Properties

```c#
//A property is declared like a field, but with a get/set block added. Just like in java but here looks different
//The set accessor can be marked private or protected if you want to expose the property as read-only to other types.

public class Stock
{
  decimal currentPrice;           //// The private "backing" field
  public decimal CurrentPrice     // The public property
  {
    get { return currentPrice; }
    set { currentPrice = value; }
  }
}


    decimal currentPrice, sharesOwned;
    public decimal Worth
    {
      get { return currentPrice * sharesOwned; }
    }
    
    // or better
    public decimal Worth => currentPrice * sharesOwned;
    
    
    public decimal CurrentPrice { get; set; } = 123; // read and write
    
     // This gives CurrentPrice an initial value of 123. Properties with an initializer can be read-only:
            public int Maximum { get; } = 999;
   

```


* Implementing an indexer  [mdn](https://msdn.microsoft.com/en-us/library/2549tw02.aspx)

```c#
 class Sentence
    {
      string[] words = "The quick brown fox".Split();
      public string this [int wordNum]     //indexer  // If index is out of range, the temps array will throw the exception.
      {
        get { return words [wordNum];  }
        set { words [wordNum] = value; }
      }
}
public string this [int wordNum] => words [wordNum]; // when there are no setters c#6 makes it simple

//main method here
//Here’s how we could use this indexer:
    Sentence s = new Sentence();
    Console.WriteLine (s[3]);
    s[3] = "kangaroo";
    Console.WriteLine (s[3]);



```



