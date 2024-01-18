using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Data
{
    public static class PersonData
    {
        public static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person { Name = "Ahmet", Age = 18 },
                new Person { Name = "Selami", Age = 5 },
                new Person { Name = "Elif", Age = 25 },
                new Person { Name = "Mehmet", Age = 40 },
                new Person { Name = "Fatih", Age = 65 },
                new Person { Name = "Bera", Age = 65 },
            };
        }
    }
}