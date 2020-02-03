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

  public Dictionary<string, long> XLog { get; set; }
  public Dictionary<string, long> YLog { get; set; }
  public Dictionary<string, long> ZLog { get; set; }

  public List<int[]> Pairings { get; set; }

  public long XRepeatStep { get; set; }
  public long YRepeatStep { get; set; }
  public long ZRepeatStep { get; set; }

  public DayTwelvePartTwo(string systemData)
  {
      OrbitalBodies = new List<OrbitalBody>();
      Pairings = new List<int[]>();

      CreateBodiesFromData(systemData);

      XLog = new Dictionary<string, long>();
      YLog = new Dictionary<string, long>();
      ZLog = new Dictionary<string, long>();

      var xKey = "";
      var yKey = "";
      var zKey = "";

      for(var i = 0; i < OrbitalBodies.Count; i++)
      {
        xKey = xKey + OrbitalBodies[i].XPosition.ToString() + ":" + OrbitalBodies[i].XVelocity.ToString() + ":";
        yKey = yKey + OrbitalBodies[i].YPosition.ToString() + ":" + OrbitalBodies[i].YVelocity.ToString() + ":";
        zKey = zKey + OrbitalBodies[i].ZPosition.ToString() + ":" + OrbitalBodies[i].ZVelocity.ToString() + ":";
      }

      XLog.Add(xKey, 0);
      YLog.Add(yKey, 0);
      ZLog.Add(zKey, 0);              

      XPositions = new int[OrbitalBodies.Count];
      YPositions = new int[OrbitalBodies.Count];
      ZPositions = new int[OrbitalBodies.Count];
      XVelocities = new int[OrbitalBodies.Count];
      YVelocities = new int[OrbitalBodies.Count];
      ZVelocities = new int[OrbitalBodies.Count];

      for(var i = 0; i < XPositions.Length; i++)
      {
          for(var j = i+1; j < XPositions.Length; j++)
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

  public long FindRepeat()
  {
    var count = 0;

    do
    {
      count++;

      ApplyGravity();
      MoveCheckAndLog(count);
      if(XRepeatStep > 0 && YRepeatStep > 0 && ZRepeatStep > 0)
      {
        return CalculateOveralRepeatStep();
      }

    }while( true );
  }


  public void PerformSteps(long steps)
  {
    for(long i = 0; i < steps; i++)
    {
      ApplyGravity();
      MoveCheckAndLog(i);
      if(XRepeatStep > 0 && YRepeatStep > 0 && ZRepeatStep > 0)
      {
        CalculateOveralRepeatStep();
      }
    }
  }

  public long CalculateOveralRepeatStep()
  {
    return DetermineLcm(DetermineLcm(XRepeatStep, YRepeatStep), ZRepeatStep);
  }

  public void MoveCheckAndLog(long step)
  {
    var xRepeat = true;
    var yRepeat = true;
    var zRepeat = true;

    var xKey = "";
    var yKey = "";
    var zKey = "";

    for(int i = 0; i < XPositions.Length; i++)
    {
      if(XRepeatStep == 0)
      {
        XPositions[i] += XVelocities[i];
        xKey += XPositions[i].ToString() + ":" + XVelocities[i].ToString() + ":";
      }

      if(YRepeatStep == 0)
      {
        YPositions[i] += YVelocities[i];
        yKey += YPositions[i].ToString() + ":" + YVelocities[i].ToString() + ":";
      }
      
      if(ZRepeatStep == 0)
      {
        ZPositions[i] += ZVelocities[i];
        zKey += ZPositions[i].ToString() + ":" + ZVelocities[i].ToString() + ":";
      }
    }

    if(XRepeatStep == 0)
    {
      if(!XLog.ContainsKey(xKey))
      {
        XLog.Add(xKey, step);
      }
      else
      {
        XRepeatStep = step;
      }
    }

    if(YRepeatStep == 0)
    {
      if(!YLog.ContainsKey(yKey))
      {
        YLog.Add(yKey, step);
      }
      else
      {
        YRepeatStep = step;
      }
    }

    if(ZRepeatStep == 0)
    {
      if(!ZLog.ContainsKey(zKey))
      {
        ZLog.Add(zKey, step);
      }
      else
      {
        ZRepeatStep = step;
      }
    }        

  }

  public void ApplyGravity()
  {
    for(var i = 0; i < Pairings.Count; i++)
    {
      if (XPositions[Pairings[i][0]] > XPositions[Pairings[i][1]])
      {
        XVelocities[Pairings[i][0]] --;
        XVelocities[Pairings[i][1]] ++;
      }
      else if (XPositions[Pairings[i][0]] < XPositions[Pairings[i][1]])
      {
        XVelocities[Pairings[i][0]] ++;
        XVelocities[Pairings[i][1]] --;
      }

      if (YPositions[Pairings[i][0]] > YPositions[Pairings[i][1]])
      {
        YVelocities[Pairings[i][0]] --;
        YVelocities[Pairings[i][1]] ++;
      }
      else if (YPositions[Pairings[i][0]] < YPositions[Pairings[i][1]])
      {
        YVelocities[Pairings[i][0]] ++;
        YVelocities[Pairings[i][1]] --;
      }  

      if (ZPositions[Pairings[i][0]] > ZPositions[Pairings[i][1]])
      {
        ZVelocities[Pairings[i][0]] --;
        ZVelocities[Pairings[i][1]] ++;
      }
      else if (ZPositions[Pairings[i][0]] < ZPositions[Pairings[i][1]])
      {
        ZVelocities[Pairings[i][0]] ++;
        ZVelocities[Pairings[i][1]] --;
      }               
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

    public static long DetermineLcm(long a, long b)
    {
        long num1, num2;
        if (a > b)
        {
            num1 = a; num2 = b;
        }
        else
        {
            num1 = b; num2 = a;
        }

        for (int i = 1; i < num2; i++)
        {
            if ((num1 * i) % num2 == 0)
            {
                return i * num1;
            }
        }
        return num1 * num2;
    }  


}