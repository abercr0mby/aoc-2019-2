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
        var dayThirteen = new DayThirteen();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(dayThirteen.PartOne());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      } 
  
    }
  }
}


