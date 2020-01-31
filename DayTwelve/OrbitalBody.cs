using System;

class OrbitalBody
{
  public int XPosition;
  public int YPosition;
  public int ZPosition;

  public int XVelocity { get; set; }
  public int YVelocity { get; set; }
  public int ZVelocity { get; set; }
  public OrbitalBody()
  {
    XVelocity = 0;
    YVelocity = 0;
    ZVelocity = 0;
  }

  public void Move()
  {
    XPosition += XVelocity;
    YPosition += YVelocity;
    ZPosition += ZVelocity;
  }

  public int CalculateTotalEnergy()
  {
    var potential = Math.Abs(XPosition) + Math.Abs(YPosition) + Math.Abs(ZPosition);
    var kinetic = Math.Abs(XVelocity) + Math.Abs(YVelocity) + Math.Abs(ZVelocity);
    return potential * kinetic;
  }

  public void ApplyGravityToPair( OrbitalBody o )
  {
    if(o.XPosition > XPosition)
    {
      o.XVelocity --;
      XVelocity ++;
    }
    if(o.XPosition < XPosition)
    {
      o.XVelocity ++;
      XVelocity --;
    } 

    if(o.YPosition > YPosition)
    {
      o.YVelocity --;
      YVelocity ++;
    }
    if(o.YPosition < YPosition)
    {
      o.YVelocity ++;
      YVelocity --;
    }  

    if(o.ZPosition > ZPosition)
    {
      o.ZVelocity --;
      ZVelocity ++;
    }
    if(o.ZPosition < ZPosition)
    {
      o.ZVelocity ++;
      ZVelocity --;
    }                 
  }
}