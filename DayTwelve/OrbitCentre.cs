using System;
using System.Collections.Generic;

class OrbitCentre
{
  public List<OrbitalBody> OrbitalBodies { get; set; }

  public OrbitCentre(string systemData)
  {
    OrbitalBodies = new List<OrbitalBody>();
    CreateBodiesFromData(systemData);
  }

  public void SetTheWorldInMotion(long steps)
  {
    for (var i = 0; i < steps; i++)
    {
      ApplyGravity();
      MoveBodies();
    }
  }

  public int CalculateTotalEnergy()
  {
    var totalEnergy = 0;

    foreach(var o in OrbitalBodies)
    {
      totalEnergy += o.CalculateTotalEnergy();
    }
    return totalEnergy;
  }

  public void MoveBodies()
  {
    foreach(var o in OrbitalBodies)
    {        
      o.Move();
    }
  }

  public void ApplyGravity()
  {
    foreach(var o in OrbitalBodies)
    {        
      for(var i = OrbitalBodies.IndexOf(o); i < OrbitalBodies.Count; i++)
      {
        o.ApplyGravityToPair(OrbitalBodies[i]);
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
}