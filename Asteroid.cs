using System;
using System.Collections.Generic;

class Asteroid : IMapPoint
{
  public int X { get; set; }
  public int Y { get; set; }

  public int VisiblePoints { get; set; }

  public Dictionary<string, Line> OnLines { get; set; }

  public HashSet<double> Angles { get; set; }

  public Asteroid(int x, int y)
  {
    X = x;
    Y = y;
    OnLines = new Dictionary<string, Line>();
    Angles = new HashSet<double>();
  }

  public void AddToLine(Line line)
  {
    try
    {
      OnLines.Add(line.Id, line);
    } catch(Exception){}
  }  

  public void DetermineVisiblePoints()
  {
    foreach(var l in OnLines)
    {
      VisiblePoints += l.Value.DetermineVisibleAsteroids(this);
    }
  }

  public void GenerateLosVectorTo(IMapPoint point)
  {
    var xDistance = X - point.X;
    var yDistance = Y - point.Y;
    try{
      Angles.Add(Math.Atan2(yDistance, xDistance));
    }catch(Exception ex){}

  }
}