using System;

class DayFourteen
{
  public int PartOne()
  {
    RunTestsPartOne();
    return 0;
  }

  public void RunTestsPartOne()
  {
    var observations = @"10 ORE => 10 A
1 ORE => 1 B
7 A, 1 B => 1 C
7 A, 1 C => 1 D
7 A, 1 D => 1 E
7 A, 1 E => 1 FUEL";

    Lab.RecordReactionsInLabBook(observations);
    var ore = Lab.MakeChemical("FUEL", 1);
    if(ore == 31)
    {
      Console.WriteLine("Day 14 part one test one passed");
    }
    else
    {
      throw new Exception("Failed day 14 part one test one. Should have been 31 was " + ore);
    }
  }
}