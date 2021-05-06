using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Zoo.Models
{
	public sealed class Monkey : Animal
	{
		public Monkey(string name) : base(name)
		{
			Energy = 60;
		}

		public override int Eat()
		{
			return Energy += 10;
		}

		public override int UseEnergy()
		{
			return Energy -= 2;
		}
	}
}