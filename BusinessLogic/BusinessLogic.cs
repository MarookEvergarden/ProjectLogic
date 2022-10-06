using System.IO;
namespace BusinessLogic
{
    public class TvSchedule
    {
        private List<TvSlot> Slots;

        private double StartHour;
        private double StartMinutes;
        private string Filepath;

        public TvSchedule(List<TvSlot> Slots)
        {
            this.Slots = Slots;
        }
        public TvSchedule()
        {

        }

        public void SaveToFile(String filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }


       
      
            SetFilepath(filepath);
            using (StreamWriter tw = File.CreateText(filepath))
            {                                       
                tw.WriteLine(GetStartHour.ToString() + "," + GetStartMinutes.ToString() + "," + GetFilepath);

                foreach (TvSlot slot in Slots)
                {
                    tw.WriteLine(slot.GetName + "," + slot.GetTime + "," + slot.GetPath);
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
            if (!File.Exists(file))
            {
                File.Create(file);
            }
            List<string> lines = new List<string>();

            lines = File.ReadAllLines(file).ToList();

            for (int i = 0; i < lines.Count;i++) 
            {
                string[] parts = lines[i].Split(',');
                if (i == 0) 
                {
                    StartHour = Convert.ToDouble(parts[i]);
                    StartMinutes = Convert.ToDouble(parts[i+1]);  
                    Filepath = parts[i+2];
                    continue;
                }
                TvSlot tv = new TvSlot(parts[0], Convert.ToDouble(parts[1]),file);
                tvSlots.Add(tv);
            }
           
        }
        public bool FolderIsExist(string path)
        {
            if (File.Exists(path))
            {

                return true;
            }
            return false;
          
        }

        public string ReturnRandomFile(string path) 
        {
            var di = new DirectoryInfo(path);

            var rgFolders = di.GetDirectories();

            var rand = new Random();
            
            var folder = rgFolders.ElementAt(rand.Next(rgFolders.Count())).FullName;


            var di2 = new DirectoryInfo(folder);

            var files = di2.GetFiles();

            string file = files.ElementAt(rand.Next(0, files.Count())).FullName;

            return file;                
        }

        public void Synchronization(string folderPath, List<TvSlot> tvSlots) 
        {
           /* var di = new DirectoryInfo(folderPath);

            foreach(TvSlot tv in tvSlots) 
            {
                string name = tv.GetName;
                var show = di.GetFiles(name);

                if (show == null) 
                {
                    string creatFolder = 
                    System.IO.Directory.CreateDirectory(folderPath, name);
                }

            }*/
        }

        public TvSchedule(List<TvSlot> Slots, double StartHour, double StartMinutes, string Filepath)
        {

            this.Slots = Slots;
            this.StartMinutes = StartMinutes;
            this.StartHour = StartHour;
            this.Filepath = Filepath; 
        }

        public double GetStartHour { get =>  StartHour; }
        public double SetStartHour { set => StartHour = value; }
        public double GetStartMinutes { get => StartMinutes; }
        public double SetStartMinutes { set => StartMinutes = value; }
        public string GetFilepath { get => Filepath; }
        public void SetFilepath(string path) { Filepath = path; }


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
        private string Path;

        public TvSlot(string Name, double Time, string Path)
        {
            this.Name = Name;
            this.Time = Time;
            this.Path = System.IO.Path.Combine(Path,Name); 
        }
       // public TvSlot() { ; }


        public string GetName { get => Name; }
        public void SetName(string Name) { this.Name = Name; }

        public double GetTime { get => Time; }
        public void SetTime (double Time) { this.Time = Time; }

        public string GetPath { get => Path; }
        public void SetPath(string Path) { this.Path = Path; }

    }

}
        


