
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace LiveCharts2Demo.LogView
{
    public class LogLineManager
    {
        //private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public List<LogLine> logLinesList { get; set; }
        public LogLineManager()
        {
            logLinesList = new List<LogLine>();
        }
        public void AddLine(string line)
        {
            string dateString = line.Substring(0, 10);
            if (DateTime.TryParse(dateString, out DateTime result))
            {
                string[] contents = line.Split(' ');
                DateTime dateTime = GetDateTime(contents[0], contents[1]);
                int thread = int.Parse(contents[2].Substring(1, contents[2].Length - 2));
                string type = contents[3];
                LogType res;
                Enum.TryParse<LogType>(type, out res);
                string message = getMsg(line);
                LogLine ln = new LogLine(dateTime, thread, res, message, false, 1);
                logLinesList.Add(ln);
            }
            else
            {
                string msg = logLinesList[logLinesList.Count - 1].message;
                msg += "\n\t" + line;
                logLinesList[logLinesList.Count - 1].message = msg;
                logLinesList[logLinesList.Count - 1].multiline = true;
                logLinesList[logLinesList.Count - 1].NumberOfLines = logLinesList[logLinesList.Count - 1].NumberOfLines + 1;
            }
        }
        public DateTime GetDateTime(string date, string time)
        {
            int[] values = new int[7];
            int count = 0;
            string tm = time.Substring(0, 8);
            string millisec = time.Substring(time.IndexOf(',') + 1);
            string[] temp = date.Split('-');
            for (int i = 0; i < temp.Length; i++)
            {
                values[count] = Convert.ToInt32(temp[i]);
                count++;
            }
            temp = tm.Split(':');
            for (int i = 0; i < temp.Length; i++)
            {
                values[count] = Convert.ToInt32(temp[i]);
                count++;
            }
            temp = millisec.Split(' ');
            values[count] = Convert.ToInt32(temp[0]);
            count++;
            return new DateTime(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
        }
        public string getMsg(string line)
        {
            line = line.Substring(11);
            line = line.Substring(line.IndexOf('-') + 2);
            return line;
        }
    }
}

