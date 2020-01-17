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

    public static string GetLineId(int pointOneX, int pointOneY, int pointTwoX, int pointTwoY)
    {
      var xDistance = Math.Abs(pointOneX - pointTwoX);
      var yDistance = Math.Abs(pointOneY - pointTwoY);

      if(xDistance == 0)
      {
        return ":" + pointOneX;
      }

      if(yDistance == 0)
      {
        return pointOneY + ":";
      }

      float gradient = yDistance / xDistance;
      float yIntercept = pointOneX == 0 ? pointOneY : pointOneX == 0 ? pointOneY : pointOneY - ( gradient * pointOneX );
      float xIntercept = pointOneY == 0 ? pointOneX : pointTwoY == 0 ? pointTwoX : ( 0 - yIntercept ) / gradient;

      return xIntercept + ":" + yIntercept;
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