using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Person
    {
        public int id;
        public Person bioMom { get; set; }
        public Person bioDad { get; set; }
        public List<Person> bioChildren { get; set; }
        public Gender gender { get; set; }
        public List<Relationship> relationships { get; set; }
        public string name { get; set; }
        public Person(int id, Person bioMom, Person bioDad)
        {
            this.id = id;
            this.bioMom = bioMom;
            this.bioDad = bioDad;
            bioChildren = new List<Person>();
            relationships = new List<Relationship>();
            gender = Gender.Non;
        }
        public string getInfo()
        {
            string retStr = "Name: " + name + Environment.NewLine + "ID: " + id + Environment.NewLine
                +"Gender: " + gender + Environment.NewLine;   
            retStr += "Biological Parents: ";
            retStr += showParents(); 
            retStr += Environment.NewLine + "Biological Children: ";
            retStr += showChildren(); 
            retStr += Environment.NewLine+ "Other relationships:";
            retStr += showOthers(); 
            return retStr;
        }

        public string showParents()
        {
            string retStr = ""; 
            if (bioMom == null)
            {
                retStr += "mother not available, ";
            }
            else
            {
                retStr += bioMom.name + " (mother), ";
            }
            if (bioDad == null)
            {
                retStr += "father not available.";
            }
            else
            {
                retStr += bioDad.name + " (father)";
            }
            return retStr; 
        }
        public string showChildren()
        {
            string retStr = "";
            if (bioChildren.Count > 0)
            {
                foreach (Person person in bioChildren)
                {
                    retStr += Environment.NewLine + person.name + "(ID: " + person.id + ")";
                }
            }
            else
            {
                retStr += "No children";
            }
            return retStr;
        }
        public string showOthers()
        {
            string retStr = ""; 
            foreach (Relationship relation in relationships)
            {
                retStr += Environment.NewLine + relation.ToString();
            }
            return retStr;
        }


    }
    public enum Gender
    {
        Male,
        Female,
        Non
    }
}
