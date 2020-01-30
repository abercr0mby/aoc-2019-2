using System;
using System.Collections.Generic;

interface IMapPoint
{
  int X { get; set; }
  int Y { get; set; }

  HashSet<double> Angles { get; set; }

  double DistanceFromPoint { get; set; }

  double AngleFromPoint { get; set; }

  List<IMapPoint> Points {get; set;}

  void GenerateVectorsToAllOtherPoints(List<IMapPoint> points);

  void GenerateLosVectorTo(IMapPoint point);
}