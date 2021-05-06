using System;
using Xunit;
using Zoo.Models;

namespace ZooTestproject
{
    public class AnimalTests
    {
        [Fact]
        public void ElephantEatTest()
        {
            Elephant ruud = new Elephant("Ruud");
            ruud.Eat();
            Assert.Equal(150, ruud.Energy);
        }

        [Fact]
        public void ElephantUseEnergyTest()
        {
            Elephant henk = new Elephant("Henk");
            henk.UseEnergy();
            Assert.Equal(95, henk.Energy);
        }
    }
}
