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
        private static readonly ILog log = LogManager.GetLogger(typeof(Manager));
        public static readonly string filePath = "C:\\Users\\ginaf\\source\\repos\\GinaFornasari\\internshipTasks\\FamilyTree\\FamilyTree\\Family.json";
        private List<Person> family;
        private static Manager instance;
        private Manager()
        {
            family = new List<Person>();
            LoadData();
        }
        public static Manager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Manager();
                }
                return instance;
            }
        }
        public void AddMember(Person person)
        {
            family.Add(person);
        }
        public List<Person> getFamily()
        {
            return family;
        }
        public void LoadData()
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
        }
        public void writeChanges()
        {
            try
            {
                string updatedJson = JsonConvert.SerializeObject(Manager.Instance.getFamily(), Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
                Manager.Instance.LoadData();
            }
            catch (Exception ex)
            {
                log.Error("Something went wrong when trying to read the JSON file");
                log.Error(ex.ToString());
            }
        }
        public void addOriginals(List<Person> list)
        {
            family.Clear();
            foreach (Person person in list)
            {
                family.Add(person);
            }
        }
        public bool find(int id)
        {
            foreach (Person person in family)
            {
                if (person.id.Equals(id))
                {
                    return true;
                }
            }
            return false;
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
        public Person GetPersonByName(string name)
        {
            foreach (Person child in family)
            {
                if (child.name == name)
                {
                    return child;
                }
            }
            return null;
        }
        public bool checkValid(string name, int id)
        {
            if (GetPerson(id).name.Equals(name))
            {
                return true; 
            }
            return false;
        }
        public void addBioChild(int parent, int child)
        {
            if(!find(parent) || !find(parent))
            {
                return; 
            }
            Person Parent = GetPerson(parent);
            Person Child = GetPerson(child);
            Parent.bioChildren.Add(Child);   
        }
    }
}
