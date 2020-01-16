using System;
using System.Collections.Generic;

class IntCodeComputer
{
  public long[] Program;
  private long CurrentPosition { get; set; }
  private long RelativeBase { get; set; }
  private string NextOpCode { get; set; } 
  public bool Halted { get; set; }

  public long[] Inputs { get; set; }
  private int CurrentInput { get; set; }
  public List<long> Output { get; set; } = new List<long>();
  private bool Debug { get; set; }
  private bool PauseAfterOutput { get; set; }

  public IntCodeComputer(long[] program, long[] inputs, bool pauseAfterOutput = true, bool debug = false)
  {
    CurrentPosition = 0;    
    this.Program = (long[]) program.Clone();

    this.Inputs = inputs;
    CurrentInput = 0;
    RelativeBase = 0;
    Halted = false;
    Debug = debug;
    PauseAfterOutput = pauseAfterOutput;
  }

  public void SetInputSignal(long inputSignal)
  {
    Inputs[1] = inputSignal;
  }

  public char [] GetParameterTypesFromOpCodeValue(string opCodeValue, string opCode)
  {
    if(opCode.Length < opCodeValue.Length)
    {
      var parameters = opCodeValue.Substring(0 ,opCodeValue.Length - opCode.Length);
      var charArray = parameters.ToCharArray();
      Array.Reverse( charArray );
      return charArray == null ? new char[0] : charArray;
    }
    return null;
  }

  private void SetNextOpCode()
  {
    var opCodeValue = Program[CurrentPosition].ToString();
    var opCodeLength = opCodeValue.Length > 1 ? 2 : 1;
    NextOpCode = opCodeValue.Substring(opCodeValue.Length - opCodeLength ,opCodeLength).PadLeft(2, '0');
  }

  public long GetParameter(long position, char[] parameterTypes)
  {
    long parameterIndex = 0;

    if(parameterTypes == null || parameterTypes.Length < position || parameterTypes[position -1] == '0')
    {
      parameterIndex = Program[CurrentPosition + position];
    }
    else if (parameterTypes[position -1] == '1')
    {
      parameterIndex = CurrentPosition + position;
    }
    else if (parameterTypes[position -1] == '2')
    {      
      parameterIndex = Program[CurrentPosition + position] + RelativeBase;
    }

    CheckPositionAndResize(parameterIndex);
    
    return parameterIndex;
  }

  public void CheckPositionAndResize(long position)
  {
    if(position > Program.Length - 1)
    {
      Array.Resize<long>(ref Program, (int) position + 1);
    }    
  }

  public void SetTargetToValue(long position, long value)
  {
    CheckPositionAndResize(position);
    Program[position] = value;
  }

  public void ChangeCurrentPosition(long newPosition)
  {
    CheckPositionAndResize(newPosition);
    CurrentPosition = newPosition;
  }

  public void Add(char[] parameterTypes)
  {
    var xPos = GetParameter(1, parameterTypes);
    var x = Program[xPos];
    
    var yPos = GetParameter(2, parameterTypes);
    var y = Program[yPos];

    var target = GetParameter(3, parameterTypes);

    SetTargetToValue(target, x + y);
    ChangeCurrentPosition(CurrentPosition += 4);
  }

  public void Multiply(char[] parameterTypes)
  {
    var xPos = GetParameter(1, parameterTypes);
    var x = Program[xPos];

    var yPos = GetParameter(2, parameterTypes);
    var y = Program[yPos];

    var target = GetParameter(3, parameterTypes);

    SetTargetToValue(target, x * y);
    
    ChangeCurrentPosition(CurrentPosition += 4);
  }

  public void ShowOutput(char[] parameterTypes)
  {
    var xPos = GetParameter(1, parameterTypes);
    var x = Program[xPos];

    Output.Add(x);
    ChangeCurrentPosition(CurrentPosition += 2);
  }

