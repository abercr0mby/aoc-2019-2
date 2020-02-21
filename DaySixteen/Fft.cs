using System;
using System.Linq;

class Fft
{

  private int[] BasePattern { get; set; }

  public Fft()
  {
    BasePattern = new int[] {0, 1, 0, -1};
  }

  public string CleanUpWithOffSet(string inputString, int iterations, int offset)
  {
    var skipIt = Int32.Parse(string.Join("", inputString.Take(offset)));
    var result = CleanUp(inputString, iterations);

    return result.Skip(skipIt).Take(8).ToString();
  }

  public string CleanUp(string inputString, int iterations)
  {
    //int[] input = inputString.Select(i => Int32.TryParse(i, out x));
    int[] input = Array.ConvertAll(inputString.ToCharArray(), s => int.Parse(s.ToString()));
    var output = new int[input.Length];

    var newInput = new int[input.Length];

    for(int x = 0; x < iterations; x++)
    {
      for(int i = 0; i < output.Length; i++)
      {
        var inputIndex = -1;
        do
        {
          for(int j = 0; j < BasePattern.Length; j++)
          {
            for(int k = 0; k <= i; k++)
            {
              if(inputIndex == -1)
              {
                inputIndex ++;
                continue;
              }

              newInput[inputIndex] = (input[inputIndex] * BasePattern[j]);
              inputIndex ++;

              if(inputIndex >= input.Length)
                break;            
            }
            if(inputIndex >= input.Length)
              break;           
          }
          if(inputIndex >= input.Length)
            break;           
        }
        while(true);

        output[i] = Math.Abs(newInput.Sum() % 10);
      }
      input = output;
    }    

    return string.Join("", output.Take(8));

  } 




}