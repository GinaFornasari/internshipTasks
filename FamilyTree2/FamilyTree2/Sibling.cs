using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree2
{
    public class Sibling : Person
    {
        Relationship relationship;
        Person sibling;
        public Sibling(string name, Person sibling) : base(name)
        {
            this.sibling = sibling;
            this.relationship = new Relationship(sibling, Relation.Sibling);
        }

        public override string toString()
        {
            return "\tSibling to " + sibling.getName(); ;
        }
    }
}
