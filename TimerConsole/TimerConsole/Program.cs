using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a total");
            int total = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an offset");
            int offset = int.Parse(Console.ReadLine());


            var theClock = new Clock();
            var timer = new CustomTimer(total, offset, DateTime.Now.Second);
            timer.subscribe(theClock); 
            theClock.RunClock();
        }
    }
}
