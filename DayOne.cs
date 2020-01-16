using System;

class DayOne {
  public int [] moduleMasses;

  public DayOne() {
    moduleMasses = new int[] {139195, 139828, 68261, 122523, 122363, 92345, 57517, 96771, 109737, 106466, 79011, 131515, 77564, 128967, 76455, 140143, 94188, 102483, 116410, 102343, 75009, 132926, 124193, 141396, 94715, 144192, 61123, 112401, 139101, 99152, 124424, 95233, 92024, 145901, 101966, 113963, 79648, 76216, 140625, 72982, 89179, 123060, 133118, 96191, 55839, 141615, 107191, 130028, 65641, 106080, 122329, 63873, 56237, 55959, 71941, 86453, 50127, 61463, 128084, 127326, 118094, 69727, 96157, 85522, 122926, 90449, 108978, 69085, 119108, 81331, 143962, 119929, 100978, 77036, 99555, 77342, 75274, 148490, 94110, 104057, 142323, 87000, 123416, 113491, 69569, 136231, 124140, 62041, 130474, 77480, 76624, 111762, 117950, 144316, 149407, 96042, 63783, 62694, 142257, 92563};
  }
  public int RunTestsAndGetResultPartOne() {
    RunTestsPartOne();
    return CalculateTotalFuelRequirement();
  }

  public int RunTestsAndGetResultPartTwo() {
    RunTestsPartTwo();
    return CalculateTotalTyranicalFuelRequirement();
  }  

  public int CalculateTotalFuelRequirement() {
    var totalMass = 0;

    foreach(int mass in moduleMasses)
    {
      totalMass += CalculateFuel(mass);
    }

    return totalMass;
  }

  public int CalculateTotalTyranicalFuelRequirement() {
    var totalMass = 0;

    foreach(int mass in moduleMasses)
    {
      totalMass += CalculateTyranicalFuel(mass);
    }

    return totalMass;
  }  

  public int CalculateTyranicalFuel(int mass) {    
    var fuel = CalculateFuel(mass);

    if ( fuel <= 0 ) {
      return 0;
    }

    fuel += CalculateTyranicalFuel(fuel);
    return fuel;
  }

  public int CalculateFuel(int mass) {
    return mass == 0 ? 0 : Convert.ToInt32(mass / 3) - 2;
  }

  public void RunTestsPartTwo () {
    if(CalculateTyranicalFuel(14) != 2) {
      throw new System.Exception("test failed " + "14");
    }
    if(CalculateTyranicalFuel(1969) != 966) {
      throw new System.Exception("test failed" + "1969");
    }
    if(CalculateTyranicalFuel(100756) != 50346) {
      throw new System.Exception("test failed" + "100756");
    }            
  }

  public void RunTestsPartOne () {
    if(CalculateFuel(12) != 2) {
      throw new System.Exception();
    }
    if(CalculateFuel(14) != 2) {
      throw new System.Exception();
    }    
    if(CalculateFuel(1969) != 654) {
      throw new System.Exception();
    }    
    if(CalculateFuel(100756) != 33583) {
      throw new System.Exception();
    }    
  }  
}