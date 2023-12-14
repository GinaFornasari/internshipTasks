using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree3
{
    public class Person
    {
        public int id;
        public Person bioMom {  get; set; }
        public Person bioDad { get; set; }
        public List<Person> bioChildren { get; set; }
        public Gender gender { get; set; }
        public List<Relationship> relationships { get; set; }
        public string name{ get; set; }

        public Person(int id, Person bioMom, Person bioDad) 
        {
            this.id = id; 
            this.bioMom = bioMom;
            this.bioDad = bioDad;

            bioChildren = new List<Person>();
            relationships = new List<Relationship>();
        }

        public string getInfo()
        {
            //need to fix since bioMOm or dad can be null
            return id + ": " + name + ", " + gender + "\n" + bioMom.name + " " + bioDad.name + "\nBioChildren: " + display(bioChildren) + "\nRelationships" + showRelationships() + "\n";
        }

        public virtual string display(List<Person> list)
        {
            string returnStr = ""; 
            foreach (Person person in list)
            {
                returnStr += person.name + "\n";
            }
            return returnStr; 
        }
        public virtual string display(List<Relationship> list)
        {

            string returnStr = "";
            foreach (Relationship rel in list)
            {
                returnStr += rel.person.name + " ("+rel.relation.ToString() + ")";
                if (rel.ongoing)
                {
                    returnStr += "\tCurrent"; 
                }
            }
            return returnStr;
        }

        public string showRelationships()
        {
            string str =""; 
            foreach (Relationship rel in relationships)
            {
                str += rel.person.name + ", " + rel.relation.ToString() + ", " + rel.ongoing+"\n"; 
            }

            for(int i=1; i<bioChildren.Count; i++)
            {
                if (bioChildren[i] != null)
                {
                    str += bioChildren[i].name + "\n";
                }
               
            }
            return str;
        }

    }

    public enum Gender
    {
        Male,
        Female, 
        other
    }

}
