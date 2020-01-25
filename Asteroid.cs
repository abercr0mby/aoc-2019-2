using System;
using System.Collections.Generic;
using System.Linq;

class Asteroid : IMapPoint
{
  public int X { get; set; }
  public int Y { get; set; }

  public HashSet<double> Angles { get; set; }

  public double DistanceFromPoint { get; set; }

  public double AngleFromPoint { get; set; }

  public List<IMapPoint> Points { get; set; }

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
    point = AddAngleAndDistance(point);
    try{
      Angles.Add(point.AngleFromPoint);
    }catch(Exception ex){}
  }

  public IMapPoint AddAngleAndDistance(IMapPoint target)
  {
    var xDistance = X - target.X;
    var yDistance = Y - target.Y;
    target.DistanceFromPoint = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
    target.AngleFromPoint = Math.Atan2(yDistance, xDistance);

    return target;
  } 

  public void GenerateVectorsToAllOtherPoints(List<IMapPoint> points)
  {
    Points = points;
    for(var i = 0; i < Points.Count; i++)
    {
      if (Points[i].X == X && Points[i].Y == Y)
        continue;
      Points[i] = AddAngleAndDistance(Points[i]);     
    }
  }

  public IMapPoint BlastXAsteroids(int blastLimit)
  {
    var blastedCount = 0;

    // Sort List of asteroids
    var points = Points.OrderBy(p=>p.DistanceFromPoint);

    var remainingPoints = new List<IMapPoint>();

    do{
      Angles.Clear();

      // Loop until limit is reached
      foreach(var p in points)
      {
        try
        {
          Angles.Add(p.AngleFromPoint);
        } catch(Exception ex)
        {
          remainingPoints.Add(p);
          continue;
        }
        blastedCount ++;
        if(blastedCount == blastLimit)
          return p;
      }

      points = remainingPoints.OrderBy(p=>p.DistanceFromPoint);

    } while(blastedCount < Points.Count);
    return null;
  } 
}