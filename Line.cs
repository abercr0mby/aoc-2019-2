using System;
using System.Collections.Generic;

class Line
{
    public string Id { get; set; }
    private Dictionary<string, IMapPoint> AsteroidsOnLine { get; set; }

    public Line(string id)
    {
      Id = id;
      AsteroidsOnLine = new Dictionary<string, IMapPoint>();
    }

    public static string GetLineId(int pointOneX, int pointOneY, int pointTwoX, int pointTwoY)
    {
      var xDistance = pointOneX - pointTwoX;
      var yDistance = pointOneY - pointTwoY;

      var gradient = xDistance == 0 ? 1 : yDistance == 0 ? 0 : yDistance / xDistance;
      var yIntercept = gradient == 1 ? pointOneY : pointOneY - ( gradient * pointOneX );
      var xIntercept = gradient == 0 ? pointOneX : ( 0 - yIntercept ) / gradient;

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