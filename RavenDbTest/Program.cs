using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;

namespace RavenDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IDocumentStore store = new DocumentStore { Urls = new[]{ "http://localhost:8080" } , Database = "Persons"};
            store.Initialize();

            var person = new Person { Name = "Nitin" };
            IDocumentSession session = store.OpenSession();
            session.Store(person);
            session.SaveChanges();

            Person loadedPerson = session.Load<Person>(person.Id.ToString());

            Console.WriteLine(loadedPerson.Name);
        }
    }

    public record Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

}
