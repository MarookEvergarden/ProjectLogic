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
            if(FindHour < StartHour) 
            {
                return null;
            }
            else { 
                double FindinThisMinute = FindHour * 60 + FindMinute;
                double StartHour = GetStartHour * 60 + GetStartMinutes;
                double SearchTime = FindinThisMinute - StartHour;
                double TimeCounter = 0;

                for (int i = 0; i < Slots.Count;i++) 
                {
                   if( SearchTime <= TimeCounter + Slots[i].GetTime) 
                    {
                        return Slots[i];
                    }
                
                }
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
        


