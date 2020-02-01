using System;
using System.Collections.Generic;

class DayTwelvePartTwo
{
  public List<OrbitalBody> OrbitalBodies { get; set; }

  public int[] XPositions { get; set; }

  public int[] YPositions { get; set; }

  public int[] ZPositions { get; set; }

  public int[] XVelocities { get; set; }

  public int[] YVelocities { get; set; }

  public int[] ZVelocities { get; set; }

  public List<int[]> Pairings { get; set; }

  public DayTwelvePartTwo(string systemData)
  {
      OrbitalBodies = new List<OrbitalBody>();
      Pairings = new List<int[]>();

      CreateBodiesFromData(systemData);

      XPositions = new int[OrbitalBodies.Count];
      YPositions = new int[OrbitalBodies.Count];
      ZPositions = new int[OrbitalBodies.Count];
      XVelocities = new int[OrbitalBodies.Count];
      YVelocities = new int[OrbitalBodies.Count];
      ZVelocities = new int[OrbitalBodies.Count];

      for(var i = 0; i < XVelocities.Length; i++)
      {
          for(var j = i+1; j < XVelocities.Length; j++)
          {
              Pairings.Add(new int[] {i, j});
          }
      }

      for(var i = 0; i < OrbitalBodies.Count; i++)
      {
        XPositions[i] = OrbitalBodies[i].XPosition;
        YPositions[i] = OrbitalBodies[i].YPosition;
        ZPositions[i] = OrbitalBodies[i].ZPosition;
      }

      Console.WriteLine(Pairings.Count);
      foreach(var p in Pairings)
      {
        Console.WriteLine(p[0] + " : " + p[1]);
      }
  }

  public void PerformSteps(long steps)
  {
    for(long i = 0; i < steps; i++)
    {
      PerformStep();
    }
  }

  public void PerformStep()
  {
    for(var i = 0; i < Pairings.Count; i++)
    {
      if (XPositions[Pairings[i][0]] > XPositions[Pairings[i][1]])
      {
        XPositions[Pairings[i][0]] --;
        XPositions[Pairings[i][1]] ++;
      }/*
      else if (XPositions[Pairings[i][0]] < XPositions[Pairings[i][1]])
      {
        XPositions[Pairings[i][0]] ++;
        XPositions[Pairings[i][1]] --;
      }

      if (YPositions[Pairings[i][0]] > YPositions[Pairings[i][1]])
      {
        YPositions[Pairings[i][0]] --;
        YPositions[Pairings[i][1]] ++;
      }
      else if (YPositions[Pairings[i][0]] < YPositions[Pairings[i][1]])
      {
        YPositions[Pairings[i][0]] ++;
        YPositions[Pairings[i][1]] --;
      }  

      if (ZPositions[Pairings[i][0]] > ZPositions[Pairings[i][1]])
      {
        ZPositions[Pairings[i][0]] --;
        ZPositions[Pairings[i][1]] ++;
      }
      else if (ZPositions[Pairings[i][0]] < ZPositions[Pairings[i][1]])
      {
        ZPositions[Pairings[i][0]] ++;
        ZPositions[Pairings[i][1]] --;
      }*/                
     } 
  }

  public void CreateBodiesFromData(string systemData)
  {
    var rawBodyDatas = systemData.Split(Environment.NewLine);

    foreach(var b in rawBodyDatas)
    {
      var body = new OrbitalBody();
      var bodyDatas = b.Trim(new char[] {'<', '>'}).Split(',');

      foreach(var d in bodyDatas)
      {
        var positionalData = d.Trim().Split('=');
        if (positionalData[0].Equals("x"))
          Int32.TryParse(positionalData[1], out body.XPosition);
        if (positionalData[0].Equals("y"))
          Int32.TryParse(positionalData[1], out body.YPosition);
        if (positionalData[0].Equals("z"))
          Int32.TryParse(positionalData[1], out body.ZPosition);
      }

      OrbitalBodies.Add(body);
    }
  }


}