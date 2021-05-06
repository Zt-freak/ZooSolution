using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Zoo.Models
{
    public abstract class Animal
    {
        public int Energy { get; set; }
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
            Energy = 100;
        }

        public virtual int Eat() 
        { 
            return Energy += 25;
        }

        public abstract int UseEnergy();
    }
}
