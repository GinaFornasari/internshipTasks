using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTimer
{
    public class TimeEventArgs : EventArgs
    {
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
    }
}
