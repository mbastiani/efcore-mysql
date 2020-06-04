using System;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace efcore_mysql
{
    internal static class Program
    {
        private static void Main()
        {
            AddData();
            UpdateData();
            GetData(1);
            DeleteData(1);

            Console.WriteLine("Fim!");
        }

        private static void AddData()
        {
            var random = new Random().Next().ToString();
            var person = new PersonModel
            {
                Name = "Person " + random,
                Email = "Email " + random,
                Phone = random,
                Address = new AddressModel
                {
                    Cep = "17207000",
                    Street = "Nome da rua"
                }
            };

            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            context.Persons.Add(person);
            context.SaveChanges();
        }

        private static void UpdateData()
        {
            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            var person = context.Persons.FirstOrDefault();

            person.Phone += " updated";
            context.Persons.Attach(person).State = EntityState.Modified;
            context.SaveChanges();
        }

        private static void GetData(long id)
        {
            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            var person = context.Persons.Find(id);
            var personJson = JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(personJson);
        }

        private static void DeleteData(long id)
        {
            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            var person = context.Persons.Find(id);

            if (person != null)
            {
                context.Persons.Remove(person);
                context.SaveChanges();
            }
        }
    }
}
