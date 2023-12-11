using CustomTimer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTimer
{
    public class Clock
    {
        private int hour;
        private int minute;
        private int second;

        public delegate void TimeChangedHandler(object clock, TimeEventArgs timeinfo);
        public TimeChangedHandler TimeChanged;

        public Clock()
        {
        }

        public void RunClock()
        {
            while (true)
            {
                Thread.Sleep(100);
                DateTime curr = DateTime.Now;

                if (curr.Second != this.second)
                {

                    TimeEventArgs eventArgs = new TimeEventArgs()
                    {
                        hour = curr.Hour,
                        minute = curr.Minute,
                        second = curr.Second
                    };

                    if (TimeChanged != null)
                    {
                        TimeChanged(this, eventArgs);
                    }

                    this.minute = curr.Minute;
                    this.second = curr.Second;
                    this.hour = curr.Hour;
                }

            }
        }

    }
}

