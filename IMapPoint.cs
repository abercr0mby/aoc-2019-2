using System;
using System.Collections.Generic;

interface IMapPoint
{
  int X { get; set; }
  int Y { get; set; }

  Dictionary<string, Line> OnLines { get; set; }

  void AddToLine(Line line);   
}