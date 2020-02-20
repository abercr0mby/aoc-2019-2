using System;
using System.Collections.Generic;
using System.Linq;

class Grid
{
  public static string[] Statuses { get; set; } = new string[] {"unknown", "visited", "fully-explored", "wall", "o2"};

  public Dictionary<Tuple<int, int>, Tile> Tiles { get; set; }

  public Roomba Roomba { get; set; }

  public Grid()
  {
    Tiles = new Dictionary<Tuple<int, int>, Tile>();
  }


  public int ProgressOxygen(Tile start)
  {
    var maxDepth = 0;
    start.Status = Statuses[4];

    var tiles = GetNeighbours(start).Where(t => t.Value.Status != Statuses[3] && t.Value.Status != Statuses[4]).ToList();

    if(tiles.Count == 0)
    {
      return 1;
    }

    foreach(var tile in tiles)
    {
      var depth = ProgressOxygen(tile.Value) + 1;
      if(depth > maxDepth)
        maxDepth = depth;
    }
    return maxDepth;
  }

  public int GetFurthestTileFromRoombaStart()
  {
    return Tiles.Max(t => t.Value.DistanceFromOrigin);
  }

  public Tile GetO2Supply()
  {
    return Tiles.FirstOrDefault(t => t.Value.Status == Statuses[4]).Value;
  }


  public Roomba AddRoomba(int x, int y, long[] program)
  {
    Roomba = new Roomba(this, x, y, program);
    return Roomba;
  }

  public Tile GetOrCreateTileAt(int x, int y)
  {
    Tile tile;
    Tiles.TryGetValue(Tuple.Create(x, y), out tile);
    if(tile == null)
    {
      tile = new Tile(x, y);
      Tiles.Add(Tuple.Create(x, y), tile);
    }
    return tile;
  }

  public Dictionary<int, Tile> GetNeighbours(Tile tile)
  {
    var neighbours = new Dictionary<int, Tile>();
    Tile neighbour;

    //North
    neighbour = GetOrCreateTileAt(tile.XPosition, tile.YPosition + 1);
    neighbours.Add(1, neighbour);

    //South
    neighbour = GetOrCreateTileAt(tile.XPosition, tile.YPosition - 1);
    neighbours.Add(2, neighbour);

    //East
    neighbour = GetOrCreateTileAt(tile.XPosition - 1, tile.YPosition);
    neighbours.Add(4, neighbour);

    //West
    neighbour = GetOrCreateTileAt(tile.XPosition + 1, tile.YPosition);
    neighbours.Add(3, neighbour);

    return neighbours;
  }

  public void Render()
  {
  var xStart = Tiles.Min(t => t.Key.Item1);  
  var xEnd = Tiles.Max(t => t.Key.Item1);
  var yStart = Tiles.Min(t => t.Key.Item2);
  var yEnd = Tiles.Max(t => t.Key.Item2);
  var pixel = ' ';

  for(var i = yStart; i <= yEnd; i++)
  {
    for(var j = xStart; j <= xEnd; j++)
    {
      Tile t;
      Tiles.TryGetValue(Tuple.Create(j,i), out t);
      if(t == null)
      {
        pixel = '?';
      }
      else if(t.XPosition == 0 && t.YPosition == 0)
      {
        pixel = '+';
      }
      else
      {
        pixel =  t.Status == Statuses[0] ? '?' : t.Status == Statuses[1] ? 'V' : t.Status == Statuses[2] ? ' ' : t.Status == Statuses[3] ? '#' : 'O';      
      }
      Console.Write(" " + pixel + " ");      
    }
    Console.WriteLine();
  }
  Console.WriteLine();
  Console.WriteLine();

  }
}