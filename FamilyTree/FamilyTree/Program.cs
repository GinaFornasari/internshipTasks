using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Person mom = new Person(1, "collie", Gender.Female);
            Person son = new Person(2, "luca", Gender.Male);
            Person dad = new Person(3, "frank", Gender.Male);
            Person daughter = new Person(4, "Gina", Gender.Female); 
            Person uncle = new Person(5, "Vaughin", Gender.Male);

            RelationshipHandler handler = new RelationshipHandler();
            handler.addRelationship(new Relationship(mom, son, Relation.Parent));
            handler.addRelationship(new Relationship(mom, dad, Relation.Partner));
            handler.addRelationship(new Relationship(dad, son, Relation.Parent));
            handler.addRelationship(new Relationship(mom, daughter, Relation.Parent));
            handler.addRelationship(new Relationship(dad, daughter, Relation.Parent));
            handler.addRelationship(new Relationship(son, daughter, Relation.Sibling));
            handler.addRelationship(new Relationship(uncle, mom, Relation.Sibling));

            display(handler.getRelationships(mom));
            Console.WriteLine(""); 
            display(handler.getRelationships(dad));
            Console.WriteLine("");
            display(handler.getRelationships(son));
            Console.WriteLine("");
            display(handler.getRelationships(daughter));
            Console.WriteLine("");
            display(handler.getRelationships(uncle));


            

        }

        public static void display(List<Relationship> relations)
        {
            foreach (Relationship rel in relations)
                {
                    Console.WriteLine(rel.toString());
                };
        }

        
    }
}
