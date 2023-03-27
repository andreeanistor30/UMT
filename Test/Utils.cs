using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Utils
    {
        public static Calendar ReadFile(string path)
        {
            if(File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    Calendar calendar = new Calendar();
                    if ((s = sr.ReadLine()) != null)
                    {
                        if (!s.Equals("[[]]"))
                        {
                            string array = s.Substring(2, s.Length - 4);
                            string[] substring = array.Split("], [");
                            for (int i = 0; i < substring.Length; i++)
                            {
                                string[] times = substring[i].Split(",");
                                TimeSpan start = TimeSpan.Parse(times[0].Substring(1, times[0].Length - 2));
                                TimeSpan end = TimeSpan.Parse(times[1].Substring(1, times[1].Length - 2));
                                TimeInterval timeInterval = new TimeInterval(start, end);
                                calendar.AddInterval(timeInterval);
                            }
                        }
                    }
                    if ((s = sr.ReadLine()) != null)
                    {
                        string substring = s.Substring(1,s.Length - 2);
                        string[] times = substring.Split(",");
                        TimeSpan start = TimeSpan.Parse(times[0].Substring(1, times[0].Length - 2));
                        TimeSpan end = TimeSpan.Parse(times[1].Substring(1, times[1].Length - 2));
                        TimeInterval timeInterval = new TimeInterval(start, end);
                        calendar.RangeLimit= timeInterval;
                    }
                    return calendar;    
                }
            }
            return null;
        }
        public static TimeInterval IntersectIntervals(TimeInterval timeInterval1,TimeInterval timeInterval2)
        {
            if(timeInterval1.Start <= timeInterval2.Start && timeInterval1.End >= timeInterval2.End)
            {
                return timeInterval2;
            }
            else if(timeInterval2.Start <= timeInterval1.Start && timeInterval2.End >= timeInterval1.End)
            {
                return timeInterval1;
            }
            else if (timeInterval1.End >= timeInterval2.Start && timeInterval2.End >= timeInterval1.End)
            {
                return new TimeInterval(timeInterval2.Start, timeInterval1.End);
            }
            else if (timeInterval2.End >= timeInterval1.Start && timeInterval1.End >= timeInterval2.End )
            {
                return new TimeInterval(timeInterval1.Start, timeInterval2.End);
            }
            return null;
        }
    }

    
}
