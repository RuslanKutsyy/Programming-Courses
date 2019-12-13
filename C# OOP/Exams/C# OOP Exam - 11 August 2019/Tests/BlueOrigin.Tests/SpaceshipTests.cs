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

    }
}