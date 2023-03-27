using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TimeInterval
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeInterval(TimeSpan start, TimeSpan end)
        {
            this.Start = start;
            this.End = end;
        }
        public override string ToString()
        {
            return "[" + Start.ToString() + ", " + End.ToString()+" ]";
        }

        public double GetDuration()
        {
            return End.TotalMinutes - Start.TotalMinutes;
        }
    }
}
