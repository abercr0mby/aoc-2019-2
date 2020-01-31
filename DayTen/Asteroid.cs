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
    }catch(Exception){}
  }

  public IMapPoint AddAngleAndDistance(IMapPoint target)
  {
    var xDistance = Math.Abs(X - target.X);
    var yDistance = Math.Abs(Y - target.Y);
    target.DistanceFromPoint = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
    var rawAngle = (180 / Math.PI) * Math.Atan2(yDistance, xDistance);
    
    if (xDistance == 0)
    {
      if ( target.Y < Y )
        rawAngle = 0;
      if ( target.Y > Y )
        rawAngle = 180;
    }
    else if (yDistance == 0)
    {
      if ( target.X > X )
        rawAngle = 90;
      if ( target.X < X )
        rawAngle = 270;      
    }
    else if ( target.X > X )
    {
      if ( target.Y < Y )
        rawAngle = 90 - rawAngle;      
      if ( target.Y > Y )
        rawAngle = (90 - rawAngle) + 90;
    }
    else
    {
      if ( target.Y < Y )
        rawAngle = (rawAngle) + 270;
      if ( target.Y > Y )
        rawAngle = (90 - rawAngle) + 180;
    }

    target.AngleFromPoint = rawAngle;

    return target;
  } 

  public void GenerateVectorsToAllOtherPoints(List<IMapPoint> points)
  {
    Points = new List<IMapPoint>();
    for(var i = 0; i < points.Count; i++)
    {
      if (points[i].X == X && points[i].Y == Y)
        continue;
      Points.Add(AddAngleAndDistance(points[i]));     
    }
  }

  public IMapPoint BlastXAsteroids(int blastLimit)
  {
    var blastedCount = 0;

    var count = 0;

    // Sort List of asteroids
    var points = Points.OrderBy(p => p.AngleFromPoint).ThenBy(p=>p.DistanceFromPoint);

    foreach(var p in points)
    {
      count++;
      Console.WriteLine(count + " .. " + p.X + ":" + p.Y + " - " + p.AngleFromPoint + " - " + p.DistanceFromPoint);
    }

    var remainingPoints = new List<IMapPoint>();

    do{
      Angles.Clear();
      remainingPoints.Clear();
      Console.WriteLine(blastedCount);
      // Loop until limit is reached
      foreach(var p in points)
      {
        if( !Angles.Add(p.AngleFromPoint) )
        {
          remainingPoints.Add(p);
          continue;
        }
        blastedCount ++;
        Console.WriteLine("Blasted asteroid no " + blastedCount + ": " + p.X + ":" + p.Y + " - " + p.AngleFromPoint + " / " + p.DistanceFromPoint);
        if(blastedCount == blastLimit)
          return p;
      }

      points = remainingPoints.OrderBy(p => p.AngleFromPoint).ThenBy(p=>p.DistanceFromPoint);

    } while(blastedCount < Points.Count);
    return null;
  } 
}