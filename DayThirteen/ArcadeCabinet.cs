using System;
using System.Collections.Generic;
using System.Linq;

class ArcadeCabinet
{
  public IntCodeComputer Processor { get; set; }

  public List<List<Square>> Grid { get; set; }

  public int BatX;
  public int BatY;
  public int BallX;
  public int BallY;

  public int CurrentScore = 0;

  public int BlockCount = 0;  

  public ArcadeCabinet()
  {
    Grid = new List<List<Square>>();
    Grid.Add(new List<Square>());
  }

  public void LoadProgram(long[] program)
  {
    var input = new long[2];
    Processor = new IntCodeComputer(program, input, false, true);
  }

  public void SetUpBoard()
  {
    Processor.Compute();
    BuildGrid();
  }

  public void Play(bool useAi = false)
  {
    bool gameOver = false;

    do
    {
      BuildGrid();
      if(BallY > BatY || BlockCount < 1)
        gameOver = true;      
      if(useAi)
      {
        if(BatX < BallX)
          Processor.SetInputSignal(1);
        if(BatX > BallX)
          Processor.SetInputSignal(-1);
        if(BatX == BallX)
          Processor.SetInputSignal(0);
      }
      else
      {
        RenderGrid();
        var joystickInput = WaitForJoystickInput();
        Processor.SetInputSignal(joystickInput);        
      }
      Processor.Compute();
      
    } while(!gameOver);
    Console.WriteLine("GAME OVER!!!!!11");
  }

  public int WaitForJoystickInput()
  {
			var key = Console.ReadKey();
      if(key.Key == ConsoleKey.LeftArrow)
        return -1;
      if(key.Key == ConsoleKey.RightArrow)
        return 1;        
      return 0;
  }

  public void RenderGrid()
  {
    Console.WriteLine("Your current score is: " + CurrentScore + " !!!!");

    foreach(var g in Grid)
    {
      foreach(var s in g)
      {
        s.Render();
      }
      Console.WriteLine();
    }
  }

  public void BuildGrid()
  {
    BlockCount = 0;
    for(var i = 0; i < Processor.Output.Count; i += 3)
    {      
      var xPos = (int) Processor.Output[i];
      var yPos = (int) Processor.Output[i+1];
      var tileType = (int) Processor.Output[i+2];

      if(xPos == -1 && yPos == 0)
      {
        CurrentScore = tileType;
        continue;
      }

      if( xPos >= Grid[0].Count )
      {
        foreach(var g in Grid)
        {
        for(var j = 0; j <= xPos - Grid[0].Count; j++)
          g.Add(new Square());
        }  
      }

      if( yPos >= Grid.Count )
      {
        for(var j = 0; j <= yPos - Grid.Count; j++)
          Grid.Add(NewRowOfSquares(Grid[0].Count));
      }

      Grid[yPos][xPos].SetType(tileType);
      if(tileType == 2)
        BlockCount ++;
      if(tileType == 4)
      {
        BallX = xPos; 
        BallY = yPos;
      }
      if(tileType == 3)
      {
        BatX = xPos;       
        BatY = yPos;
      }
    }
  }

  public List<Square> NewRowOfSquares(int squares)
  {
    var row = new List<Square>();
    for(var i = 0; i < squares; i++)
      row.Add(new Square());

    return row;
  }

  public int CountType(int type)
  {
    return Processor.Output.Where((x, i) => (i + 1) % 3 == 0).Count(x => x == type);
  }

}

class Square
{
  public int Type { get; set; }

  public Square(int type = 0)
  {
    Type = type;
  }

  public void SetType(int type)
  {
    Type = type;
  }

  public void Render()
  {
    Console.Write(Type == 1 ? '#' : Type == 2 ? '@' : Type == 3 ? '_' : Type == 4 ? 'o' : ' ');
  }
}