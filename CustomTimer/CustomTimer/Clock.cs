using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomTimer
{
    public class Clock
    {
        public int total;
        public int offset;

        private int hour;
        private int minute;
        private int second;

        public delegate void TimeChangedHandler(object clock, TimeEventArgs timeinfo);
        public TimeChangedHandler TimeChanged;

        public Clock(int total, int offset)
        { 
            this.total = total;
            this.offset = offset;
            this.minute = DateTime.Now.Minute;
            this.second = DateTime.Now.Second;
            this.hour = DateTime.Now.Hour;
           
        }

        public void RunClock()
        {
            while (true)
            {
                Thread.Sleep(100);
                DateTime currTime = DateTime.Now;
                if((currTime.Second - this.second)==offset)
                {
                    //update timer, update stored time
                    TimeEventArgs eventArgs = new TimeEventArgs()
                    {
                        hour = currTime.Hour,
                        minute = currTime.Minute,
                        second = currTime.Second
                    };

                    if (TimeChanged != null)
                    {
                        TimeChanged(this, eventArgs);
                    }
                    this.minute = currTime.Minute;
                    this.second = currTime.Second;
                    this.hour = currTime.Hour;
                }


            }
        }
    }

}
