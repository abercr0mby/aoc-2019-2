using System;
using System.Linq;

class DayTwelve
{

  public long PartTwo()
  {

    RunTestsPartTwo();

    var systemData = @"<x=-3, y=15, z=-11>
<x=3, y=13, z=-19>
<x=-13, y=18, z=-2>
<x=6, y=0, z=-1>";

  var partTwo = new DayTwelvePartTwo(systemData);
  var result = partTwo.FindRepeat();  

  Console.WriteLine("steps doned: " + result);

    return result;
  }

  public void RunTestsPartTwo()
  {
    var systemData = @"<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>";

  var partTwo = new DayTwelvePartTwo(systemData);
  var result = partTwo.FindRepeat();  
  if(result == 2772)
  {
    Console.WriteLine("Passed day twelve part two test one");
  }
  else
  {
    throw new System.Exception("Failed. Should ahve been 2272 was " + result);
  }

    systemData = @"<x=-8, y=-10, z=0>
<x=5, y=5, z=10>
<x=2, y=-7, z=3>
<x=9, y=-8, z=-3>";

  partTwo = new DayTwelvePartTwo(systemData);
  result = partTwo.FindRepeat();  
  if(result == 4686774924)
  {
    Console.WriteLine("Passed day twelve part two test two");
  }
  else
  {
    throw new System.Exception("Failed. Should have been 4686774924 was " + result);
  }
  }

  public int RunTestsAndGetResultPartOne() 
  {
    RunTestsPartOne(); 

    var systemData = @"<x=-3, y=15, z=-11>
<x=3, y=13, z=-19>
<x=-13, y=18, z=-2>
<x=6, y=0, z=-1>";
    var centre = new OrbitCentre(systemData);
    centre.SetTheWorldInMotion(1000);
    return 0;
    //return centre.CalculateTotalEnergy();    
  }

  public void RunTestsPartOne()
  {
    var systemData = @"<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>";
    var centre = new OrbitCentre(systemData);
    centre.SetTheWorldInMotion(10);
    var result = centre.CalculateTotalEnergy();
    if ( result != 179 )
    {
      throw new Exception("Total energy should be 179. It is " + result);
    }
    else
    {
      Console.WriteLine("Total Energy: " + result);
    }

    systemData = @"<x=-8, y=-10, z=0>
<x=5, y=5, z=10>
<x=2, y=-7, z=3>
<x=9, y=-8, z=-3>";
    centre = new OrbitCentre(systemData);
    centre.SetTheWorldInMotion(100);
    result = centre.CalculateTotalEnergy();
    if ( result != 1940 )
    {
      throw new Exception("Total energy should be 1940. It is " + result);
    }
    else
    {
      Console.WriteLine("Total Energy: " + result);
    }
    
  }
}