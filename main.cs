using System;

namespace aoc_2019
{
  class MainClass
  {
    static void Main(string[] args)
    {
      var previousDays = new PreviousDays();
      previousDays.Run();

      try{
        var dayEleven = new DayEleven();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(dayEleven.RunTestsAndGetResultPartOne());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }   
    }
  }
}


