using System;
using System.Collections.Generic;
using System.Linq;

class Surface
{
  public long[] Program = new long[] {3,8,1005,8,326,1106,0,11,0,0,0,104,1,104,0,3,8,1002,8,-1,10,101,1,10,10,4,10,108,0,8,10,4,10,101,0,8,28,2,1104,14,10,3,8,102,-1,8,10,101,1,10,10,4,10,1008,8,1,10,4,10,101,0,8,55,3,8,102,-1,8,10,101,1,10,10,4,10,1008,8,1,10,4,10,1001,8,0,77,2,103,7,10,3,8,102,-1,8,10,101,1,10,10,4,10,108,0,8,10,4,10,102,1,8,102,1006,0,76,1,6,5,10,1,1107,3,10,3,8,1002,8,-1,10,1001,10,1,10,4,10,108,1,8,10,4,10,1001,8,0,135,1,1002,8,10,2,1101,3,10,1006,0,97,1,101,0,10,3,8,1002,8,-1,10,101,1,10,10,4,10,108,1,8,10,4,10,101,0,8,172,1006,0,77,1006,0,11,3,8,102,-1,8,10,101,1,10,10,4,10,1008,8,0,10,4,10,102,1,8,201,1006,0,95,3,8,102,-1,8,10,101,1,10,10,4,10,1008,8,1,10,4,10,1002,8,1,226,2,3,16,10,1,6,4,10,1006,0,23,1006,0,96,3,8,1002,8,-1,10,1001,10,1,10,4,10,108,0,8,10,4,10,1001,8,0,261,1,3,6,10,2,1006,3,10,1006,0,78,3,8,102,-1,8,10,101,1,10,10,4,10,1008,8,0,10,4,10,101,0,8,295,1006,0,89,1,108,12,10,2,103,11,10,101,1,9,9,1007,9,1057,10,1005,10,15,99,109,648,104,0,104,1,21102,1,838365918100,1,21102,343,1,0,1106,0,447,21102,387365315476,1,1,21102,354,1,0,1106,0,447,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,21101,0,179318254811,1,21102,401,1,0,1106,0,447,21102,1,97911876839,1,21101,0,412,0,1106,0,447,3,10,104,0,104,0,3,10,104,0,104,0,21101,838345577320,0,1,21101,435,0,0,1106,0,447,21102,1,838337188628,1,21101,0,446,0,1105,1,447,99,109,2,21202,-1,1,1,21101,40,0,2,21102,478,1,3,21101,0,468,0,1106,0,511,109,-2,2106,0,0,0,1,0,0,1,109,2,3,10,204,-1,1001,473,474,489,4,0,1001,473,1,473,108,4,473,10,1006,10,505,1102,1,0,473,109,-2,2106,0,0,0,109,4,2102,1,-1,510,1207,-3,0,10,1006,10,528,21101,0,0,-3,21202,-3,1,1,22101,0,-2,2,21101,1,0,3,21102,1,547,0,1106,0,552,109,-4,2106,0,0,109,5,1207,-3,1,10,1006,10,575,2207,-4,-2,10,1006,10,575,22102,1,-4,-4,1105,1,643,22102,1,-4,1,21201,-3,-1,2,21202,-2,2,3,21101,0,594,0,1105,1,552,21201,1,0,-4,21101,0,1,-1,2207,-4,-2,10,1006,10,613,21101,0,0,-1,22202,-2,-1,-2,2107,0,-3,10,1006,10,635,22102,1,-1,1,21101,635,0,0,106,0,510,21202,-2,-1,-2,22201,-4,-2,-4,109,-5,2106,0,0};

  public Dictionary<string, Panel> Panels { get; set; }

  public int StartX { get; set; }
  public int EndX { get; set; }
  public int StartY { get; set; }
  public int EndY { get; set; }


  public Robot Robot { get; set; }

  public Surface(int width, int height)
  {
    Panels = new Dictionary<string, Panel>();

    for(var i=0; i < width; i++)
    {
      for(var j=0; j < height; j++)
      {
        Panels.Add(i + ":" + j, new Panel(i, j, 0));
      }
    }
    StartX = 0;
    StartY = 0;
    EndX = width - 1;
    EndY = height - 1;
  }

  public void AddRobot()
  {
    Panels["0:0"].Colour = 1;
    Robot = new Robot(this, Panels["0:0"], Program);
  }

  public void MakeRobotPaint()
  {
    Robot.Paint();
  }

  public int GetPaintedCount()
  {
    return Panels.Values.Count(p => p.Painted == true);
  }

  public Panel MoveToNewPanel(int x, int y)
  {
    var key = x + ":" + y;
    Panel panel = null;

    if(x < StartX || x > EndX)
    {
      for(var i = StartY; i <= EndY; i++)
      {
        Panels.Add(x + ":" + i, new Panel(x, i, 0));
      }
      StartX = x < StartX ? x : StartX;
      EndX = x > EndX ? x : EndX;       
    }

    if(y < StartY || y > EndY)
    {
      for(var i = StartX; i <= EndX; i++)
      {
        Panels.Add(i + ":" + y, new Panel(i, y, 0));
      }
      StartY = y < StartY ? y : StartY;
      EndY = y > EndY ? y : EndY;
    }

    if (!Panels.TryGetValue(key, out panel))
      throw new System.Exception("There should be a panel but there isnae!");

    return Panels[key];
  }

  public void RenderHull()
  {
    var currentRow = Panels.Values.Min(p=> p.Y);
    var panels = Panels.Values.OrderByDescending(p=> p.Y).ThenBy(p=>p.X);

    for (var i = 0; i <= EndX; i++)
      Console.Write(". ");

    Console.Write(Environment.NewLine);

    foreach(var p in panels)
    {
      if(p.Y != currentRow)
      {
        currentRow = p.Y;
        Console.Write(Environment.NewLine);
      }

      var pixel = p.Colour == 1 ? '#' : '.';
      Console.Write(pixel + " ");      
    }
  }



}