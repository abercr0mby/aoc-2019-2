using System;
using System.Collections.Generic;

class Line
{
    public string Id { get; set; }
    public Dictionary<string, IMapPoint> AsteroidsOnLine { get; set; }

    public Line(string id)
    {
      Id = id;
      AsteroidsOnLine = new Dictionary<string, IMapPoint>();
    }

    public int DetermineVisibleAsteroids(IMapPoint asteroid)
    {
      var visibleInOneDirection = 0;
      var visibleInOtherDirection = 0;

      foreach(var a in AsteroidsOnLine)
      {
        if(visibleInOneDirection == 1 && visibleInOtherDirection == 1)
          break;

        if(asteroid.X < a.Value.X)
        {
          visibleInOneDirection = 1;
          continue;
        }

        if(asteroid.X > a.Value.X)
        {
          visibleInOtherDirection = 1;
          continue;
        }

        if(asteroid.X == a.Value.X)
        {
          if(asteroid.Y < a.Value.Y)
          {
            visibleInOneDirection = 1;
            continue;
          }
          if(asteroid.Y > a.Value.Y)
          {
            visibleInOtherDirection = 1;
            continue;
          }
        }
      }
      return visibleInOneDirection + visibleInOtherDirection;
    }

    public static string GetLineId(int pointOneX, int pointOneY, int pointTwoX, int pointTwoY)
    {
      float yIntercept;
      float xIntercept;

      float xDistance = pointOneX - pointTwoX;
      float yDistance = pointOneY - pointTwoY;
      string gradientId = xDistance == 0 ? "H" : Math.Abs(yDistance / xDistance).ToString();

      if (pointOneX == 0 && pointOneY == 0)
        return pointOneX + ":" + pointOneY + ":" + gradientId;

      if (pointTwoX == 0 && pointTwoY == 0)
        return pointTwoX + ":" + pointTwoY + ":" + gradientId;

      if (xDistance == 0)
      {
        return ":" + pointOneX + ":" + gradientId;
      }

      if (yDistance == 0)
      {
        return pointOneY + ":" + ":" + gradientId;
      }

      float gradient = yDistance / xDistance;
      yIntercept = pointOneX == 0 ? pointOneY : pointTwoX == 0 ? pointTwoY : 0;
      xIntercept = pointOneY == 0 ? pointOneX : pointTwoY == 0 ? pointTwoX : 0;

      if (yIntercept == 0)
      {
          var yValue = pointOneY != 0 ? pointOneY : pointTwoY;
          yIntercept = pointOneY - ( gradient * pointOneX );
      }

      if (xIntercept == 0)
      {
          xIntercept = ( 0 - yIntercept ) / gradient;    
      }

      return xIntercept + ":" + yIntercept + ":" + gradient;
    }

    public void AddPoint( IMapPoint point )    
    {
      try
      {
        AsteroidsOnLine.Add(point.X + ":" + point.Y, point);
        point.AddToLine(this);
      }
      catch(Exception){}
    }
}