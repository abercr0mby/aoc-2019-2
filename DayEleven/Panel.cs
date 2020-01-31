using System;

class Panel
{
  public int X { get; set; }
  public int Y { get; set; }

  public bool Painted { get; set; }
  public int Colour { get; set; }

  public Panel(int x, int y, int colour)
  {
    X = x;
    Y = y;
    Colour = colour;
    Painted = false;
  }

  public void Paint(int colour)
  {
    Painted = true;
    Colour = colour;
  }
}