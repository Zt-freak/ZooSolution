using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace ZooApplication
{
	public sealed class Elephant : Animal
	{
		public Elephant(string name) : base(name)
		{
			
		}

        public override int Eat()
        {
			return Energy += 50;
        }

        public override int UseEnergy()
        {
            return Energy -= 5;
        }
    }
}