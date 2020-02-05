using System;
using System.Collections.Generic;

class Reaction
{
  public Dictionary<string, Tuple<int, Reaction>> Inputs { get; set; }

  public string OutputChemical { get; set; }

  public int OutputQuantity { get; set; }

  public int Stock { get; set; }

  public Reaction(string output, int outputQuantity)
  {
    Inputs = new Dictionary<string, Tuple<int, Reaction>>();
    OutputChemical = output;
    OutputQuantity = outputQuantity;
  }

  public int React(int quantityRequired)
  {
    var ore = 0;

    var stock = Lab.GetStock(OutputChemical, quantityRequired);
    quantityRequired = quantityRequired - stock;
    if( quantityRequired < 1 )
      return 0;

    var noOfReactions = (int) Math.Ceiling((double) quantityRequired / (double) OutputQuantity);

    Lab.PlaceInStock(OutputChemical, (noOfReactions * OutputQuantity) - quantityRequired);

    foreach(var i in Inputs)
    {
      if(i.Key.Equals(Lab.ORE))
      {
        ore += i.Value.Item1 * noOfReactions;
      }
      else
      {
        ore += i.Value.Item2.React(i.Value.Item1 * noOfReactions);
      }    
    }
    return ore;
  }
}