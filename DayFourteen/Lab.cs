using System;
using System.Collections.Generic;
using System.Linq;

class Lab
{
  public static Dictionary<string, Reaction> LabBook { get; set; }

  public static Dictionary<string, long> Stock { get; set; }

  public const string ORE = "ORE";
  public const string FUEL = "FUEL";

  public static long OreQuantity = 0;

  static Lab()
  {
    LabBook = new Dictionary<string, Reaction>();
    Stock = new Dictionary<string, long>();
  }

  public static void Reset()
  {
    LabBook.Clear();
    Stock.Clear();
  }

  public static long MakeMostFuelWith(long availableOre)
  {
    long batchSize = 100000000000;
    do
    {
      batchSize ++;
      long oreUsed = MakeChemical(FUEL, batchSize);
      Console.WriteLine(batchSize + " : " + oreUsed);
      if(oreUsed > availableOre)
        return batchSize - 1;
    }while (true);
  }

  public static void RecordReactionsInLabBook(string observations)
  {
    var reactionDatas = observations.Split(Environment.NewLine);
    foreach(var r in reactionDatas)
    {
      var components = r.Split("=>");
      var outputData = components[1].Trim().Split(' ');
      var outputQuantity = 0;
      Int32.TryParse(outputData[0], out outputQuantity);
      var reaction = new Reaction(outputData[1], outputQuantity);

      var inputDatas = components[0].Split(',');
      foreach(var i in inputDatas)
      {
        var inputs = i.Trim().Split(' ');
        var inputQuantity = 0;
        Int32.TryParse(inputs[0], out inputQuantity);
        reaction.Inputs.Add(inputs[1], Tuple.Create<int, Reaction>(inputQuantity, null));
      }
      LabBook.Add(outputData[1], reaction);
    }

    foreach(var l in LabBook)
    {
      var stagedInputs = new Dictionary<string, Tuple<int, Reaction>>();
      foreach(var i in l.Value.Inputs)
      {
        stagedInputs.Add(i.Key, Tuple.Create<int, Reaction>(i.Value.Item1, GetReaction(i.Key)));
      }
      l.Value.Inputs = stagedInputs;
    }
  }

  public static long GetStock(string chemicalName, long required)
  {
    long stock = 0;
    if(Stock.TryGetValue(chemicalName, out stock))
    {
      if(stock <= required)
      {
        Stock[chemicalName] = 0;
      }
      else
      {
        Stock[chemicalName] = stock - required;
      }

    }
    return stock;
  }

  public static void PlaceInStock(string chemicalName, long spare)
  {
    long stock = 0;
    if(Stock.TryGetValue(chemicalName, out stock))
    {
      Stock[chemicalName] = stock + spare;
    }
    else
    {
      Stock.Add(chemicalName, spare);
    }
  }

  public static Reaction GetReaction(string chemicalName)
  {
    Reaction chemicalReaction;

    LabBook.TryGetValue(chemicalName, out chemicalReaction);
    return chemicalReaction;
  }

  public static long MakeChemical(string chemical, long quantityRequired)
  {
    var chemicalReaction = GetReaction(chemical);
    var totalOre = chemicalReaction.React(quantityRequired);

    return totalOre;
  }
}