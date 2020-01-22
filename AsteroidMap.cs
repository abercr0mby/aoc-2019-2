using System;
using System.Collections.Generic;
using System.Linq;

class AsteroidMap
{
  public List<IMapPoint> Asteroids;
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
          Asteroids.Add(new Asteroid(j, i));
      }
    }

    GenerateLines();

    foreach(var l in Lines.Values)
    {
      // Console.WriteLine(l.Id);
/*        foreach(var a in l.AsteroidsOnLine.Values)
      {
        Console.WriteLine(a.X + " -- " + a.Y);
      }  */
    }

     Asteroids.Sort((a, b) => a.X.CompareTo(b.X));

    foreach(var a in Asteroids)
    {      
      Console.WriteLine(a.X + ":" + a.Y + " = " + a.VisiblePoints);
/*       if(true && a.X == 5 && a.Y == 8)
      { 
        Console.WriteLine(Asteroids.Count);
        Console.WriteLine(a.X + ":" + a.Y + " = " + a.VisiblePoints);
        Console.WriteLine(a.X + ":" + a.Y + " = " + a.OnLines.Count);       
        var totalFromLines = a.OnLines.Values.Sum(l => l.AsteroidsOnLine.Count);
        Console.WriteLine(a.X + ":" + a.Y + " = " + totalFromLines);       
        var sortedLines = a.OnLines.Values.ToList();
        sortedLines.Sort((i1, i2) => i1.Id.CompareTo(i2.Id));
        foreach(var l in sortedLines)
        {
          Console.WriteLine(l.Id + " -- " + l.AsteroidsOnLine.Count);
           foreach(var ast in l.AsteroidsOnLine)
            Console.Write(ast.Key + " ; ");
          Console.WriteLine(""); 
        }
      }  */
    }
  }

  public int GetMaxDetectable()
  {
    return Asteroids.Max(a => a.VisiblePoints);
  }

  public void GenerateLines()
  {
    for(var i = 0; i < Asteroids.Count; i++)
    {
      for(var j = i + 1; j < Asteroids.Count; j++)
      {
        var line = GetLineAndAddTwoPoints(Asteroids[i], Asteroids[j]);
      }
    }

    for(var i = 0; i < Asteroids.Count; i++)
    {
      Asteroids[i].DetermineVisiblePoints();
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