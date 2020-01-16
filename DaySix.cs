using System;

class DaySix 
{
  public int RunTestsAndGetResultPartOne() 
  {
    RunTestsPartOne();
    var map = new OrbitalMap("OrbitalData.txt");
    return map.totalOrbits;
  }

  public int RunTestsAndGetResultPartTwo() 
  {
    RunTestsPartTwo();
    var map = new OrbitalMap("OrbitalData.txt");
    return map.GetOrbitalTransfersBetween("YOU", "SAN");
  }

  public void RunTestsPartOne () 
  {
    var map = new OrbitalMap("OrbitalDataTestOne.txt");
    if(map.totalOrbits != 42) 
    {
      throw new System.Exception(map.totalOrbits + " should  be 42");
    }
  } 

  public void RunTestsPartTwo () 
  {
    var map = new OrbitalMap("OrbitalDataTestTwo.txt");
    var minPath = map.GetOrbitalTransfersBetween("YOU", "SAN");
    if(minPath != 4) 
    {
      throw new System.Exception(minPath + " should  be 4");
    }
  }    
}