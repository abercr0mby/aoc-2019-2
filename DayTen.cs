using System;
class DayTen
{

  public int RunTestsAndGetResultPartOne() 
  {
    RunTestsPartOne();
var map = new AsteroidMap(
@".###.###.###.#####.#
#####.##.###..###..#
.#...####.###.######
######.###.####.####
#####..###..########
#.##.###########.#.#
##.###.######..#.#.#
.#.##.###.#.####.###
##..#.#.##.#########
###.#######.###..##.
###.###.##.##..####.
.##.####.##########.
#######.##.###.#####
#####.##..####.#####
##.#.#####.##.#.#..#
###########.#######.
#.##..#####.#####..#
#####..#####.###.###
####.#.############.
####.#.#.##########."
);

  return map.GetMaxDetectable();
  }

  public void RunTestsPartOne () 
  {

var map = new AsteroidMap(
@"......#.#.
#..#.#....
..#######.
.#.#.###..
.#..#.....
..#....#.#
#..#....#.
.##.#..###
##...#..#.
.#....####"
);

  var maxDetectable = map.GetMaxDetectable();
  if(maxDetectable != 33)
  {
    throw new System.Exception(maxDetectable + " should be 33");
  }
  else
  {
    Console.WriteLine("Day ten test one passed");
  }

   map = new AsteroidMap(
@"#.#...#.#.
.###....#.
.#....#...
##.#.#.#.#
....#.#.#.
.##..###.#
..#...##..
..##....##
......#...
.####.###."
);

  maxDetectable = map.GetMaxDetectable();
  if(maxDetectable != 35)
  {
    throw new System.Exception(maxDetectable + " should be 35");
  }
  else
  {
    Console.WriteLine("Day ten test two passed");
  }

    map = new AsteroidMap(
@".#..#
.....
#####
....#
...##"
);

    maxDetectable = map.GetMaxDetectable();
    if(maxDetectable != 8)
    {
      throw new System.Exception(maxDetectable + " should be 8");
    }
    else
    {
      Console.WriteLine("Day ten test zero passed");
    }

    map = new AsteroidMap(
@".#..#..###
####.###.#
....###.#.
..###.##.#
##.##.#.#.
....###..#
..#.#..#.#
#..#.#.###
.##...##.#
.....#.#.."
);

    maxDetectable = map.GetMaxDetectable();
    if(maxDetectable != 41)
    {
      throw new System.Exception(maxDetectable + " should be 41");
    }
    else
    {
      Console.WriteLine("Day ten test three passed");
    }

    map = new AsteroidMap(
@".#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##"
);

    maxDetectable = map.GetMaxDetectable();
    if(maxDetectable != 210)
    {
      throw new System.Exception(maxDetectable + " should be 210");
    }
    else
    {
      Console.WriteLine("Day ten test four passed");
    }

  }
}
