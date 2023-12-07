using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimerConsole
{
    public class CustomTimer
    {
        private int total;
        private int offset;
        public int now;
        public CustomTimer() : this(0, 0, 0) { }
          
        public CustomTimer(int total, int offset, int now) 
        {
            this.total = total;
            this.offset = offset;
            Console.WriteLine(total);
            this.now = now;
        }
        public void subscribe(Clock theClock)
        {
            //theClock.TimeChanged += delegate(object sender, TimeEventArgs e)
            //lambda notation
            theClock.TimeChanged +=
            (sender, e) =>
            { 
                if ( e.second - now == offset)
                {
                    Console.WriteLine(total - offset);
                    total -= offset;
                    now =e.second;
                }
            };
        }
    }
}
