using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomTimer
{
    public class Timer
    {
        private int total;
        private int offset;
        public int now;
        public int leftOver;
        // public Form1 form = new Form1();
        public delegate void UpdateView( string timeinfo);
        public UpdateView TimeChange;

        //public Timer() : this(0, 0, 0) { }

        public Timer(int total, int offset, int now)
        {
            this.total = total;
            this.offset = offset;
           
            if (TimeChange != null)
            {
                TimeChange("LOL");
            }
            
            this.now = now;
            this.leftOver = total % offset;
        }
        public void subscribe(Clock theClock)
        {

            //theClock.TimeChanged += delegate(object sender, TimeEventArgs e)
            //lambda notation
            theClock.TimeChanged +=
            (sender, e) =>
            {
                if (total > leftOver && e.second - now == offset)
                {
                    //Console.WriteLine(total - offset);
           
                    total -= offset;
                    if (TimeChange != null)
                    {
                        TimeChange("LOL2");
                    }
                    now = e.second;
                }

                if (total <= leftOver && total > 0 && e.second != now)
                {
                    //Console.WriteLine(--total);
                    total--;
                    if (TimeChange != null)
                    {
                        TimeChange("LOL3");
                    }
                    now = e.second;
                }


                if (total == 0)
                {
                    theClock.TimeChanged -= delegate (object sender, TimeEventArgs e) { };
                }


            };

        }

    }
}