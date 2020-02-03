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
  }

  public int CountType(int type)
  {
    return Processor.Output.Where((x, i) => (i + 1) % 3 == 0).Count(x => x == type);
  }

}

class Square
{
  public string Type { get; set; }
}