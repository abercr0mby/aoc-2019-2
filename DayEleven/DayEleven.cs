using System;
using System.Linq;

class DayEleven
{
  public int RunTestsAndGetResultPartOne() 
  {
    RunTestsPartOne(); 
    return 0; 
  }

  public void RunTestsPartOne()
  {
    var surface = new Surface(10, 10);
    surface.AddRobot();
    surface.MakeRobotPaint();
    var paintedCount = surface.GetPaintedCount();
    surface.RenderHull();

    Console.WriteLine("Damn, surface had " + surface.Panels.Count() + " panels");
    Console.WriteLine("Day eleven, dat robot painted " + paintedCount + " panels");

  }
}