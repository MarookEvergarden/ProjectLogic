using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForms
{
    public partial class Form3 : Form
    {
        private List<TvSlot> timeSlots;
        private TvSchedule schedule;
        private DateTimePicker timePicker;

        private static string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string FileSafe = System.IO.Path.Combine(CurrentDirectory, @"Schedule.txt");

        public Form3()
        {
            InitializeComponent();
            Form3_Load();
        }

        private void Form3_Load()
        {
            DateTime time = DateTime.Now;

            timeSlots = new List<TvSlot>();
            schedule = new TvSchedule(timeSlots, FileSafe);

            int getStartHour = Convert.ToInt32(schedule.StartHour);
            int getStartMinutes = Convert.ToInt32(schedule.GetStartMinutes);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.ShowUpDown = true;



            //dateTimePicker1_ValueChanged();
            

            TimeSpan setTime = new TimeSpan(getStartHour, getStartMinutes,0);
            time = time.Date + setTime;

            dateTimePicker1.Value = time;




            listView1.Items.Clear();

            foreach (TvSlot slot in timeSlots)
            {
                listView1.Items.Add(new ListViewItem(new string[] { slot.GetName, Convert.ToString(slot.GetTime) }));

            }
         

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
         {
             

         }
       

        private void dateTimePicker1_ValueChanged()
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            schedule.StartHour = Convert.ToDouble(dateTimePicker1.Value.Hour);
            schedule.StartMinutes = Convert.ToDouble(dateTimePicker1.Value.Minute);
            schedule.SaveToFile(FileSafe);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

