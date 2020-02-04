using System;
using System.Collections.Generic;

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
        reaction.Inputs.Add(inputs[1], inputQuantity);
      }
      LabBook.Add(outputData[1], reaction);
    }
  }

  public static int GetStock(string checmicalName, int required)
  {
    var stock = 0;
    if(Stock.TryGetValue(checmicalName, out stock))
    {
      if(stock <= required)
      {
        Stock[checmicalName] = 0;
      }
      else
      {
        Stock[checmicalName] = stock - required;
      }

    }
    return stock;
  }

  public static void PlaceInStock(string checmicalName, int spare)
  {
    var stock = 0;
    if(Stock.TryGetValue(checmicalName, out stock))
    {
      Stock[checmicalName] = stock + spare;
    }
    else
    {
      Stock.Add(checmicalName, spare);
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
    return chemicalReaction.React(quantityRequired);
  }
}