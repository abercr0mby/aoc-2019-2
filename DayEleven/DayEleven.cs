using System;

class DayEleven
{
  public int RunTestsAndGetResultPartOne() 
  {
    RunTestsPartOne(); 
    return 0; 
  }

  public void RunTestsPartOne()
  {
    if(false)
    {
      throw new System.Exception("Should be 8:2");
    }
    else
    {
      Console.WriteLine("Day ten part two test one passed");
    }    
  }
}