using FamilyTree3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FamilyTree
{
    public class Program
    {
        public static readonly string filePath = "C:\\Users\\ginaf\\source\\repos\\GinaFornasari\\internshipTasks\\FamilyTree3\\FamilyTree3\\Family.json";
        public static Manager manager = new Manager();
        public static void Main()
        {
            //Manager manager = new Manager();
            manager.LoadData(filePath);
            manager.PrintFamilyTree(); 

            Console.WriteLine("Start a new family(N), See family(S), Add Member(A), Add relationship(R), See Person Details(D), Exit(E)");
            char ans = char.Parse(Console.ReadLine());

            do
            {
                switch (ans)
                {
                    case ('N'):
                        startNewTree(manager);
                        goto case 'A'; 

                    case ('A'):
                        Console.WriteLine("What is your name?");
                        string name = Console.ReadLine();

                        addPerson(name, manager);
                        break;

                    case ('S'):
                        manager.PrintFamilyTree();
                        break;

                    case ('R'):
                        Console.WriteLine("Who are we tampering with? (ID number expected)");
                        addRelationships(manager.GetPerson(int.Parse(Console.ReadLine())), manager); 
                        break;

                    case ('D'):
                        Console.WriteLine("Who are we looking at? (ID number expected)");
                        Console.WriteLine(manager.GetPerson(int.Parse(Console.ReadLine())).showRelationships());
                        break;

                    case ('E'):
                        System.Environment.Exit(0);
                        break; 
                }

                Console.WriteLine("Start a new family(N), See family(S), Add Member(A), Add relationship(R), See Person Details(D), Exit(E)");
                ans = char.Parse(Console.ReadLine());

            } while (!ans.Equals('E'));

            writeChanges();
            manager.PrintFamilyTree();
        }

        public static void startNewTree(Manager manager)
        {
            List<Person> list = new List<Person>();
            Console.WriteLine("How many Originals would you like to add? (These are people will null in the parent field)");
            int num = int.Parse(Console.ReadLine());

            for(int i=1; i<=num; i++)
            {
                Console.WriteLine($"Enter the name of person {i}: ");
                string name = Console.ReadLine();
                Console.WriteLine($"Enter the id of {name}: ");
                int id = int.Parse(Console.ReadLine());

                Person person = new Person(id, null, null);
                person.name = name; 
                list.Add(person);
            }
            manager.addOriginals(list); 
            
        }
            
        public static void addPerson(string name, Manager manager )
        {
            Console.WriteLine($"What is your ({name}) ID number?");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Who is your biological Mother?");
            string mother = Console.ReadLine();
            Console.WriteLine($"What is {mother}'s ID number? ");
            int momID = int.Parse(Console.ReadLine());
            Console.WriteLine("Who is your biological Father?");
            string father = Console.ReadLine();
            Console.WriteLine($"What is  {father} 's ID number? ");
            int dadID = int.Parse(Console.ReadLine());

            if (!find(momID, manager.family))
            {
                Console.WriteLine($"{mother} is not found, would you like to add her details? ");
                if (Console.ReadLine().Equals("yes")){
                    addPerson(mother, manager);
                }
                else
                {
                    Person temp = new Person(momID, null, null);
                    temp.name = mother;
                    manager.family.Add(temp);
                    writeChanges(); 
                }
               
            }
            if (!find(dadID, manager.family))
            {
                Console.WriteLine($"{father} is not found, would you like to add his details? ");
                if (Console.ReadLine().Equals("yes"))
                {
                    addPerson(father, manager);
                }
                else
                {
                    Person temp = new Person(dadID, null, null);
                    temp.name = father;
                    manager.family.Add(temp);
                    writeChanges();
                }
            }

            Person person = new Person(id, manager.GetPerson(momID), manager.GetPerson(dadID));
            person.name = name;
            manager.family.Add(person);
            writeChanges(); 
            manager.addBioChild(momID, id);
            manager.addBioChild(dadID, id);
            }

        public static bool find(int id, List<Person> family)
        {
            foreach(Person person in family)
            {
                if (person.id.Equals(id))
                {
                    return true;
                }
            }
            return false; 
        }

        public static void addRelationships(Person person, Manager manager)
        {
            Console.WriteLine("Who is the second party? (Name)");
            string otherguy = Console.ReadLine();
            Console.WriteLine("Who is the second party? (ID)");
            int id = int.Parse(Console.ReadLine());
            if (!find(id, manager.family))
            {
                Console.WriteLine("Second party not found in system, please add them first:");
                addPerson(otherguy, manager);
            }

            Console.WriteLine("What is the relation? \nAdoptedChild(C),\nAdoptedParent(A),\nPartner(P)");
            char relation = char.Parse(Console.ReadLine());
            Console.WriteLine("Is this relationship ongoing?");
            string ongoing = Console.ReadLine();
            bool ong = false;
            if (ongoing.Equals("Yes"))
            {
                ong = true;
            }

            switch (relation)
            {
                case ('C'):
                    person.relationships.Add(new Relationship(manager.GetPerson(id), Relation.AdoptedChild, ong));
                    writeChanges();
                    (manager.GetPerson(id)).relationships.Add(new Relationship(person, Relation.AdoptedParent, ong));
                    writeChanges();
                    break;

                case ('A'):
                    person.relationships.Add(new Relationship(manager.GetPerson(id), Relation.AdoptedParent, ong));
                    writeChanges();
                    (manager.GetPerson(id)).relationships.Add(new Relationship(person, Relation.AdoptedChild, ong));
                    writeChanges();
                    break;

                case ('P'):
                    person.relationships.Add(new Relationship(manager.GetPerson(id), Relation.Partner, ong));
                    writeChanges();
                    (manager.GetPerson(id)).relationships.Add(new Relationship(person, Relation.Partner, ong));
                    writeChanges();
                    break;
            }
        }


            public static void updatePerson(Person person, Manager manager)
        {
            Console.WriteLine("What would you like to update/change?" +
                "ID\nbioMom\nbioDad\nGender\nName"); 
            //blah blah blah
        }

       public static void writeChanges()
        {
            string updatedJson = JsonConvert.SerializeObject(manager.family, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
            manager.LoadData(filePath);
        }

    }
}

