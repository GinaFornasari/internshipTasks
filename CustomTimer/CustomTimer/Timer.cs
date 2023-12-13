using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomTimer
{
    public class Timer
    {
        public int total;
        private int offset;
        public DateTime now;
        public int leftOver;
        public string timeMeasure; 
        public delegate void UpdateView(object s, StringEventArgs timeinfo);
        public UpdateView TimeChange;

        //public Timer() : this(0, 0, 0) { }

        public Timer(int total, int offset, DateTime now)
        {
            this.total = total;
            this.offset = offset;
            StringEventArgs strEventArgs = new StringEventArgs()
            {
                updatedTimeLeft = format(total)
            };

            if (TimeChange != null)
            {
                TimeChange(this, strEventArgs);
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
               
                if (total > leftOver && ((e.second - now.Second)+ (e.minute - now.Minute)*60+(e.hour - now.Hour)*3600) == offset)
                {
                    total -= offset;
                    StringEventArgs strEventArgs = new StringEventArgs()
                    {
                        updatedTimeLeft = format(total)
                    };

                    if (TimeChange != null)
                    {
                        TimeChange(this, strEventArgs);
                    }

                   
                    now = DateTime.Now;
                }

                if (total <= leftOver && total > 0 && DateTime.Now != now)
                {
                    total--;

                    StringEventArgs strEventArgs = new StringEventArgs()
                    {
                        updatedTimeLeft = format(total)
                    };

                    if (TimeChange != null)
                    {
                        TimeChange(this, strEventArgs);
                    }

                    now = DateTime.Now;
                }
                


                if (total == 0)
                {
                    theClock.TimeChanged -= delegate (object sender, TimeEventArgs e) { };
                }


            };

        }

        public string format(int num)
        {
            int hrz = num / 3600;
            num = (num%3600);
            int minz = (num / 60);
            num = (num % 60);
            return (hrz + " hours," +Environment.NewLine + minz + " minutes," + Environment.NewLine + num + " seconds" +Environment.NewLine+"remaining");
        }
        public int getUnformatted()
        {
            return total;
            
        }
        public void Paused()
        {
            this.total = 0;
        }
        public void Resumed(Clock theClock, int total, DateTime now)
        {
            this.total = total;
            this.now = now;

            subscribe(theClock);
        }

    }
}