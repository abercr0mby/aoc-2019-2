using System;
using System.Collections.Generic;
using System.Linq;

class ArcadeCabinet
{
  public IntCodeComputer Processor { get; set; }

  public List<List<Square>> Grid { get; set; }

  public ArcadeCabinet()
  {
    Grid = new List<List<Square>>();
    Grid.Add(new List<Square>());
  }

  public void LoadProgram(long[] program)
  {
    Processor = new IntCodeComputer(program, new long[]{}, false);
  }

  public void SetUpBoard()
  {
    Processor.Compute();

    foreach(var o in Processor.Output)
    {
      Console.WriteLine(o);
    }

    foreach(var o in Processor.Output.Where((x, i) => (i % 3 == 0) && x == 0))
    {
      Console.WriteLine(o);
    }
    Console.WriteLine(Processor.Output.Count());
    Console.WriteLine(Processor.Output.Where((x, i) => i % 3 == 0).Count());

    var results = Processor.Output.Where((x, i) => (i % 3 == 0)).GroupBy(
    o => o, 
    (key, x) => new { Key = key, Count = x.Count() });

    foreach(var x in results)
    {
      Console.WriteLine(x.Key + " : " + x.Count);
    }

  }

}

class Square
{
  public string Type { get; set; }
}