using System;
using System.Collections.Generic;
using System.Linq;

class Roomba
{

  public IntCodeComputer Brain { get; set; }

  public Grid Grid { get; set; }

  public Tile CurrentTile { get; set; }

  public Roomba(Grid grid, int x, int y, long[] program)
  {
    Grid = grid;
    CurrentTile = Grid.GetOrCreateTileAt(x, y);
    Brain = new IntCodeComputer(program, new long[] {0}, true, false);
  }

  public int FindTileWithStatus(string status)
  {
    var distanceToTile = 0;    

    do
    {
      var neighbours = Grid.GetNeighbours(CurrentTile);      
      KeyValuePair<int, Tile> nextTile;

      if(CurrentTile.Status == status)
        distanceToTile = CurrentTile.DistanceFromOrigin;

      nextTile = neighbours.FirstOrDefault(x => x.Value.Status.Equals(Grid.Statuses[0]));

      if(nextTile.Value == null)
      {
        if(neighbours.Count(x => x.Value.Status.Equals(Grid.Statuses[1])) == 1 && CurrentTile.Status != Grid.Statuses[4])
          CurrentTile.Status = Grid.Statuses[2];

        nextTile = neighbours.FirstOrDefault(x => x.Value.Status.Equals(Grid.Statuses[1]));
      }

      if(nextTile.Value == null)
        break;

      MoveTo( nextTile );

    } while( true );

    return distanceToTile;
  }

  public void MoveTo(KeyValuePair<int, Tile> tile)
  {
    Brain.SetInputSignal(tile.Key);
    Brain.Compute();  

    var result = Brain.Output.Last();
   
    if(result == 0)
    {
      // wall
      tile.Value.Status = Grid.Statuses[3];
      return;
    }

    if(result == 2)
    {
      // destination
      tile.Value.Status = Grid.Statuses[4];
    }
    else if(result == 1)
    {
      // visited
      tile.Value.Status = Grid.Statuses[1];
    }

    if(tile.Value.DistanceFromOrigin == 0 || CurrentTile.DistanceFromOrigin + 1 < tile.Value.DistanceFromOrigin)
      tile.Value.DistanceFromOrigin = CurrentTile.DistanceFromOrigin + 1;
    
    CurrentTile = tile.Value;
  }

}