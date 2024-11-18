using System.Net.Sockets;

namespace SF2022User_NN_Lib
{
    public class Calculations
    {
        public string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            List<string> temp = new List<string>();
            while (beginWorkingTime < endWorkingTime)
            {
                TimeSpan b_next = beginWorkingTime.Add(TimeSpan.FromMinutes(consultationTime));
                int schet=0;

                TimeSpan kri = b_next;
                for (int i = 0; i < startTimes.Length; i++)
                {
                    TimeSpan p = startTimes[i].Add(TimeSpan.FromMinutes(durations[i]));
                    if (beginWorkingTime >= startTimes[i] && beginWorkingTime < p)
                    {
                        schet += 1;
                        kri = p;
                    }
                    else if (b_next > startTimes[i] && b_next <= p)
                    {
                        schet += 1;
                        kri = p;
                    }
                    else if(startTimes[i]>beginWorkingTime && startTimes[i]<beginWorkingTime.Add(TimeSpan.FromMinutes(consultationTime))){
                        schet += 1;
                        kri = p;
                    }
                    

                }
                if (schet > 0)
                {
                   
                    beginWorkingTime =kri;
                    continue;
                }
                temp.Add(forma(beginWorkingTime,b_next));
                beginWorkingTime = b_next;
            }
            return temp.ToArray();
        }
        string forma(TimeSpan begin, TimeSpan next)
        {
            string[] many = new string[] { Convert.ToString(begin.Hours),
                    Convert.ToString(begin.Minutes),
                    Convert.ToString(next.Hours),
                    Convert.ToString(next.Minutes)
                    };
            for (int vr = 0; vr < many.Length; vr++)
            {
                if (many[vr].Length == 1)
                {
                    many[vr] = "0" + many[vr];
                }
            }
            return many[0] + ":" + many[1] + "-" + many[2] + ":" + many[3];

        }
    }
}