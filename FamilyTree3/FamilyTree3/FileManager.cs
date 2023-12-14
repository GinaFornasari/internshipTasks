using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace FamilyTree3
{
    public class FileManager
    {
        public FileManager(string jsonFilePath) {  }
        public List<Person> LoadJsonData(string filePath)
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read the entire contents of the file
                string jsonContent = File.ReadAllText(filePath);

                // Deserialize the JSON content into a List of Person objects
                List<Person> people = JsonConvert.DeserializeObject<List<Person>>(jsonContent);

                return people;
            }
            else
            {
                Console.WriteLine("The specified JSON file does not exist.");
                return null;
            }
        }

        /*
        public void writeChanges(string jsonFilePath, List<Person> list)
        {
            string updatedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(jsonFilePath, updatedJson);
        }*/
    }
}
