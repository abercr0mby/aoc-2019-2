using System;
using System.Collections.Generic;

class Asteroid : IMapPoint
{
  public int X { get; set; }
  public int Y { get; set; }

  public HashSet<double> Angles { get; set; }

  public double DistanceFromPoint { get; set; }

  public double AngleFromPoint { get; set; }

  public Asteroid(int x, int y)
  {
    X = x;
    Y = y;
    Angles = new HashSet<double>();
  }

  public void GenerateLosVectorTo(IMapPoint point)
  {
    var xDistance = X - point.X;
    var yDistance = Y - point.Y;
    point.DistanceFromPoint = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
    point.AngleFromPoint = Math.Atan2(yDistance, xDistance);
    try{
      Angles.Add(point.AngleFromPoint);
    }catch(Exception ex){}
  }
}