using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace SQLModifications.Escalation
{
    public class Scheduler: IDisposable
    {
        private readonly Timer clock;

        public Scheduler() // treba da primi parametar na koliko minuta se izvrsava
        {
            clock = new Timer();
            clock.Interval = 1000; // svake sekunde radi nesto
        }

        public void Start()
        {
            clock.Elapsed += Clock_Elapsed;
            this.clock.Start();
        }

        public void Stop()
        {
            clock.Elapsed -= Clock_Elapsed;
            this.clock.Stop();
        }
        private void Clock_Elapsed(object sender, ElapsedEventArgs e)
        {
            var now = DateTime.Now;

            // Here we check 9:00.000 to 9:00.999 AM. Because clock runs every 1000ms, it should run the schedule
            if (now.DayOfWeek == DayOfWeek.Monday &&
                (now.TimeOfDay >= new TimeSpan(0, 9, 0, 0, 0) && now.TimeOfDay <= new TimeSpan(0, 9, 0, 0, 999)))
            {
                // 9 AM schedule
            }

            if (now.Date.Day == 1 &&
                (now.TimeOfDay >= new TimeSpan(0, 9, 0, 0, 0) && now.TimeOfDay <= new TimeSpan(0, 9, 0, 0, 999)))
            {
                // 1 day of the month at 9AM
            }

            //svake sekunde
            if(now.TimeOfDay >= new TimeSpan(0, 9, 0, 0, 0) && now.TimeOfDay <= new TimeSpan(0, 9, 0, 0, 999))
            {
               
            }
        }

        public void Dispose()
        {
            if (this.clock != null)
            {
                this.clock.Dispose();
            }
        }
    }
}
