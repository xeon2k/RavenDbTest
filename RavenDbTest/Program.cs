using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;

namespace RavenDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IDocumentStore store = new DocumentStore { Urls = new[]{ "http://localhost:8080" } , Database = "Person"};
            store.Initialize();

            var person = new Person { Name = "Nitin" };
            IDocumentSession session = store.OpenSession();
            session.Store(person);
            session.SaveChanges();

            Console.WriteLine($"Person record created with Id {person.Id}");

            Person loadedPerson = session.Load<Person>(person.Id.ToString());

            Console.WriteLine($"Person record loaded for Id {loadedPerson.Id}");
        }
    }

    public record Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

}
