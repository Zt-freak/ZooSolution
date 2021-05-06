using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace ZooApplication
{
    public abstract class Animal
    {
        public int Energy { get; set; }
        public string Name { get; set; }

        public Animal()
        { }

        public int Eat() 
        { 
            Energy += 25;

            return Energy;
        }
    }
}
