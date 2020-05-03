namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;
    using System.Linq;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        [Test]
        public void TestIfItSetsNewFishName()
        {
            Fish fish = new Fish("Ivan");
            fish.Name = "Nemo";
            Assert.That(fish.Name == "Nemo");
        }

        [Test]
        public void ChangeFishAvailability()
        {
            Fish fish = new Fish("Ivan");
            fish.Available = false;

            Assert.IsTrue(fish.Available == false);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ThrowsExceptionWhenAquariumNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 20), "Invalid aquarium name!");
        }

        [Test]
        public void ThrowsExceptionWhenAquariumCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Nemo", -4), "Invalid aquarium capacity!");
        }

        [Test]
        public void ReturnsCorrectAquariumFishCount()
        {
            Aquarium aquarium = new Aquarium("Aqua", 20);
            aquarium.Add(new Fish("Nemo"));

            Assert.That(aquarium.Count == 1);
        }

        [Test]
        public void ThrowsExceptionWhenAquariumIsFull()
        {
            Aquarium aquarium = new Aquarium("Aqua", 1);
            aquarium.Add(new Fish("Nemo"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Ivan")), "Aquarium is full!");
        }

        [Test]
        [TestCase("Ivan")]
        [TestCase("Rus")]
        public void ThrowsExceptionWhenNoSuchFishToRemove(string name)
        {
            Aquarium aquarium = new Aquarium("Aqua", 1);
            aquarium.Add(new Fish("Nemo"));

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(name), $"Fish with the name Ivan doesn't exist!");
        }

        [Test]
        [TestCase("Ivan")]
        [TestCase("Rus")]
        public void ThrowsExceptionWhenNoSuchFishToSell(string name)
        {
            Aquarium aquarium = new Aquarium("Aqua", 1);
            aquarium.Add(new Fish("Nemo"));

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(name), $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void ChangeAvailabilityWhenSellAFish()
        {
            Aquarium aquarium = new Aquarium("Aqua", 5);
            Fish nemo = new Fish("Nemo");
            aquarium.Add(nemo);
            aquarium.SellFish("Nemo");

            Assert.IsTrue(nemo.Available == false);
        }

        [Test]
        public void ReturnsTheCorrectDataInReport()
        {
            Aquarium aquarium = new Aquarium("Aqua", 5);
            Fish nemo = new Fish("Nemo");
            Fish nemo2 = new Fish("Ivan");
            List<Fish> fish = new List<Fish>();
            fish.Add(nemo);
            fish.Add(nemo2);
            aquarium.Add(nemo);
            aquarium.Add(nemo2);
            string allFish = string.Join(", ", fish.Select(f => f.Name));

            Assert.That(aquarium.Report() == $"Fish available at {aquarium.Name}: {allFish}");
        }
    }
}
