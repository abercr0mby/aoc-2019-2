using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class OrbitalMap 
{
  public Planet com { get; set; }

  public Dictionary<string, Planet> AllPlanets;

  public int totalOrbits = 0;

  public string MapFile { get; set; }

  public OrbitalMap(string mapFile)
  {
    AllPlanets = new Dictionary<string, Planet>();
    MapFile = mapFile;

    com = new Planet("COM");
    AllPlanets.Add(com.Name, com);
    PopulateMapFromFile();
    totalOrbits = com.CalculateDistances( totalOrbits );
  }

  public void PopulateMapFromFile()
  {
    String line;
    try 
    {
      //Pass the file path and file Name to the StreamReader constructor
      StreamReader sr = new StreamReader(MapFile);   

      //Continue to read until you reach end of file
      while (!sr.EndOfStream) 
      {
        line = sr.ReadLine();
        var components = line.Split(')');
        var orbittedName = components[0];
        Planet orbittedPlanet;

        var orbitingName = components[1];
        Planet orbitingPlanet;

        AllPlanets.TryGetValue(orbittedName, out orbittedPlanet);
        if (orbittedPlanet == null)
        {
          orbittedPlanet = new Planet(orbittedName);
          AllPlanets.Add(orbittedPlanet.Name, orbittedPlanet);
        }

        AllPlanets.TryGetValue(orbitingName, out orbitingPlanet);
        if (orbitingPlanet == null)
        {
          orbitingPlanet = new Planet(orbitingName);
          AllPlanets.Add(orbitingPlanet.Name, orbitingPlanet);
        }

        orbittedPlanet.AddOrbitedBy(orbitingPlanet);
      }

      //close the file
      sr.Close();
    }
    catch(Exception e)
    {
      Console.WriteLine("Exception: " + e.Message);
    }
      finally 
    {
      Console.WriteLine("Executing finally block.");
    }
  }

  public int GetOrbitalTransfersBetween(string pointOneName, string pointTwoName)
  {
    Planet pointOnePlanet;
    Planet pointTwoPlanet;
    Planet comPlanet;

    AllPlanets.TryGetValue(pointOneName, out pointOnePlanet);
    AllPlanets.TryGetValue(pointTwoName, out pointTwoPlanet);
    AllPlanets.TryGetValue("COM", out comPlanet);

    var pathOne = pointOnePlanet.GetPathTo(comPlanet);
    var pathTwo = pointTwoPlanet.GetPathTo(comPlanet);

    var crossOverPlanet = GetCrossOverPlanet(pathOne, pathTwo);
    return (pointOnePlanet.InOrbitAround.totalOrbiting - crossOverPlanet.totalOrbiting)
      + (pointTwoPlanet.InOrbitAround.totalOrbiting - crossOverPlanet.totalOrbiting);
  }

  private Planet GetCrossOverPlanet(
    Dictionary<string, Planet> pathOne,
    Dictionary<string, Planet> pathTwo)
  {
    var crossOvers = new List<Planet>();
    foreach(var p1 in pathOne)
    {
      if(pathTwo.ContainsKey(p1.Key))
      {
        crossOvers.Add(p1.Value);
      }
    }

    crossOvers.OrderBy(p => p.totalOrbiting);
    return crossOvers.FirstOrDefault();
  }
}


class Planet
{
  public string Name { get; set; }

  public List<Planet> OrbitedBy { get; set; }

  public Planet InOrbitAround { get; set; }

  public int directlyOrbiting { get; set; } = 0;

  public int totalOrbiting { get; set; } = 0;

  public Planet(string Name)
  {
    OrbitedBy = new List<Planet>();
    this.Name = Name;
  }

  public Dictionary<string, Planet> GetPathTo(Planet destination)
  {
    var path = new Dictionary<string, Planet>();
    path.Add(this.Name, this);
    if (this == destination)
    {
      return path;
    }
  
    var subPath = InOrbitAround.GetPathTo(destination);
    foreach(var p in subPath)
    {
      path.Add(p.Key, p.Value);
    }
    return path;
  }

  public int CalculateDistances(int total)
  {
    total = totalOrbiting = InOrbitAround == null ? 0 : InOrbitAround.totalOrbiting + 1;
    directlyOrbiting = InOrbitAround == null ? 0 : 1;

    foreach(var planet in OrbitedBy)
    {
      total += planet.CalculateDistances(total);
    }

    return total;
  }

  public void SetInOrbit(Planet inOrbitAround)
  {
    InOrbitAround = inOrbitAround;
  }

  public void AddOrbitedBy(Planet orbitedBy)
  {
    OrbitedBy.Add(orbitedBy);
    orbitedBy.SetInOrbit(this);
  }
}