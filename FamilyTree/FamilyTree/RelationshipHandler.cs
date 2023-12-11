using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class RelationshipHandler
    {
        List<Relationship> relationships = new List<Relationship>();
        public RelationshipHandler() { }

        public List<Relationship> getRelationships(Person person)
        {
            List<Relationship> returnRels = new List<Relationship>();
            string who = person.name; 
            foreach(Relationship relationship in relationships)
            {
                if ((relationship.getMain()).name == who)
                {
                    returnRels.Add(relationship);
                }
            }
            return returnRels; 
        }

        public void addRelationship(Relationship relationship)
        {
            relationships.Add(relationship);
            Relationship inverse = getInverse(relationship); 
            relationships.Add(inverse);

            //add derived??
        }

        public Relationship getInverse(Relationship relationship)
        {
            Person name1 = relationship.sub; 
            Person name2 = relationship.main;
            
            Relation relation = relationship.relation;
            if (relation.ToString().Equals("Parent"))
            {
                relation = Relation.Child; 
            }
            else if (relation.ToString().Equals("Child"))
            {
                relation = Relation.Parent;
            }

            return new Relationship(name1, name2, relation); 
        }

        public List<Relationship> getDerivedRelationships(Person person)
        {
            List<Relationship> rels = getRelationships(person);
            foreach(Relationship re in rels)
            {
                //get current sub to main
                Person curr = re.getSub();
                Relation currRel = re.relation; 

                List<Relationship> rels2 = getRelationships(curr);

                foreach(Relationship re2 in rels2)
                {
                    string combo = getCombo(currRel.ToString(), re2.relation.ToString()); 
                }
            }
        }

       
            
    }
}
