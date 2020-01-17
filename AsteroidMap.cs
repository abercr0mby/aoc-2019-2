using System;
using System.Collections.Generic;

class AsteroidMap
{
  private List<IMapPoint> Asteroids;
  private Dictionary<string, Line> Lines;

  public AsteroidMap(string mapData)
  {
    Asteroids = new List<IMapPoint>();
    Lines = new Dictionary<string, Line>();

    var rows = mapData.Split(
      new[] { "\r\n", "\r", "\n" },
      StringSplitOptions.None
    );    

    for(var i =0; i < rows.Length; i++)
    {
      for(var j =0; j < rows[i].Length; j++)    
      {
        if(rows[i][j] == '#')
          Asteroids.Add(new Asteroid(i, j));
      }
    }

    GenerateLines();

    foreach(var a in Asteroids)
    {      
      Console.WriteLine(a.X + ":" + a.Y + " = " + a.OnLines.Count);
    }
  }

  public void GenerateLines()
  {
    for(var i = 0; i < Asteroids.Count; i++)
    {
      for(var j = i; j < Asteroids.Count; j++)
      {
        var line = GetLineAndAddTwoPoints(Asteroids[i], Asteroids[j]);
      }
    }
  }

    public Line GetLineAndAddTwoPoints(IMapPoint pointOne, IMapPoint pointTwo)
    {
      var lineId = Line.GetLineId(pointOne.X, pointOne.Y, pointTwo.X, pointTwo.Y);

      Line line = null;
      Lines.TryGetValue(lineId, out line);
      if (line == null)
      {
        line = new Line(lineId);
        Lines.Add(lineId, line);
      }

      line.AddPoint(pointOne);
      line.AddPoint(pointTwo);

      return line;
    }  

}