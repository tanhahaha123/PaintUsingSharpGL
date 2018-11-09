using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab1T1.Helper
{
    public class Log
    {
        public DateTime dayDraw;
        public string name;
        public DateTime timeToDraw;

        public static int SoSanh(Log a, Log b)
        {
            if (a.dayDraw > b.dayDraw)
            {
                return -1;
            }
            else if (a.dayDraw == b.dayDraw)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
    public class WriteLog
    {
        static List<Log> list = new List<Log>();
        public static void AddLog(Log newLog)
        {
            list.Add(newLog);
            list.Sort(Log.SoSanh);
            if (list.Count > 6)
            {
                list.Remove(list[6]);
            }
        }

        public static void Render(List<Label> name, List<Label> time)
        {
            int i = 0;
            foreach (var x in list)
            {
                name[i].Text = x.name;
                TimeSpan difference = x.dayDraw - x.timeToDraw;
                time[i].Text = difference.Duration().ToString(@"mm\:ss\:ff");
                i++;
            }
        }
    }
}
