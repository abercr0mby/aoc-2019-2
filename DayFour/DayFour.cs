using System;

class DayFour {
  
  public bool IsPasswordValid(string password)
  {
    if(!DoDigitsIncrease(password))
    {
      return false;
    }

    if(!CheckForContiguousDigits(password))
    {
      return false;
    }    

    return true;
  }

  public bool IsPasswordValidStrict(string password)
  {
    if(!DoDigitsIncrease(password))
    {
      return false;
    }

    if(!CheckForContiguousDigitsStrict(password))
    {
      return false;
    }    

    return true;
  }

  public bool CheckForContiguousDigitsStrict(string digits)
  {
    var contiguousDigits = 1;
    for(int i = 1; i < digits.Length; i++)
    {
      if(digits[i] == digits[i-1])
      {
        contiguousDigits ++;
      }
      else
      {
        if( contiguousDigits == 2 )
        {
          return true;
        }
        contiguousDigits = 1;
      }      
    }    

    if( contiguousDigits == 2 )
    {
      return true;
    }    

    return false;
  }

  public bool CheckForContiguousDigits(string digits)
  {
    for(int i = 1; i < digits.Length; i++)
    {
      if(digits[i] == digits[i-1])
      {
        return true;
      }      
    }    
    return false;
  }

  public bool DoDigitsIncrease(string digits)
  {
    for(int i = 1; i < digits.Length; i++)
    {
      if(digits[i] < digits[i-1])
      {
        return false;
      }
    }
    return true;
  }

  public int RunTestsAndGetResultPartOne()
  {
    RunTestsPartOne();
    return CountValidPasswords(372037, 905157);
  }

  public int CountValidPasswords(int from, int to)
  {
    var validPasswords = 0;

    for(var i = from; i <= to; i++)
    {
      if(IsPasswordValid(i.ToString()))
      {
        validPasswords ++;
      }
    }
    return validPasswords;
  }

  public int CountValidPasswordsStrict(int from, int to)
  {
    var validPasswords = 0;

    for(var i = from; i <= to; i++)
    {
      if(IsPasswordValidStrict(i.ToString()))
      {
        validPasswords ++;
      }
    }
    return validPasswords;
  }  

  public void RunTestsPartOne()
  {
    if(!IsPasswordValid("111111")) 
    {
      throw new System.Exception("111111 should be valid");
    }
    if(IsPasswordValid("223450")) 
    {
      throw new System.Exception("223450 should not be valid");
    }
    if(IsPasswordValid("123789")) 
    {
      throw new System.Exception("123789 should not be valid");
    }        
  }

  public int RunTestsAndGetResultPartTwo()
  {
    RunTestsPartTwo();
    return CountValidPasswordsStrict(372037, 905157);
  }

  public void RunTestsPartTwo()
  {
    if(!IsPasswordValidStrict("112233")) 
    {
      throw new System.Exception("112233 should be valid");
    }
    if(IsPasswordValidStrict("123444")) 
    {
      throw new System.Exception("123444 should not be valid");
    }
    if(!IsPasswordValidStrict("111122")) 
    {
      throw new System.Exception("111122 should be valid");
    }        
  }
  
}