using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveCharts2Demo.LogFile;

namespace LiveCharts2Demo
{
    internal class MiniLogCreator
    {
        private string[] logEntries;
        private Dictionary<DateTime, string> logData;

        private Dictionary<DateTime, string> unsuccessfulSessionLogs = new Dictionary<DateTime, string>();
        private Dictionary<DateTime, string> successfulSessionLogs = new Dictionary<DateTime, string>();
        private Dictionary<DateTime, string> offlineLogs = new Dictionary<DateTime, string>();
        private Dictionary<DateTime, string> diagnosticsLogs = new Dictionary<DateTime, string>();
        private Dictionary<DateTime, string> errorLogs = new Dictionary<DateTime, string>();

        public MiniLogCreator(Dictionary<DateTime, string> logData)
        {
            this.logData = logData; ;

            foreach (var logEntry in logData)
            {
                if (logEntry.Value.Contains("Offline"))
                {
                    offlineLogs.Add(logEntry.Key, logEntry.Value);
                }
                else if (logEntry.Value.Contains("Warning"))
                {
                    diagnosticsLogs.Add(logEntry.Key, logEntry.Value);
                }
                else if (logEntry.Value.Contains("Error"))
                {
                    errorLogs.Add(logEntry.Key, logEntry.Value);
                }
                // Add more conditions for other types of logs
            }
        }

       

        
        public Dictionary<DateTime, string> OfflineLogs => offlineLogs;
        public Dictionary<DateTime, string> DiagnosticsLogs => diagnosticsLogs;
        public Dictionary<DateTime, string> ErrorLogs => errorLogs;
    }
}
