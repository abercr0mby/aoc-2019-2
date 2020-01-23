using System;
using System.Collections.Generic;

interface IMapPoint
{
  int X { get; set; }
  int Y { get; set; }

  HashSet<double> Angles { get; set; }

  double DistanceFromPoint { get; set; }

  double AngleFromPoint { get; set; }

  void GenerateLosVectorTo(IMapPoint point);
}