using FamilyTree;
using log4net;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Manager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1));
        public static List<Person> family; 

        private static Manager instance;
        private static readonly object lockObject = new object();

        public event Action<string> MessageUpdated;

        private Manager()
        {
            family = new List<Person>();
        }
        public static Manager Instance
        {
            get
            {
                // Double-check locking for thread safety
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Manager();
                        }
                    }
                }
                return instance;
            }
        }

        public List<Person> getFamily()
        {
            return family;
        }

        public List<Person> LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);

                family = JsonConvert.DeserializeObject<List<Person>>(jsonContent);
            }
            else
            {
                log.Error("The specified JSON file does not exist.");
            }

            return family; 
        }
      
        public void addOriginals(List<Person> list)
        {
            family.Clear();
            foreach (Person person in list)
            {
                family.Add(person);
            }
            //writeChanges();

        }

        public void PrintFamilyTree()
        {

            
            //Console.WriteLine($"{new string(' ', depth * 2)}{person}");
            string str = ""; 
            foreach (Person child in family)
            {
              str += child.name;
            }
            MessageUpdated?.Invoke(str);

        }

        public Person GetPerson(int id)
        {
            foreach (Person child in family)
            {
                if (child.id == id)
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
            //Console.WriteLine($"{Parent.name} and {Child.name}");
        }

        public void AddMember(Person person)
        {
            family.Add(person);

        }



    }
}
