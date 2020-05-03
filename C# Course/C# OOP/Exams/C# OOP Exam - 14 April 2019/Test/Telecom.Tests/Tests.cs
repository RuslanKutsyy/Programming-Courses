namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        //check if throw exception if no such number in phonebook when call

        [Test]
        public void CreateNewPhoneInstanceWithCorrectData()
        {
            Phone phone = new Phone("Siemens", "CS75");
            Assert.True("Siemens" == phone.Make && "CS75" == phone.Model);
        }

        [Test]
        public void ThrowsExceptionWhenMakeIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "1100"), "Invalid null!");
        }

        [Test]
        public void ThrowExceptionWhenCreatePhoneWithNullModel()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Siemens", null), "Invalid null!");
        }

        [Test]
        public void CountReturnsCorrectCount()
        {
            Phone phone = new Phone("Siemens", "CX75");
            phone.AddContact("Ivan", "0897897844");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void ThrowExceptionIfPersonIsAlreadyExistsInPhonebook()
        {
            Phone phone = new Phone("Siemens", "CX75");
            phone.AddContact("Ivan", "0897897844");

            Assert.Throws<InvalidOperationException > (() => phone.AddContact("Ivan", "0897897844"), "Person already exists!");
        }

        [Test]
        public void GetStringWhenCallTheNumberFromPhoneBook()
        {
            Phone phone = new Phone("Siemens", "CX75");
            phone.AddContact("Ivan", "0897897844");

            Assert.AreEqual("Calling Ivan - 0897897844...", phone.Call("Ivan"));
        }

        [Test]
        public void ThrowExceptionIfNoSuchPhoneNumberInPhoneBookWhenCall()
        {
            Phone phone = new Phone("Siemens", "CX75");
            phone.AddContact("Ivan", "0897897844");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Rus"), "Person doesn't exists!");
        }
    }
}