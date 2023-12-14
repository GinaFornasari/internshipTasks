using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree3
{
    public class Relationship
    {
        public Person person {  get; set; }
        public Relation relation {  get; set; }
        //public DateTime start; 
        public bool ongoing {  get; set; } 

        public Relationship(Person person, Relation relation, bool ongoing)
        {
            this.person = person;
            this.relation = relation;
            this.ongoing = ongoing;
        }

        
    }

    public enum Relation
    {
        AdoptedChild,
        AdoptedParent,
        Pet,
        Partner
    }

    public class Duration
    {
        public DateTime start{get;set;}
        public DateTime end { get; set; }

        public Duration(DateTime start, DateTime end)
        {
            this.start = start; 
            this.end = end;
        }

    }
}
