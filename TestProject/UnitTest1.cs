using BusinessLogic;

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
}