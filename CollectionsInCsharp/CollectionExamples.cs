using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CollectionsInCsharp
{
    public class CollectionExamples
    {
        static List<Person> people = new List<Person>
        {
            new Person { Name = "John", Age = "25", City = "New York" },
            new Person { Name = "Alice", Age = "30", City = "Los Angeles" },
            new Person { Name = "Bob", Age = "22", City = "Chicago" },
            new Person { Name = "Eve", Age = "20",City = "San Francisco" },
            new Person { Name = "Tyler", Age = "21",City = "San Francisco" }
        };

        #region from object
        public void WriteCollectionObject()
        {
            Console.WriteLine("Original Data:");
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age} years old");
            }

            // LINQ Query to filter people older than 25, order by age, and select name and age
            //var result = from person in people
            //             where person.Age > 25
            //             orderby person.Age
            //             select new { person.Name, person.Age };

            var result = people.Where(person => int.Parse(person.Age) > 25)
                .OrderBy(person => person.Age)
                .Select(person => new { person.Name, person.Age });

            Console.WriteLine("\nFiltered and Sorted Data:");
            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age} years old");
            }
        }
        #endregion

        #region json
        public void WriteCollectionJson()
        {
            string jsonString = File.ReadAllText("people.json");

            List<Person> people = JsonSerializer.Deserialize<List<Person>>(jsonString);

            //var item =  people.FirstOrDefault(e => e.Name == "Tyler");
            //item.Age = 25;

            //var serializedData = JsonSerializer.Serialize(people);

            //File.WriteAllText("people.json", serializedData);

            Console.WriteLine("Data from JSON:");
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age} years old, {person.City}");
            }
        }
        #endregion

        #region xml
        public void WriteCollectionXml()
        {
            XDocument doc = XDocument.Load("people.xml");

            // Parse XML into a collection of Person objects using LINQ to XML
            List<Person> peopleXml = doc.Descendants("Person")
                                     .Select(p => new Person
                                     {
                                         Name = p.Element("Name").Value,
                                         City = p.Element("City").Value,
                                         Age = p.Element("Age").Value
                                     })
                                     .ToList();

            Console.WriteLine("Data from XML:");
            foreach (var person in peopleXml)
            {
                Console.WriteLine($"{person.Name} - {person.Age} years old");
            }
        }
        #endregion

        #region Where OrderBy Select GroupBy Join Average
        public void WriteMainMethods()
        {
            var filteredPeople = people.Where(person => int.Parse(person.Age) > 25);

            Console.WriteLine("Фільтрація (Where):");
            foreach (var person in filteredPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age} years old, {person.City}");
            }

            // Сортування (OrderBy, OrderByDescending): Сортувати за віком у зростаючому порядку
            var sortedPeople = people.OrderBy(person => person.Age);

            Console.WriteLine("\nСортування (OrderBy):");
            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age} years old, {person.City}");
            }

            // Проектування (Select): Вибрати ім'я та місто людей
            var projectedPeople = people.Select(person => new { person.Name, person.City });

            Console.WriteLine("\nПроектування (Select):");
            foreach (var person in projectedPeople)
            {
                Console.WriteLine($"{person.Name}, {person.City}");
            }

            // Групування (GroupBy): Згрупувати за містом та підрахувати кількість людей у кожному місті
            var groupedPeople = people.GroupBy(person => person.City)
                                      .Select(group => new { City = group.Key, Count = group.Count() });

            Console.WriteLine("\nГрупування (GroupBy):");
            foreach (var group in groupedPeople)
            {
                Console.WriteLine($"{group.City}: {group.Count} people");
            }

            // Об'єднання (Join): Об'єднати дані з двох списків за спільним ключем (місто)
            List<Person> additionalPeople = new List<Person>
        {
            new Person { Name = "Charlie", Age = "35", City = "New York" },
            new Person { Name = "David", Age = "28", City = "Chicago" }
        };

            var joinedPeople = people.Join(additionalPeople, p1 => p1.City, p2 => p2.City,
                                           (p1, p2) => new { Name1 = p1.Name, Name2 = p2.Name, City = p1.City });

            Console.WriteLine("\nОб'єднання (Join):");
            foreach (var person in joinedPeople)
            {
                Console.WriteLine($"{person.Name1} from {person.City} and {person.Name2}");
            }

            // Агрегація (Sum, Average, Count, Max, Min): Знайти середній вік усіх людей
            var averageAge = people.Average(person => int.Parse(person.Age));

            Console.WriteLine($"\nАгрегація (Average): Average Age: {averageAge}");
        }
        #endregion

        public void GetByURL() 
        {

            //string githubRepoUrl = "https://raw.githubusercontent.com/exampleuser/example-repo/main";

            string githubRepoUrl = $"https://raw.githubusercontent.com/Valik-Yarema/mockdata/main/mockerson.json";


            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonContent = client.GetStringAsync(githubRepoUrl).Result;

                    var jsonData = JsonSerializer.Deserialize<List<Person>>(jsonContent);

                    Console.WriteLine(jsonContent);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
