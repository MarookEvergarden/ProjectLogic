using System.IO;
namespace BusinessLogic
{
    public class TvSchedule
    {
        private List<TvSlot> Slots;

        public double StartHour;
        public double StartMinutes;

        public TvSchedule(List<TvSlot> Slots)
        {
            this.Slots = Slots;
        }

        public void SaveToFile(String filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);       
            }


           /* String NewLine = String.Join("\n", Slots);
            System.IO.File.WriteAllText(filepath, NewLine);*/
           using(StreamWriter tw = File.CreateText(filepath)) 
            {
                //tw.WriteLine(string.Format("{0},{1}",StartHour, StartMinutes));
                tw.WriteLine(GetStartHour.ToString() + "," + GetStartMinutes.ToString());
                foreach (TvSlot slot in Slots) 
                {
                    tw.WriteLine(slot.GetName + "," + slot.GetTime);
                }
            }
        }

        public bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files
            // are not the same.

            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is
            // equal to "file2byte" at this point only if the files are
            // the same.
            return ((file1byte - file2byte) == 0);
        }

        public void ReadScheduleFromFile(string file, List<TvSlot> tvSlots) 
        {
            List<string> lines = new List<string>();

            lines = File.ReadAllLines(file).ToList();

            for (int i = 0; i < lines.Count;i++) 
            {
                string[] parts = lines[i].Split(',');
                if (i == 0) 
                {
                    StartHour = Convert.ToDouble(parts[i]);
                    StartMinutes = Convert.ToDouble(parts[i+1]);                  
                    continue;
                }
                TvSlot tv = new TvSlot(parts[0], Convert.ToDouble(parts[1]));
                tvSlots.Add(tv);
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


        public TvSchedule(List<TvSlot> Slots, String filepath)
        {
            ReadScheduleFromFile(filepath, Slots);
            this.Slots = Slots;
        }
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
        


