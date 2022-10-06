using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form4 : Form
    {
        private List<TvSlot> timeSlots;
        private TvSchedule schedule;

        private static string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        private readonly string FileSafe = System.IO.Path.Combine(CurrentDirectory, @"Schedule.txt");

        public Form4()
        {
            InitializeComponent();
            Form4Load();
        }
        private void Form4Load() 
        {
            timeSlots = new List<TvSlot>(); 
            schedule = new TvSchedule(timeSlots, FileSafe);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timeSlots.Add( new TvSlot() { SetName = textBox1.Text, SetTime = Convert.ToDouble(textBox2.Text), SetPath = FileSafe });
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
