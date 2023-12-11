using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FamilyTree2
{
    public class Program
    {
        public static List<Person> people = new List<Person>();

        public static void Main(string[] args)
        {
            //List<Person> people = new List<Person>();
            Person God = new Person("God");
            people.Add(God);
            Person collie = new Person("Collie");
            people.Add(collie);
            Partner frank = new Partner("Frank", collie);
            people.Add(frank);
            Person luca = new Person("Luca");
            people.Add(luca);
            Person gina = new Person("Gina");
            people.Add(gina);
            Partner luke = new Partner("Luke", gina);
            people.Add(luke);
            Sibling vaughin = new Sibling("Vaughin", collie);
            people.Add(vaughin);

            Node<Person> root = new Node<Person>(God);
           
            Node<Person> col = new Node<Person>(collie);
            Node<Person> fr = new Node<Person>(frank);
            Node<Person> va = new Node<Person>(vaughin);
            root.addChild(col);
            root.addChild(fr);
            root.addChild(va);

            Node<Person> gi = new Node<Person>(gina);
            Node<Person> lu = new Node<Person>(luca);
            col.addChild(gi);
            col.addChild(lu);
            fr.addChild(gi);
            fr.addChild(lu);

            Node<Person> luk = new Node<Person>(luke);
            gi.addChild(luk);

            //loadTree();

            Console.WriteLine("See tree (S) or add a person(A)? ");
            char answer = Char.Parse(Console.ReadLine());
            
            if(answer.Equals('S') || answer.Equals('s'))
            {
                showTree(root);
            }
            else if (answer.Equals('A') || answer.Equals('a'))
            {
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Relation: ");
                string relation = Console.ReadLine();
                Console.WriteLine("To who: ");
                string otherguy = Console.ReadLine();

                Console.WriteLine(getOtherGuy(otherguy, root,0).toString()); ;

                if (relation.Equals("Sibling"))
                {
                    //Sibling sib = new Sibling(name, getOtherGuy(otherguy));
                }
                //Person otherdude = findOtherGuy(otherguy);

            }
            else
            {
                Console.WriteLine("Not an option");
                System.Environment.Exit(0); 
            }

        }

        public static void showTree(Node<Person> person)
        {
            Console.WriteLine("Tree Structure:");
            PrintTree(person, 0);
        }
        static void PrintTree(Node<Person> node, int depth)
        {
            Console.WriteLine($"{new string(' ', depth * 2)}{node.getPerson().getName()}{node.getPerson().toString()}");

            foreach (var child in node.children)
            {
                PrintTree(child, depth + 1);
            }
        }

         static Person getOtherGuy(string name, Node<Person> node, int depth)
        {
            string currentName = node.getPerson().getName();
            
            foreach (var child in node.children)
            {
                if (currentName.Equals(name))
                {
                    Console.WriteLine("found"); 
                    return child.getPerson();
                    
                }
                else
                {
                    return getOtherGuy(name, child, depth + 1);
                }
               
            }
            return null;
        }

       

    }
}
