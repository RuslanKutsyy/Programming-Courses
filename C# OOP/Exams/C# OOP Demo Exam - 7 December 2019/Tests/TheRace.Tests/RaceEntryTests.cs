using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreatesMotorCycleWithCorrectData()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("SX1", 100, 2000);

            Assert.True(motorcycle.Model == "SX1" && motorcycle.HorsePower == 100 && motorcycle.CubicCentimeters == 2000);
        }

        [Test]
        public void CreatesUnitRiderWithCorrectData()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("SX1", 100, 2000);
            UnitRider rider = new UnitRider("Ivan", motorcycle);

            Assert.True(rider.Name == "Ivan" && rider.Motorcycle == motorcycle);
        }

        [Test]
        public void ThrowExceptionWhenCreatingRiderWithNullName()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, new UnitMotorcycle("SX1", 100, 2000)));
        }

        [Test]
        public void RaceReturnsCorrectRidersCount()
        {
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddRider(new UnitRider("Ivan", new UnitMotorcycle("SX1", 100, 2000)));

            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void ReturnStringWhenAddRider()
        {
            UnitRider rider = new UnitRider("Ivan", new UnitMotorcycle("SX1", 100, 2000));
            RaceEntry race = new RaceEntry();
            string result = race.AddRider(rider);

            Assert.AreEqual("Rider Ivan added in race.", result);
        }

        [Test]
        public void ThrowExceptionWhenRiderIsNull()
        {
            UnitRider rider = null;
            RaceEntry race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.AddRider(rider), "Rider cannot be null.");
        }

        [Test]
        public void ThrowExceptionWhenAddingDuplicateRider()
        {
            UnitRider rider = new UnitRider("Ivan", new UnitMotorcycle("SX1", 100, 2000));
            RaceEntry race = new RaceEntry();
            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => race.AddRider(rider));
        }

        [Test]
        public void ThrowExceptionWhenLessThen2RidersInRaceToCalculateAverageHorsePower()
        {
            RaceEntry race = new RaceEntry();
            UnitRider rider = new UnitRider("Ivan", new UnitMotorcycle("SX1", 100, 2000));

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void ReturnsCorrectDataWhenCalculateAverageHorsePower()
        {
            RaceEntry race = new RaceEntry();
            UnitRider rider = new UnitRider("Ivan", new UnitMotorcycle("SX1", 100, 2000));
            UnitRider rider2 = new UnitRider("Rus", new UnitMotorcycle("SGX1", 200, 3000));
            race.AddRider(rider);
            race.AddRider(rider2);

            Assert.AreEqual(150, race.CalculateAverageHorsePower());
        }
    }
}