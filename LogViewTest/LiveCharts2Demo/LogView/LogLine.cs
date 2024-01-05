
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace LiveCharts2Demo.LogView
{
    public class LogLine
    {
        //private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public DateTime dateTime { get; set; }
        public int thread { get; set; }
        public LogType type { get; set; }
        public string message { get; set; }
        public bool multiline { get; set; }
        public int NumberOfLines { get; set; }
        public LogLine(DateTime dateTime, int thread, LogType type, string message, bool multiline, int NumberOfLines)
        {
            this.dateTime = dateTime;
            this.thread = thread;
            this.type = type;
            this.message = message;
            this.multiline = multiline;
            this.NumberOfLines = NumberOfLines;
        }
        public override string ToString()
        {
            return dateTime + " [" + thread + "] " + type + " - " + message;
        }
    }
    public enum LogType
    {
        INFO,
        WARN,
        ERROR,
        DEBUG
    }
}
