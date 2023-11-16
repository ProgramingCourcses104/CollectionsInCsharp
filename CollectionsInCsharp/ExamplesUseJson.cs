using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsInCsharp
{
    public class ExamplesUseJson
    {
        public void ExampleJsonReadWrite()
        {
            Random random = new Random();
            string filePath = "people.json";


            List<Person> people = JsonHelper.ReadJson<List<Person>>(filePath);

            // check not null
            if(people == null )
            {
                people = new List<Person>();
            }

            //add new object
            var person = new Person()
            {
                Name = "Test Name",
                Age = random.Next(10, 101).ToString(),
                City = "test city"
            };

            people.Add(person);


            // modify first object
            people.FirstOrDefault().Age = random.Next(10, 101).ToString();

            JsonHelper.WriteJson(filePath, people);

        }
    }
}
