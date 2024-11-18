SF2022User_NN_Lib.Calculations pr = new SF2022User_NN_Lib.Calculations();
var have = pr.AvailablePeriods(new TimeSpan[] { new TimeSpan(11, 00, 0)
                               ,new TimeSpan(12,0,0)
                               ,new TimeSpan(15,0,0)
                                ,new TimeSpan(15,30,0)
                                , new TimeSpan(16,50,0)},
                              new int[] { 60, 30, 10, 10, 40 }, new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0), 40);
foreach (string p in have)
{
    Console.WriteLine(p);
}