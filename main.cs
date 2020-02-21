using System;

namespace aoc_2019
{
  class MainClass
  {
    static void Main(string[] args)
    {
      var previousDays = new PreviousDays();
      previousDays.Run();

      try
      {
        var daySixteen = new DaySixteen();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(daySixteen.PartOne());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      } 

      try
      {
        var daySixteen = new DaySixteen();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(daySixteen.PartTwo());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }      

    }
  }
}


