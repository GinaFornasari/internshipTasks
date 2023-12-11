using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree2
{
    public class Partner : Person
    {
        Relationship relationship;
        Person partner; 
        public Partner(string name, Person partner) : base(name)
        {
            this.partner = partner;
            this.relationship = new Relationship(partner, Relation.Partner);
        }

        public override string toString()
        {
            return "\tPartner to " + partner.getName(); ; 
        }
    }
}
