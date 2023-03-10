using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User_NN_Lib
{
    public class Calculation
    {
        public string[] AvailablePeriods(List<TimeSpan> startTimes, List<int> durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            List<TimeSpan> workRoad = new List<TimeSpan>();
            workRoad.Add(beginWorkingTime);

           
            int n = 0;
            int b = 0;
            while (true) {
                if (workRoad[n] + new TimeSpan(0, consultationTime, 0) >= endWorkingTime)
                {
                    break;
                }
                else
                {
                    if (startTimes[b] >= workRoad[n] && startTimes[b] < (workRoad[n] + new TimeSpan(0, consultationTime, 0)))
                    {
                        workRoad[n] = (startTimes[b] + new TimeSpan(0, durations[b], 0));
                        b++;
                    }

                    else
                    {
                        workRoad.Add(workRoad[n] + new TimeSpan(0, consultationTime, 0));
                        n++;
                    }
                }
                

            


                
                
            }
            string[] result = new string[workRoad.Count()] ; 
            for (int i = 0; i < workRoad.Count(); i++)
            {
                result[i] +=  workRoad[i].ToString("hh\\:mm") + "-" + (workRoad[i] + new TimeSpan(0, consultationTime, 0)).ToString("hh\\:mm");
            }


            


            return result;
        }
    }
}
