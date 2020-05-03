namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
        public void AddNewAstronautToTheSpaceship()
        {
            Spaceship spaceship = new Spaceship("Enterprise", 30);
            Assert.DoesNotThrow(() => spaceship.Add(new Astronaut("Rus", 40.5)));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ThrowsExceptionWhenCreateSpaceshipWithNullName(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, 30), "Invalid spaceship name!");
        }

        [Test]
        public void ThrowsExceptionWhenCreateSpaceshipWithLessThanZeroCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Ivan", -1));
        }

        [Test]
        public void ThrowsExceptionWhenAddNewAstronautWhenCapacityIsFull()
        {
            Spaceship spaceship = new Spaceship("Universe", 1);
            spaceship.Add(new Astronaut("Rus", 45.5));

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Ivan", 33.3)), "Spaceship is full!");
        }

        [Test]
        public void ThrowsExceptionWhenAddNewAstronautAndSameNameAlreadyExists()
        {
            Spaceship spaceship = new Spaceship("Universe", 5);
            spaceship.Add(new Astronaut("Rus", 100));

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut("Rus", 44.5)), "Astronaut Rus is already in!");
        }

        //[Test]
        //public void ReturnsCorrectCount()
        //{
        //    Spaceship spaceship = new Spaceship("Universe", 20);
        //    spaceship.Add(new Astronaut("Ivan", 45.6));

        //    Assert.That(spaceship.Count == 1);
        //}

        [Test]
        public void ReturnsFalseWhenRemoveData()
        {
            Spaceship spaceship = new Spaceship("Universe", 12);
            spaceship.Add(new Astronaut("Rus", 76));

            Assert.False(spaceship.Remove("Ivan"));
        }

        [Test]
        public void ReturnsTrueWhenRemoveData()
        {
            Spaceship spaceship = new Spaceship("Universe", 12);
            spaceship.Add(new Astronaut("Rus", 76));

            Assert.True(spaceship.Remove("Rus"));
        }
    }
}