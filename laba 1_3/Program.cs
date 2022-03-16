using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace qwerty 
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Restaurant { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person Paul = new Person() 
                { 
                    Name = "Paul Allen", Age = 26, Restaurant = "Dorsia" 
                };
                await JsonSerializer.SerializeAsync<Person>(fs, Paul);
                Console.WriteLine("Данные сохранены");
            }

            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
                Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}  Restaurant: {restoredPerson.Restaurant}");
            }
            File.Delete("user.json");
            Console.WriteLine("Файл удалён");
        }
    }
}