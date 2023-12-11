using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree2
{
    public class Relationship
    {
        Person person { get; set; }
        public Relation relation; 

        public Relationship(Person person, Relation relation)
        {
            this.person = person;
            this.relation = relation;
        }
    }

    public enum Relation
    {
        Sibling, 
        Partner, 
        Child
    }
}
