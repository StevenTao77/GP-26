
using System;
using System.Collections.Generic;

public class PolymorphismDemo
{
    public static void Main()
    {
        List<Animal> myAnimals = new List<Animal>();

        myAnimals.Add(new Dog());
        myAnimals.Add(new Cat());
        myAnimals.Add(new Animal());

        foreach (Animal currentAnimal in myAnimals)
        {
            currentAnimal.MakeSound();
        }
    }
}