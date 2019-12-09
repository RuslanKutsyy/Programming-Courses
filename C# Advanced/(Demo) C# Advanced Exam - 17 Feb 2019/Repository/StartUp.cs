using System;

namespace Repository
{
    public class StartUp
    {
        public static void Main()
        {
            var repository = new Repository();
            repository.Add(new Person("George", 10, new DateTime(2009, 05, 04)));
            repository.Add(new Person("Peter", 5, new DateTime(2014, 05, 24)));

            Person foundPerson = repository.Get(0);
            Console.WriteLine($"{foundPerson.Name} is {foundPerson.Age} years old ({foundPerson.Birthdate:dd/MM/yyyy})");

            Person newPerson = new Person("John", 12, new DateTime(2007, 2, 3));
            repository.Update(2, newPerson); // false
            repository.Update(0, newPerson);

            foundPerson = repository.Get(0);
            Console.WriteLine($"{foundPerson.Name} is {foundPerson.Age} years old ({foundPerson.Birthdate:dd/MM/yyyy})");

            Console.WriteLine(repository.Count);

            repository.Delete(5); // false
            repository.Delete(0);

            Console.WriteLine(repository.Count);
        }
    }
}
