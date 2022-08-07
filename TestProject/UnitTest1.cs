/*using BusinessLogic;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestShowEndTime()
        {
            List<TvSlot> timeSlots = new List<TvSlot>()
            {
                new TvSlot("Dexter",140),
                new TvSlot("Picky Blinders",200 ),
                new TvSlot("F1", 120)
            };
            TvSchedule schedule = new TvSchedule (timeSlots, 9, 0);
            TvSlot slot = schedule.FindShow(13, 20);
            //Assert.IsNotNull(show);
            Assert.AreEqual("Picky Blinders", slot.GetName);            
        }

    }
}*/
using BusinessLogic;

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
            timeSlots = new List<TvSlot>()
            {
                new TvSlot("Dexter", 140), // 9:00 - 11:20
                new TvSlot("Picky Blinders", 200), // 11:20 - 14:40
                new TvSlot("F1", 120) // 14:40 - 16:40
            };
            schedule = new TvSchedule(timeSlots, 9, 0);
        }

        [TestMethod]
        public void TestShowStartTime()
        {
            TvSlot slot;

            slot = schedule.FindShow(8, 55);
            Assert.IsNull(slot);

            slot = schedule.FindShow(9, 0);
            Assert.IsNotNull(slot);
            Assert.AreEqual("Dexter", slot.GetName);

            slot = schedule.FindShow(11, 21);
            Assert.IsNotNull(slot);
            Assert.AreEqual("Picky Blinders", slot.GetName);

            slot = schedule.FindShow(14, 41);
            Assert.IsNotNull(slot);
            Assert.AreEqual("F1", slot.GetName);

            slot = schedule.FindShow(16, 41);
            Assert.IsNull(slot);
        }


        [TestMethod]
        public void TestSaveToFile()
        {
            schedule.SaveToFile(@"C:\Users\marko\OneDrive\Documents\Мої документи\Shcedule.txt");
            // Compare ScheduleExample.txt with ScheduleFile.txt, they should be exactly the same
        }
    }
}