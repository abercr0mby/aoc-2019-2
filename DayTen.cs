using System;
class DayTen
{

  public int RunTestsAndGetResultPartOne() 
  {
    RunTestsPartOne();
    return 0;
  }

  public void RunTestsPartOne () 
  {
/*
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
    //throw new System.Exception(maxDetectable + " should be 33");
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
    //throw new System.Exception(maxDetectable + " should be 35");
  }
  else
  {
    Console.WriteLine("Day ten test two passed");
  }
  */

    var map = new AsteroidMap(
@".#..#
.....
#####
....#
...##"
);

    var maxDetectable = map.GetMaxDetectable();
    if(maxDetectable != 8)
    {
      throw new System.Exception(maxDetectable + " should be 8");
    }
    else
    {
      Console.WriteLine("Day ten test zero passed");
    }

  }
}
