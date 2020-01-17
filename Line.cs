using System;

class Line
{
    private XAxisIntercept int[2] { get; set; };
    private YAxisIntercept int[2] { get; set; };
    private List<Asteroid> Asteroids { get; set; }

    public Line(int[2] xAxisIntercept, int[2] yAxisIntercept)
    {
      XAxisIntercept = xAxisIntercept;
      YAxisIntercept = yAxisIntercept;
      Asteroids = new List<Asteroids>();
    }
}