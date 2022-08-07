using System.IO;
namespace BusinessLogic
{
    public class TvSchedule
    {
        private List<TvSlot> Slots;

        private double StartHour;
        private double StartMinutes;

        public TvSchedule(List<TvSlot> Slots)
        {
            this.Slots = Slots;
        }

        public void SaveToFile(String filepath)
        {
           /* String NewLine = String.Join("\n", Slots);
            System.IO.File.WriteAllText(filepath, NewLine);*/
           using(StreamWriter tw = new StreamWriter(filepath)) 
            {
                //tw.WriteLine(string.Format("{0},{1}",StartHour, StartMinutes));
                tw.WriteLine(GetStartHour.ToString() + "," + GetStartMinutes.ToString());
                foreach (TvSlot slot in Slots) 
                {
                    tw.WriteLine(slot.GetName + "," + slot.GetTime);
                }
            }
        }

        public TvSchedule(List<TvSlot> Slots, double StartHour, double StartMinutes)
        {
            this.Slots = Slots;
            this.StartMinutes = StartMinutes;
            this.StartHour = StartHour;
        }

        public double GetStartHour { get =>  StartHour; }
        public double GetStartMinutes { get => StartMinutes; }

        public TvSlot FindShow(double FindHour, double FindMinute) 
        {            
            double FindinThisMinute = FindHour * 60 + FindMinute;
            double ScheduleStartsMinute = GetStartHour * 60 + GetStartMinutes;
            double SearchTime = FindinThisMinute - ScheduleStartsMinute;
            double TimeCounter = 0;
            
            if (SearchTime < 0) return null;

            foreach (TvSlot slot in Slots)
            {
                if (SearchTime <= TimeCounter + slot.GetTime)
                {
                    return slot;
                }
                TimeCounter += slot.GetTime;
            }

            return null;            
        }
     
    }

    public class TvSlot
    {
        private string Name;
        private double Time;

        public TvSlot(string Name, double Time)
        {
            this.Name = Name;
            this.Time = Time;
        }


        public string GetName { get => Name; }
        public double GetTime { get => Time; }
    }

   /* public class TvPlayer
    {
        private TvSchedule schedule;

        public TvPlayer(TvSchedule schedule)
        {
            this.schedule = schedule;
        }



    }*/
}
        


