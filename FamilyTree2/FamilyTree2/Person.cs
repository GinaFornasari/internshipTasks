using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree2
{
    public class Person
    {
        public string name; 

        public Person(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }
        public virtual string toString()
        {
            return "Person";
        }

    }
}
