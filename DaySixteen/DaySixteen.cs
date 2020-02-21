using System;
using System.Linq;

class DaySixteen
{
  private int[] Output { get; set; }

  private string Input { get; set; } = "59718730609456731351293131043954182702121108074562978243742884161871544398977055503320958653307507508966449714414337735187580549358362555889812919496045724040642138706110661041990885362374435198119936583163910712480088609327792784217885605021161016819501165393890652993818130542242768441596060007838133531024988331598293657823801146846652173678159937295632636340994166521987674402071483406418370292035144241585262551324299766286455164775266890428904814988362921594953203336562273760946178800473700853809323954113201123479775212494228741821718730597221148998454224256326346654873824296052279974200167736410629219931381311353792034748731880630444730593";

  public DaySixteen()
  {    
  }

  public string BuildMegaInput(string input)
  {
    var megaString = "";
    for(var i = 0; i < 1000; i++)
    {
      megaString += input;
    }
    return megaString;
  }

  public string PartTwo()
  {
    RunTestsPartTwo();
    return "mouse";
  }

  public string RunTestsPartTwo()
  {

    var input = BuildMegaInput("03036732577212944063491565474664");

    var fft = new Fft();    
    var result = fft.CleanUpWithOffSet(input, 100, 7);
    if(!result.Equals("84462026"))
    {
      Console.WriteLine("Part two test one FAILED was: " +  result + ". Should have been: 84462026");
    } 
    return "";
  }

  public string RunTestsPartOne()
  {
    var fft = new Fft();
    var result = fft.CleanUp("12345678", 1);
    if(!result.Equals("48226158"))
    {
      Console.WriteLine("test one FAILED was: " +  result + ". Should have been: 48226158");
    }

    fft = new Fft();
    result = fft.CleanUp("80871224585914546619083218645595", 100);
    if(!result.Equals("24176176"))
    {
      Console.WriteLine("test two FAILED was: " +  result + ". Should have been: 24176176");
    }
    return "";
  }

  public string PartOne()
  {
    RunTestsPartTwo();
    var fft = new Fft();
    return fft.CleanUp(Input, 100);
  }
}