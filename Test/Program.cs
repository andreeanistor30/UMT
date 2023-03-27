using System;
using System.Globalization;
using Test;

class Program
{
    static public void Main(String[] args)
    {
        var calendar1 = Utils.ReadFile(@"../../../../calendar1.txt");
        var calendar2 = Utils.ReadFile(@"../../../../calendar2.txt");

        int meetingTime;
        Console.WriteLine("Meeting time:");
        meetingTime = Int32.Parse(Console.ReadLine());

        var availableIntervals1 = calendar1.GetAvailableIntervals(meetingTime);
        var availableIntervals2 = calendar2.GetAvailableIntervals(meetingTime);
        

        int step1 = 0;
        int step2 = 0;
        while (step1 < availableIntervals1.Count && step2 < availableIntervals2.Count)
        {
            TimeInterval intersection = Utils.IntersectIntervals(availableIntervals1[step1], availableIntervals2[step2]);
            if (intersection != null && intersection.GetDuration() >= meetingTime)
            {
                Console.WriteLine(intersection);
            }

            if (availableIntervals1[step1].End < availableIntervals2[step2].End)
            {
                step1++;
            }
            else
            {
                step2++;
            }
        }
    }
}
