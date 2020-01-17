using System;
using System.Collections.Generic;

class Line
{
    private int[] XAxisIntercept { get; set; }
    private int[] YAxisIntercept { get; set; }
    private List<Asteroid> Asteroids { get; set; }

    public Line(int[] xAxisIntercept, int[] yAxisIntercept)
    {
      XAxisIntercept = xAxisIntercept;
      YAxisIntercept = yAxisIntercept;
      Asteroids = new List<Asteroid>();
    }
}