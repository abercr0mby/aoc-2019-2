using System;

class DayTwo {

  public long[] mainInput = new long[] {1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,19,9,23,1,23,6,27,1,9,27,31,1,31,10,35,2,13,35,39,1,39,10,43,1,43,9,47,1,47,13,51,1,51,13,55,2,55,6,59,1,59,5,63,2,10,63,67,1,67,9,71,1,71,13,75,1,6,75,79,1,10,79,83,2,9,83,87,1,87,5,91,2,91,9,95,1,6,95,99,1,99,5,103,2,103,10,107,1,107,6,111,2,9,111,115,2,9,115,119,2,13,119,123,1,123,9,127,1,5,127,131,1,131,2,135,1,135,6,0,99,2,0,14,0};

  public long RunTestsAndGetResultPartOne () {
    RunTestsPartOne();
    var computer = new IntCodeComputer((long[]) mainInput.Clone(), null, false, true);
    computer.Compute();
    return computer.Program[0];
  }

  public long GetResultPartTwo () {
    for ( var i = 0; i < 100; i++ ) {
      for ( var j = 0; j < 100; j++ ) {
        long[] workingCopy = (long[]) mainInput.Clone();
        workingCopy[1] = i;
        workingCopy[2] = j;
        var computer = new IntCodeComputer(workingCopy, null);
        computer.Compute();
        if(computer.Program[0] == 19690720) {
          return ( computer.Program[1] * 100 ) + computer.Program[2];
        }
      }
    }
    return 0;
  }

  public void RunTestsPartOne () {
    var computer = new IntCodeComputer(new long[] {1,9,10,3,2,3,11,0,99,30,40,50}, null, false, true);
    computer.Compute();
    if(computer.Program[0] != 3500) {
      throw new System.Exception(computer.Program[0] + " should be: 3500");
    }
    else
    {
      Console.WriteLine("Day Two Test One Passed");
    }    

    computer = new IntCodeComputer(new long[] {1,0,0,0,99}, null, false, true);
    computer.Compute();
    if(computer.Program[0] != 2) {
      Console.WriteLine(computer.Program[0]);
      throw new System.Exception();
    } 
    else
    {
      Console.WriteLine("Day Two Test Two Passed");
    }    

    computer = new IntCodeComputer(new long[] {2,3,0,3,99}, null, false, true);
    computer.Compute();
    if(computer.Program[3] != 6) {
      Console.WriteLine(computer.Program[3]);
      throw new System.Exception();
    }    
    else
    {
      Console.WriteLine("Day Two Test Three Passed");
    }

    computer = new IntCodeComputer(new long[] {2,4,4,5,99,0}, null, false, true);
    computer.Compute();
    if(computer.Program[5] != 9801) {
      Console.WriteLine(computer.Program[5]);
      throw new System.Exception();
    }
    else
    {
      Console.WriteLine("Day Two Test Four Passed");
    }    

    computer = new IntCodeComputer( new long[] {1,1,1,4,99,5,6,0,99},null, false, true);
    computer.Compute();
    if(computer.Program[0] != 30 && computer.Program[4] != 2) {
      Console.WriteLine(computer.Program[0]);
      throw new System.Exception();
    }
    else
    {
      Console.WriteLine("Day Two Test Five Passed");
    }    
  }    

  
}