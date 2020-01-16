using System;

namespace aoc_2019
{
  class MainClass
  {
    static void Main(string[] args)
    {
  /*  try{
      var dayOne = new DayOne();
      Console.WriteLine(dayOne.RunTestsAndGetResultPartOne());
      Console.WriteLine(dayOne.RunTestsAndGetResultPartTwo());
    }
    catch(Exception ex){
      Console.WriteLine(ex.Message);
    } 
  */
      
      try{
        var dayTwo = new DayTwo();
        Console.WriteLine(dayTwo.RunTestsAndGetResultPartOne());
        // Console.WriteLine(dayTwo.GetResultPartTwo());
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }
           

      /*
      try{
        var dayThree = new DayThree();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(dayThree.RunTestsAndGetResultPartOne());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }

      try{
        var dayThree = new DayThree();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(dayThree.RunTestsAndGetResultPartTwo());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }
      */
      
      /* 
      try{
        var dayFour = new DayFour();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(dayFour.RunTestsAndGetResultPartOne());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      } 
      */  



       try{
        var dayFive = new DayFive();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        dayFive.RunTestsAndShowResultPartOne();
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }

      try{
        var dayFive = new DayFive();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        dayFive.RunTestsAndShowResultPartTwo();
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }
    

      /*
      try{
        var daySix = new DaySix();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(daySix.RunTestsAndGetResultPartOne());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }

      try{
        var daySix = new DaySix();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(daySix.RunTestsAndGetResultPartTwo());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }
      */
     
     
      try{
        var daySeven = new DaySeven();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(daySeven.RunTestsAndGetResultPartOne());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }
      
      try{
        var daySeven = new DaySeven();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(daySeven.RunTestsAndGetResultPartTwo());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }
      

      /*
      try{
        var dayEight = new DayEight();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(dayEight.RunTestsAndGetResultPartOne());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }

      try{
        var dayEight = new DayEight();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(dayEight.RunTestsAndGetResultPartTwo());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }
      */


      try{
        var dayNine = new DayNine();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine(dayNine.RunTestsAndGetResultPartOne());
        watch.Stop();
        Console.WriteLine("Time:" + watch.ElapsedMilliseconds);
      }
      catch(Exception ex){
        Console.WriteLine(ex.Message);
      }


    }
  }
}


