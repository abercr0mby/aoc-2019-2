using System;

class DaySixteen
{
  private int[] Output { get; set; }

  public DaySixteen()
  {    
  }

  public string RunTests()
  {
    var fft = new Fft();
    var result = fft.CleanUp("80871224585914546619083218645595", 100);
    if(!result.Equals("24176176"))
    {
      Console.WriteLine("test one FAILED was: " +  result + ". Should have been: 24176176");
    }
    return "";
  }

  public string PartOne()
  {
    return RunTests();
  }
}