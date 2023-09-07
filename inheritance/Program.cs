
//3.Write a program to demonstrate single level inheritance and multilevel inheritance
using System;

// Base class
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Animal is eating.");
    }
}

// Derived class from Animal
class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Dog is barking.");
    }
}

// Derived class from Dog
class Bulldog : Dog
{
    public void Guard()
    {
        Console.WriteLine("Bulldog is guarding.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Single-level inheritance
        Dog dog = new Dog();
        dog.Eat(); // Output: Animal is eating.
        dog.Bark(); // Output: Dog is barking.

        Console.WriteLine();

        // Multilevel inheritance
        Bulldog bulldog = new Bulldog();
        bulldog.Eat(); // Output: Animal is eating.
        bulldog.Bark(); // Output: Dog is barking.
        bulldog.Guard(); // Output: Bulldog is guarding.

        Console.ReadLine();
    }
}