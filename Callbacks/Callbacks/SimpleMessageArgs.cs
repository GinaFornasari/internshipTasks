using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callbacks
{
    public class SimpleMessageArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
