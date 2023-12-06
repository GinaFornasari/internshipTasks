using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsTask
{
    public class Friends : Exception
    {
        public Friends() { }
        public Friends(string str)
            : base("Don't be desperate")
        {

        }
        }
        
    
}



