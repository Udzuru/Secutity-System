namespace MyCalcLibTests
{
    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void Show_Graphic()
        {
            string[] should = new string[]{
                "08:00-08:30",
                "08:30-09:00",
                "09:00-09:30",
                "09:30-10:00",
                "11:30-12:00",
                "12:00-12:30",
                "12:30-13:00",
                "13:00-13:30",
                "13:30-14:00",
                "14:00-14:30",
                "14:30-15:00",
                "15:40-16:10",
                "16:10-16:40",
                "17:30-18:00"};
            int k = 0;
            SF2022User_NN_Lib.Calculations pr = new SF2022User_NN_Lib.Calculations();
            var have = pr.AvailablePeriods(new TimeSpan[] { new TimeSpan(10, 00, 0)
                               ,new TimeSpan(11,0,0)
                               ,new TimeSpan(15,0,0)
                                ,new TimeSpan(15,30,0)
                                , new TimeSpan(16,50,0)},
                               new int[] { 60, 30, 10, 10, 40 }, new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0), 30);
            for (int i = 0; i < should.Length; i++)
            {
                if (should[i] == have[i])
                {
                    k = k + 1;
                }
            }
            Assert.AreEqual(k, 14);
        }
        
    }
    [TestClass]
    public class MyTests_2
    {
        [TestMethod]
        public void Show_GraphicTest2()
        {
            string[] should = new string[]{
                "08:00-08:40",
                "08:40-09:20",
                "09:20-10:00",
                };
            int k = 0;
            SF2022User_NN_Lib.Calculations pr = new SF2022User_NN_Lib.Calculations();
            var have = pr.AvailablePeriods(new TimeSpan[] { new TimeSpan(11, 00, 0)
                               ,new TimeSpan(12,0,0)
                               ,new TimeSpan(15,0,0)
                                ,new TimeSpan(15,30,0)
                                , new TimeSpan(16,50,0)},
                               new int[] { 60, 30, 10, 10, 40 }, new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0), 40);
            for (int i = 0; i < should.Length; i++)
            {
                if (should[i] == have[i])
                {
                    k = k + 1;
                }
            }
            Assert.AreEqual(3, k);
        }
        [TestMethod]
        public void Show_GraphicTest3()
        {
            string[] should = new string[]{
                "08:00-08:30",
                "08:30-09:00",
                "09:30-10:00",
                "10:10-10:40",
                };
            int k = 0;
            SF2022User_NN_Lib.Calculations pr = new SF2022User_NN_Lib.Calculations();
            var have = pr.AvailablePeriods(new TimeSpan[] { new TimeSpan(9, 00, 0)
                               ,new TimeSpan(10,0,0)
                               ,new TimeSpan(15,0,0)
                                ,new TimeSpan(15,30,0)
                                , new TimeSpan(16,50,0)},
                               new int[] { 30, 10, 10, 10, 40 }, new TimeSpan(8, 0, 0), new TimeSpan(11, 0, 0), 30);
            for (int i = 0; i < should.Length; i++)
            {
                if (should[i] == have[i])
                {
                    k = k + 1;
                }
            }
            Assert.AreEqual(4, k);
        }
    }
}