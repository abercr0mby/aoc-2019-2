using System;
using System.Collections.Generic;
using System.Linq;

class AsteroidMap
{
  public List<IMapPoint> Asteroids;

  public AsteroidMap(string mapData)
  {
    Asteroids = new List<IMapPoint>();

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

    GenerateLosVectors();
  }

  public IMapPoint BlastXAsteroids(int x, int y, int blastLimit)
  {
    var laserStation = (Asteroid) Asteroids.FirstOrDefault(a => a.X == x && a.Y == y);
    laserStation.GenerateVectorsToAllOtherPoints(Asteroids);
    return laserStation.BlastXAsteroids(blastLimit);
  }

  public int GetMaxDetectable()
  {
    return Asteroids.Max(a => a.Angles.Count);
  }

  public void GenerateLosVectors()
  {
    for(var i = 0; i < Asteroids.Count; i++)
    {
      for(var j = 0; j < Asteroids.Count; j++)
      {
        if ( i == j )
          continue;
        Asteroids[i].GenerateLosVectorTo(Asteroids[j]);
      }
    }
  }  
}