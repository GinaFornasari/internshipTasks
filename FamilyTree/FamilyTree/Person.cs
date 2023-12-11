using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }   
        public Gender gender { get; set; }

        public Person(int id,string name, Gender gender) { 
            this.id = id;
            this.name = name;
            this.gender = gender;
        }

        public Person getPerson()
        {
            return this;
        }

    }
}
