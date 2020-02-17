using System;

class Tile
{
  public int XPosition { get; set; }
  public int YPosition { get; set; }

  public string Status { get; set; }

  public int DistanceFromOrigin { get; set; }

  public Tile(int x, int y, string status = "unknown")
  {
    XPosition = x;
    YPosition = y;
    Status = status;
  }
}