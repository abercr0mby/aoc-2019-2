using System;
using System.Collections.Generic;
using System.Linq;

class Robot
{
  private Surface Surface { get; set; }

  private IntCodeComputer Brain { get; set; }

  public Panel CurrentPanel { get; set; }

  private LinkedList<char> Directions = new LinkedList<char>( new char[] {'u', 'r', 'd', 'l'} );

  // u, d, l, r
  public LinkedListNode<char> Facing { get; set; }

  public List<Panel> Path { get; set; }

  public Robot(Surface surface, Panel startingPanel, long[] program)
  {    
    Surface = surface;
    Path = new List<Panel>();
    Path.Add(startingPanel);
    CurrentPanel = startingPanel;
    Brain = new IntCodeComputer(program, new long[] {CurrentPanel.Colour, CurrentPanel.Colour});
    Path = new List<Panel>();
    Facing = Directions.Find('u');
    Console.WriteLine(CurrentPanel.Colour);
  }

  public void Paint()
  {
    do
    {      
      Brain.SetInputSignal(CurrentPanel.Colour);
      Brain.Compute();
      PaintCurrentPanel((int) Brain.Output.Last());
      Brain.Compute();
      TurnAndMove((int) Brain.Output.Last());

    }while(!Brain.Halted);
  }

  public void PaintCurrentPanel(int colour)
  {    
    CurrentPanel.Paint(colour);
  }

  public void TurnAndMove(int direction)
  {
    if (! new int[] {0,1}.Contains(direction))
      throw new System.Exception("Illegal direction");

    Turn(direction);
    MoveForward();
  }

  public void MoveForward()
  {
    var currentX = CurrentPanel.X;
    var currentY = CurrentPanel.Y;

    if ( Facing.Value == 'u' )    
    {
      currentY ++;
      //Console.WriteLine("moving up to " + currentX + " : " + currentY);
    }
    if ( Facing.Value == 'd' )    
    {
      currentY --; 
      //Console.WriteLine("moving down to " + currentX + " : " + currentY);
    }
    if ( Facing.Value == 'r' )     
    {
      currentX ++;
      //Console.WriteLine("moving right to " + currentX + " : " + currentY);
    }
    if ( Facing.Value == 'l' )    
    {
      currentX --;
      //Console.WriteLine("moving left to " + currentX + " : " + currentY);
    }

    CurrentPanel = Surface.MoveToNewPanel(currentX, currentY);
  }

  public void Turn(int direction)
  {
    if (direction == 1)
    {
      Facing = Facing.Next ?? Facing.List.First;
      //Console.WriteLine("turning right to face " + Facing.Value);
    }
    else
    {
      Facing = Facing.Previous ?? Facing.List.Last;
      //Console.WriteLine("turning left to face " + Facing.Value);
    }
  }

}