using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTimer
{
    public class Timer
    {
        public int total;
        public int offset; 
        public Timer(int total, int offset)
        {
            this.total = total;
            this.offset = offset;
        }
        public void subscribe(Clock clock)
        {
            clock.TimeChanged += (sender, e) =>
            {
                Console.WriteLine("updated");
            }; 

        }
    }
}
