﻿using log4net;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Relationship
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1));
        public Person person { get; set; }
        public Relation relation { get; set; }
        public bool ongoing { get; set; }
        public Relationship(Person person, Relation relation, bool ongoing)
        {
            this.person = person;
            this.relation = relation;
            this.ongoing = ongoing;
        }
        public override string ToString()
        {
            return person.name + ": Relation = " + relation.ToString() + Environment.NewLine + "Ongoing: " + ongoing.ToString();
        }
    }
    public enum Relation
    {
        AdoptedChild,
        AdoptedParent,
        Pet,
        Partner
    }
}