using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree3
{
    public class Manager
    {
        public List<Person> family = new List<Person>();
        public Manager()
        {
            
        }
        public void LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);

                family = JsonConvert.DeserializeObject<List<Person>>(jsonContent);
            }
            else
            {
                Console.WriteLine("The specified JSON file does not exist.");
            }
        }
        public void addOriginals(List<Person> list)
        {
            foreach (Person person in list)
            {
                family.Add(person);
            }

        }

        public void PrintFamilyTree()
        {
            //Console.WriteLine($"{new string(' ', depth * 2)}{person}");

            foreach (Person child in family)
            {
                Console.WriteLine(child.name);
            }
        }

        public Person GetPerson(int id)
        {
            foreach(Person child in family)
            {
                if(child.id == id)
                {
                    return child;
                }
            }
            return null;
        }

        public void addBioChild(int parent, int child)
        {
            Person Parent = GetPerson(parent);
            Person Child = GetPerson(child); 
            Parent.bioChildren.Add(Child);
            //child is null referenced??
            Console.WriteLine($"{Parent.name} and {Child.name}");
        }

        public void AddMember(Person person)
        {
            family.Add(person);
            
        }



    }
}
