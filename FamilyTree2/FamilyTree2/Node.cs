using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree2
{
    public class Node<Person>
    {
        public Person person;
        public List<Node<Person>> children { get; set; } 

        public Node(Person person) 
        {
            this.person = person; 
            children = new List<Node<Person>>(); 
        }

        public void addChild(Node<Person> child)
        {
            children.Add(child);
        }

        public Person getPerson()
        {
            
            return person;
        }
        public void setPerson(Person person)
        {
            this.person = person;
        }
    }
}
