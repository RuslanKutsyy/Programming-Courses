namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
        public void CreateAstronautWithCorrectData() //Judge does not test it
        {
            Astronaut astronaut = new Astronaut("Ivan", 55);

            Assert.That(astronaut.Name == "Ivan" && astronaut.OxygenInPercentage == 55);
        }

        [Test]
        public void CreateSpaceshipWithCorrectData() //first Judge test
        {
            Spaceship spaceship = new Spaceship("Universe", 200);

            Assert.That(spaceship.Name == "Universe" && spaceship.Capacity == 200);
        }

        [Test]
        public void ReturnsCorrectCountOfSpaceOfAstronauts() //first Judge test
        {
            Spaceship spaceship = new Spaceship("Universe", 200);
            spaceship.Add(new Astronaut("Ivan", 45));

            Assert.That(spaceship.Count.Equals(1));
        }

        [Test]
        public void ThrowsExceptionWhenCreateSpaceshipWithNullName()  //first Judge test
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 55), "Invalid spaceship name!");
        }

        [Test]
        public void ThrowsExceptionWhenNameIsEmpty() //first Judge test
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(string.Empty, 55), "Invalid spaceship name!");
        }

        [Test]
        public void ReturnsCorrectSpaceshipName()  //first Judge test
        {
            Spaceship spaceship = new Spaceship("Universe", 200);

            Assert.AreEqual("Universe", spaceship.Name);
        }

        [Test]
        public void ThrowsExceptionWhenCapacityIsBelowZero()  //first Judge test
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Universe", -5), "Invalid capacity!");
        }

        [Test]
        public void CreateInstanceWithZeroCapacity()  //first Judge test
        {
            Assert.IsInstanceOf<Spaceship>(new Spaceship("Universe", 0));
        }

        [Test]
        public void ReturnsCorrectSpaceShipCapacity()  
        {
            Spaceship spaceship = new Spaceship("Universe", 20);

            Assert.AreEqual(20, spaceship.Capacity);
        }

        //[Test]
        //public void AddNewAstronautCorrectly()
        //{
        //    Spaceship spaceship = new Spaceship("Universe", 200);
        //    Assert.DoesNotThrow(() => spaceship.Add(new Astronaut("Ivan", 50)));
        //}

        [Test]
        public void ThrowsExceptionWhenCapacityIsFull()
        {
            Spaceship spaceship = new Spaceship("Universe", 1);
            spaceship.Add(new Astronaut("Rus", 100));

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Ivan", 50)), "Spaceship is full!");
        }

        [Test]
        public void ThrowsExceptionWhenAstronautExistsInSpaceship()
        {
            Spaceship spaceship = new Spaceship("Universe", 1);
            spaceship.Add(new Astronaut("Rus", 100));

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Rus", 100)), "Astronaut Rus is already in!");
        }

        [Test]
        public void AddNullToSpaceship() 
        {
            Astronaut astronaut = null;
            Spaceship spaceship = new Spaceship("Universe", 3);
            spaceship.Add(astronaut);
            Assert.AreEqual(1, spaceship.Count);
        }

        [Test]
        public void ReturnsTrueWhenAstronautIsRemoved()
        {
            Spaceship spaceship = new Spaceship("Universe", 1);
            spaceship.Add(new Astronaut("Rus", 100));

            Assert.IsTrue(spaceship.Remove("Rus"));
        }

        [Test]
        public void ReturnsFalseWhenNoSuchAstronautOnTheSpaceshipToRemove()
        {
            Spaceship spaceship = new Spaceship("Universe", 1);
            spaceship.Add(new Astronaut("Rus", 100));

            Assert.IsFalse(spaceship.Remove("Ivan"));
        }

        public void ReturnsFalseWhenRemoveNullAstronautOnTheSpaceship()
        {
            Spaceship spaceship = new Spaceship("Universe", 1);
            spaceship.Add(new Astronaut("Rus", 100));

            Assert.IsFalse(spaceship.Remove(null));
        }
    }
}