using System;
using System.Linq;

class Fft
{

  private int[] BasePattern { get; set; }

  public Fft()
  {
    BasePattern = new int[] {0, 1, 0, -1};
  }

  public string CleanUp(string inputString, int iterations)
  {
    //int[] input = inputString.Select(i => Int32.TryParse(i, out x));
    int[] input = Array.ConvertAll(inputString.ToCharArray(), s => int.Parse(s.ToString()));
    var output = new int[input.Length];

    for(int x = 0; x < iterations; x++)
    {
      for(int i = 0; i < output.Length; i++)
      {
        for(int j = 0; j < BasePattern.Length; j++)
        {
          for(int k = 0; k <= i; k++)
          {
            if(j == 0 && k == 0)
              continue;

            var inputIndex = ( i * BasePattern.Length ) + k ;
            if(inputIndex >= input.Length)
              break;

            input[inputIndex] = (input[inputIndex] * BasePattern[j]);
            
          }
        }
        output[i] = input.Sum() % 10;
      }
      input = output;
    }

    return string.Join("", output.Take(8));

  } 




}