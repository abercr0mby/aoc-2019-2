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
        var dayTen = new DayTen();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(dayTen.RunTestsAndGetResultPartOne());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }

    }
  }
}


