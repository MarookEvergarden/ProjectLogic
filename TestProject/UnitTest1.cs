using BusinessLogic;
using System.Reflection;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private List<TvSlot> timeSlots;
        private TvSchedule schedule;


        [TestInitialize]
        public void TestInit()
        {
            var CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var FileSafe = System.IO.Path.Combine(CurrentDirectory, @"Schedule.txt");
            timeSlots = new List<TvSlot>();
           /* {
               *//* new TvSlot("Dexter", 140), // 9:00 - 11:20
                new TvSlot("Picky Blinders", 200), // 11:20 - 14:40
                new TvSlot("F1", 120) // 14:40 - 16:40*//*
            };*/
            schedule = new TvSchedule(timeSlots, FileSafe);
        }

        [TestMethod]
        public void TestSaveToFile()
        {
            var CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var FileSafe = System.IO.Path.Combine(CurrentDirectory, @"Schedule.txt");
            //String FileSafe = @"\repos\ProjectLogic\TestProject\bin\Debug\net6.0\Schedule.txt";
            //var ExampleSafe = @"C:\Users\marko\source\repos\ProjectLogic\TestProject\ScheduleExamplae.txt";

            //schedule.SaveToFile(FileSafe);
            // Compare ScheduleExample.txt with ScheduleFile.txt, they should be exactly the same
            //Assert.IsTrue(schedule.FileCompare(FileSafe, ExampleSafe));
            schedule.ReadScheduleFromFile(FileSafe, timeSlots);
            Assert.AreEqual(9, schedule.StartHour);
        }

        [TestMethod]
        public void TestShowStartTime()
        {
            TvSlot slot;

            slot = schedule.FindShow(14, 41);
            Assert.IsNotNull(slot);
            Assert.AreEqual("Life", slot.GetName);



            /* slot = schedule.FindShow(8, 55);
             Assert.IsNull(slot);

             slot = schedule.FindShow(9, 0);

             Assert.AreEqual("Dexter", slot.GetName);

             slot = schedule.FindShow(11, 21);
             Assert.IsNotNull(slot);
             Assert.AreEqual("Picky Blinders", slot.GetName);

             slot = schedule.FindShow(14, 41);
             Assert.IsNotNull(slot);
             Assert.AreEqual("F1", slot.GetName);

             slot = schedule.FindShow(16, 41);
             Assert.IsNull(slot);*/
        }



    }
}