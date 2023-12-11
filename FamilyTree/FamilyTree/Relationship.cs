using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Relationship
    {
        public Person main {  get; set; }
        public Person sub { get; set; }
        public Relation relation { get; set; }

        public Relationship(Person main, Person sub, Relation relation)
        {
            this.main = main;
            this.sub = sub;
            this.relation = relation;
        }

        public Person getMain()
        {
            return main;
        }

        public Person getSub()
        {
            return sub;
        }

        public string toString()
        {
            return main.name + " is a " + relation.ToString() + " to " + sub.name;
        }
    }
}