  public void GetInput(char[] parameterTypes)
  {
    if (Inputs != null && Inputs.Length >= CurrentInput)
    {
      var inputTarget = GetParameter(1, parameterTypes);      
      SetTargetToValue(inputTarget, Inputs[CurrentInput]);
      if(Inputs.Length - 1 > CurrentInput)
      {
        CurrentInput ++;
      }

      ChangeCurrentPosition(CurrentPosition += 2);
      return;
    }
  }  

  public void JumpIfTrue(char[] parameterTypes)
  {
    var xPos = GetParameter(1, parameterTypes);
    var x = Program[xPos];

    var yPos = GetParameter(2, parameterTypes);
    var y = Program[yPos];

    if (x != 0)
    {
      ChangeCurrentPosition(y);
      return;
    }
    ChangeCurrentPosition(CurrentPosition + 3);
  }

  public void JumpIfFalse(char[] parameterTypes)
  {
    var xPos = GetParameter(1, parameterTypes);
    var x = Program[xPos];

    var yPos = GetParameter(2, parameterTypes);
    var y = Program[yPos];

    if (x == 0)
    {
      ChangeCurrentPosition(y);
      return;
    }       
    ChangeCurrentPosition(CurrentPosition + 3);
  }

  public void LessThan(char[] parameterTypes)
  {
    var xPos = GetParameter(1, parameterTypes);
    var x = Program[xPos];

    var yPos = GetParameter(2, parameterTypes);
    var y = Program[yPos];

    var inputTarget = GetParameter(3, parameterTypes);      

    SetTargetToValue(inputTarget, x < y ? 1 : 0);
    ChangeCurrentPosition(CurrentPosition += 4);
  }

  public void Equals(char[] parameterTypes)
  {
    var xPos = GetParameter(1, parameterTypes);
    var x = Program[xPos];

    var yPos = GetParameter(2, parameterTypes);
    var y = Program[yPos];

    var inputTarget = GetParameter(3, parameterTypes);
    
    SetTargetToValue(inputTarget, x == y ? 1 : 0);
    ChangeCurrentPosition(CurrentPosition += 4);
  }

  public void AdjustRelativeBase(char[] parameterTypes)
  {
    var xPos = GetParameter(1, parameterTypes);
    var x = Program[xPos];
    
    RelativeBase += x;
    ChangeCurrentPosition(CurrentPosition += 2);
  }

  public void Compute() 
  {
    while(NextOpCode != "99")
    {
      var opCodeValue = Program[CurrentPosition].ToString();          
      SetNextOpCode();
      char[] parameterTypes = GetParameterTypesFromOpCodeValue(opCodeValue, NextOpCode);      

      if(Debug)
      {
        //Console.WriteLine("next: " + NextOpCode + " curr: " + CurrentPosition + " - " + "op " + opCodeValue + " rb: " + RelativeBase);      
        //foreach(var p in Program)
        //  Console.Write(p + " - ");
        //Console.WriteLine("");
      }
      switch (NextOpCode)
      {
        case "01":
          Add(parameterTypes);
          break;

        case "02":
          Multiply(parameterTypes);
          break;

        case "03":
          GetInput(parameterTypes);
          break;

        case "04":
          ShowOutput(parameterTypes);
          break;

        case "05":
          JumpIfTrue(parameterTypes);
          break;

        case "06":
          JumpIfFalse(parameterTypes);
          break;

        case "07":
          LessThan(parameterTypes);
          break;

        case "08":
          Equals(parameterTypes);
          break;                                    

        case "09":
          AdjustRelativeBase(parameterTypes);
          break;                                    

        case "99":
          break;  

        default:
          throw new System.Exception("unknown opcode - " + NextOpCode);        
      }      
      
      if(NextOpCode == "04" && PauseAfterOutput)
      {  
        break;
      }

      if(NextOpCode == "99")
      {
        Halted = true;
        break;
      } 
    }
      
    return;
  }
}