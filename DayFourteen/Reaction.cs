using System;
using System.Collections.Generic;

class Reaction
{
  public Dictionary<string, int> Inputs { get; set; }

  public string OutputChemical { get; set; }

  public int OutputQuantity { get; set; }

  public Reaction(string output, int outputQuantity)
  {
    Inputs = new Dictionary<string, int>();
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
        ore += i.Value * noOfReactions;
      }
      else
      {
        var makeWith = Lab.GetReaction(i.Key);
        ore += makeWith.React(i.Value * noOfReactions);
      }    
    }
    return ore;
  }
}