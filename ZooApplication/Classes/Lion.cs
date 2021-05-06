using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace ZooApplication
{
	public sealed class Lion : Animal
	{
		public Lion(string name) : base(name)
		{
		}
		public override int UseEnergy()
		{
			return Energy -= 10;
		}
	}
}