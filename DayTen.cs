using System;
class DayTen
{

  public int RunTestsAndGetResultPartTwo() 
  {
    RunTestsPartTwo();
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
    var lastBlasted = map.BlastXAsteroids(11, 13, 200);
    return (lastBlasted.X * 100) + lastBlasted.Y;
  }

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

  public void RunTestsPartTwo () 
  {

var map = new AsteroidMap(
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

  var lastBlasted = map.BlastXAsteroids(11, 13, 199);

  if(lastBlasted.X != 9 || lastBlasted.Y != 6)
  {
    throw new System.Exception(lastBlasted.X + ":" + lastBlasted.Y + " - " + lastBlasted.AngleFromPoint + " should be 8:2");
  }
  else
  {
    Console.WriteLine("Day ten part two test one passed");
  }

  lastBlasted = map.BlastXAsteroids(11, 13, 200);

  if(lastBlasted.X != 8 || lastBlasted.Y != 2)
  {
    throw new System.Exception(lastBlasted.X + ":" + lastBlasted.Y + " - " + lastBlasted.AngleFromPoint + " should be 8:2");
  }
  else
  {
    Console.WriteLine("Day ten part two test two passed");
  }  

  lastBlasted = map.BlastXAsteroids(11, 13, 201);

  if(lastBlasted.X != 10 || lastBlasted.Y != 9)
  {
    throw new System.Exception(lastBlasted.X + ":" + lastBlasted.Y + " - " + lastBlasted.AngleFromPoint + " should be 8:2");
  }
  else
  {
    Console.WriteLine("Day ten part two test three passed");
  }
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
