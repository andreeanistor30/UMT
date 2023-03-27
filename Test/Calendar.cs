using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Calendar
    {
        public List<TimeInterval> Intervals { set; get; }

        public TimeInterval RangeLimit { set; get; }

        public Calendar() 
        {
            Intervals = new List<TimeInterval>();
        }
        public Calendar(List<TimeInterval> intervals, TimeInterval rangeLimit)
        {
            Intervals = intervals;
            this.RangeLimit = rangeLimit;
        }

        public void AddInterval(TimeInterval interval)
        {
            Intervals.Add(interval);
        }

        public List<TimeInterval> GetAvailableIntervals(int meetingTime)
        {
            List<TimeInterval> availableIntervals = new List<TimeInterval>();
            if(Intervals.Count == 0)
            {
                availableIntervals.Add(RangeLimit);
                return availableIntervals;
            }
            if (RangeLimit.Start < Intervals[0].Start)
            {
                TimeInterval timeInterval = new TimeInterval(RangeLimit.Start, Intervals[0].Start);
                if (timeInterval.GetDuration() >= meetingTime)
                {
                    availableIntervals.Add(timeInterval);
                }
            }
            for(int i=0;i<Intervals.Count-1;i++) 
            {
                if (Intervals[i].End < Intervals[i + 1].Start)
                {
                    TimeInterval timeInterval = new TimeInterval(Intervals[i].End, Intervals[i + 1].Start);
                    if (timeInterval.GetDuration() >= meetingTime)
                    {
                        availableIntervals.Add(timeInterval);
                    }
                }
            }
            if (Intervals[Intervals.Count-1].End<RangeLimit.End)
            {
                TimeInterval timeInterval = new TimeInterval(Intervals[Intervals.Count - 1].End, RangeLimit.End);
                if (timeInterval.GetDuration() >= meetingTime)
                {
                    availableIntervals.Add(timeInterval);
                }
            }
            return availableIntervals;
        }
    }
}
