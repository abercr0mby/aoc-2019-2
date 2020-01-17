using System;
using System.Collections.Generic;

class Asteroid : IMapPoint
{
  public int X { get; set; }
  public int Y { get; set; }

  public Dictionary<string, Line> OnLines { get; set; }

  public Asteroid(int x, int y)
  {
    X = x;
    Y = y;
    OnLines = new Dictionary<string, Line>();
  }

  public void AddToLine(Line line)
  {
    try
    {
      OnLines.Add(line.Id, line);
    } catch(Exception){}
  }  
}