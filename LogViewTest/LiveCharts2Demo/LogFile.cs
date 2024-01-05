using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCharts2Demo
{
    internal class LogFile
    {
        
        public Dictionary<DateTime, string> logData;

        public LogFile()
        {
            InitializeLogFile();
        }

        private void InitializeLogFile()
        {
        logData = new Dictionary<DateTime, string>();

            // Simulated log entries - replace this with actual log file parsing
            logData[DateTime.Parse("2023-12-31T10:10:10Z")] = "Warning: Disk space running low";
            logData[DateTime.Parse("2023-12-31T12:05:55Z")] = "Error: File not found";
            logData[DateTime.Parse("2023-12-31T14:20:00Z")] = "Information: Configuration updated";
            logData[DateTime.Parse("2023-12-31T15:45:30Z")] = "User session expired";
            logData[DateTime.Parse("2023-12-31T18:00:00Z")] = "Warning: Memory usage above threshold";
            logData[DateTime.Parse("2023-12-31T19:12:05Z")] = "Error: Database connection failed";
            logData[DateTime.Parse("2023-12-31T20:30:10Z")] = "Information: Application started";
            logData[DateTime.Parse("2023-12-31T22:00:00Z")] = "App Starting...";
            logData[DateTime.Parse("2023-12-31T22:05:00Z")] = "Info: Intermediate log entry 1";
            logData[DateTime.Parse("2023-12-31T22:10:00Z")] = "Info: Intermediate log entry 2";
            logData[DateTime.Parse("2023-12-31T22:15:00Z")] = "Info: Intermediate log entry 3";
            logData[DateTime.Parse("2023-12-31T22:30:00Z")] = "App Starting...";
            logData[DateTime.Parse("2023-12-31T22:35:00Z")] = "Info: Intermediate log entry 1";
            logData[DateTime.Parse("2023-12-31T22:40:00Z")] = "App Ended.";
            logData[DateTime.Parse("2023-12-31T23:20:00Z")] = "App Starting...";
            logData[DateTime.Parse("2023-12-31T23:25:00Z")] = "Info: Intermediate log entry 1";
            logData[DateTime.Parse("2023-12-31T23:30:00Z")] = "Info: Intermediate log entry 2";
            logData[DateTime.Parse("2023-12-31T23:35:00Z")] = "Info: Intermediate log entry 3";
            logData[DateTime.Parse("2023-12-31T23:40:00Z")] = "App Ended.";
            logData[DateTime.Parse("2023-12-31T23:35:00Z")] = "SuccessfulSessions: Task completed successfully";
            logData[DateTime.Parse("2023-12-31T23:40:00Z")] = "Diagnostics: Running system check";
            logData[DateTime.Parse("2023-12-31T23:45:00Z")] = "Error: Connection timeout";
            logData[DateTime.Parse("2023-12-31T23:50:00Z")] = "Offline: Connection lost";
            logData[DateTime.Parse("2023-12-31T23:59:59Z")] = "User logged in successfully";


        }
    }
}
