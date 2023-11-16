using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CollectionsInCsharp
{
    [Serializable]
    public class Person
    {
        [DataMember(Name = "name")]
        public string? Name { get; set; }

        [DataMember(Name = "age")]
        public string? Age { get; set; }

        [DataMember(Name = "city")]
        public string? City { get; set; }
    }
}
