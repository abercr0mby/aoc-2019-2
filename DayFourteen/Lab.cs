using System;
using System.Collections.Generic;
using System.Linq;

class Lab
{
  public static Dictionary<string, Reaction> LabBook { get; set; }

  public static Dictionary<string, int> Stock { get; set; }

  public const string ORE = "ORE";
  private const string FUEL = "FUEL";

  public static int OreQuantity = 0;

  static Lab()
  {
    LabBook = new Dictionary<string, Reaction>();
    Stock = new Dictionary<string, int>();
  }

  public static void Reset()
  {
    LabBook.Clear();
    Stock.Clear();
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

  public static int GetStock(string chemicalName, int required)
  {
    var stock = 0;
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

  public static void PlaceInStock(string chemicalName, int spare)
  {
    var stock = 0;
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

  public static int MakeChemical(string chemical, int quantityRequired)
  {
    if ( chemical.Equals(ORE) )
    {
      OreQuantity += quantityRequired;
    }

    var chemicalReaction = GetReaction(FUEL);
    var totalOre = chemicalReaction.React(quantityRequired);

    if(Stock.Values.Count(s => s > 0) == 0)
      throw new Exception("Holy SHIT!!!!!");

    foreach(var s in Stock)
    {
      Console.WriteLine(s.Key + " : " + s.Value);
    }

    return totalOre;
  }
}