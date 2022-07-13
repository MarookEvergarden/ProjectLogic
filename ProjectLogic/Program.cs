// See https://aka.ms/new-console-template for more information

namespace Project
{
    class TvSchedule
    {
        private List<TvTimeSlot> timeSlots;

        public TvSchedule(List<TvTimeSlot> timeSlots)
        {
            this.timeSlots = timeSlots;
        }

        public Show FindShowForTime(int hour, int minute) 
        {
            if (minute == 59)
            {
                hour += 1;
                minute = 0;
            }

            for (int i = 0; i < timeSlots.Count; i++) 
            {
               
                if (timeSlots[i].StartHour <= hour && hour < timeSlots[i].EndHour) 
                {
                    if (timeSlots[i].StartMinute <= minute && minute < timeSlots[i].EndMinute || timeSlots[i].StartMinute <= minute && timeSlots[i].EndMinute == 0)
                    {
                        return timeSlots[i].Show;
                    }
                }                
            }
            return null;
        }
    }

    class TvTimeSlot
    {
        private int startHour;
        private int startMinute;
        private int endHour;
        private int endMinute;
        private Show show;

        public TvTimeSlot(Show show, int startHour, int startMinute, int endHour, int endMinute)
        {
            if (endMinute == 0) { this.endMinute = 59; this.endHour = endHour - 1; } else { this.endMinute = endMinute - 1; }
            this.show = show;
            this.startHour = startHour; 
            this.startMinute = startMinute; 
            this.endHour = endHour;
            
        }

        public int StartMinute { get => startMinute; }
        public int StartHour { get => startHour; }
        public Show Show { get => show; }
        public int EndHour { get => endHour; }
        public int EndMinute { get => endMinute; }



    }

    class Show
    {
        private String name;
        public Show(string? name)
        {
            this.name = name ?? "Unnamed show";
        }
        public string Name { get => name;}

        public int GetNumber(int n)
        {
            return n;
        }
    }

    class TvPlayer
    {
        private TvSchedule schedule;

        public TvPlayer(TvSchedule schedule)
        {
            this.schedule = schedule;
        }
    }

    class Project
    {
        public static void Main()
        {
            List<TvTimeSlot> timeSlots = new List<TvTimeSlot>()
            {
                new TvTimeSlot(new Show("Dexter"), 10, 00, 11, 00),
                new TvTimeSlot(new Show("Picky Blinders"), 11, 00, 12, 30),
                new TvTimeSlot(new Show("F1"), 12, 30, 15, 00)
            };
            TvSchedule schedule = new TvSchedule(timeSlots);
           /* Show show = schedule.FindShowForTime(12, 20);                        
            
            if (show == null) 
            {
                Console.WriteLine("ooops there is no show at this time");
            }
            else { Console.WriteLine("At 11 shows name is - " + show.Name); }*/


           Show show = schedule.FindShowForTime(10, 59);

            if (show == null)
            {
                Console.WriteLine("ooops there is no show at this time");
            }
            else { Console.WriteLine("At 11 shows name is - " + show.Name); }

            /*Time now = Time.now;
            Show show = schedule.findShowForTime(now.GetHour(), now.GetMinute());*/
        }
    }
}

