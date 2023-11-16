using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CollectionsInCsharp
{
    public static class JsonHelper
    {
        public static T ReadJson<T>(string jsonFilePath)   
        {
            T jsonData;

            using (StreamReader reader = new StreamReader(jsonFilePath))
            {
                string jsonString = reader.ReadToEnd();

                jsonData = JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return jsonData;
        }

        public static void WriteJson<T>(string jsonFilePath, T data)
        {
            if(!File.Exists(jsonFilePath))
            {
                File.Create(jsonFilePath).Close();
            }

            var serializedData = JsonSerializer.Serialize(data);

            using (StreamWriter writer = new StreamWriter(jsonFilePath))
            {
                writer.Write(serializedData);
            }

            //OR
            //File.WriteAllText(jsonFilePath,serializedData);
        }
    }
}
