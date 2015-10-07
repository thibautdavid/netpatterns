using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pediatre.Training.NetPatterns.Decorator
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void ListPersonsByNameReversedAndThenByAge()
        {
            // Arrange
            var persons = new List<Person>
            {
                new Person {Age = 30, Name = "Martin"},
                new Person {Age = 32, Name = "Martin"},
                new Person {Age = 34, Name = "Audrey"},
                new Person {Age = 14, Name = "Julien"},
                new Person {Age = 24, Name = "Michal"},
                new Person {Age = 94, Name = "Pierre"},
                new Person {Age = 34, Name = "Catherine"},
                new Person {Age = 74, Name = "Luca"},
                new Person {Age = 34, Name = "Sophie"}
            };

            // Act
            persons.Sort(Person.ByName.Reversed().ThenBy(Person.ByAge));
            
            // Assert
            foreach (var person in persons)
            {
                Console.Out.WriteLine($"{person.Name}\t\t {person.Age}");
            }
        }
    }
}
