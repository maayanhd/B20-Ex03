using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

/// For us
// communication with user -

// #1 overriding ToString methods - as well as Equal and other methods of Object  (for polymorphysm)
// #2 storing placeholders content for the string format string - for messages for communication with user 
// #3 leaving the enumeration structure of instance as is with switch architecture 
// #4 deciding whether the instance class will be static or not- more likely static 
// #5 UI - checking the validation of input- using logic methods of Logic layer

//strings discussion

// Generating strings - (implemented in) Logic layer (override - #1)
// Processing the strings (made by user input) into types- #4
// parsing from string to types -   (implemented in)- the UI layer
// generating a string - this included in the 

//exception discussion - 

//exception will be thrown at the logic layer
// This additional to validation checks in the Logic layer- for "Independence" and "Reuseability" of Logic layer
// UI LAYER- #5 - most likely using boolean variables 

//memory storage in Garage object class-  

// #6 using dictionary<> of int keys (made of string) and objects of vehicles
// Explanation : - using polymorphism by overriding .GetHashCode() that by default works on reference-  need to make a key from strings represent license number
// #7 using dictionary<> for driver details of int keys (same logic as #6) and objects of array of 2 strings- name and the other thing describes a driver
// using enumeration class - optional 
// adding enum variable for describing the status of a vehicle in the garage- 3 status modes 

// optional readonly for collection!!!
// Generating only once- suitable for collection of cars and collection of drivers' details mentioned in #7


namespace Ex03.ConsoleUI
{
     public class UI
     {
          public static void OpenGarageForBusiness()
          {
               Garage MyGarage = new Garage();

               
          }

          //****************Functionality******************//  

          public void AddVehicle()
          {
              Console.WriteLine("Please choose the type of vehicle you would like to enter the garage:" + Environment.NewLine);

               int numOption     = GetTypeOption();
               string licenseNum = GetLicenseNumStr();

               // Need to fix access to class of instance and static members in general
               Instance.GenerateInstance((Instance.eVehicleType)numOption, licenseNum);

          }

          public void ProceedToNextStepOfProcess()
          {
               Garage.countProcessSteps++;
          }
          //****************Input Methods******************//  
          public int GetTypeOption()
          {
               string numOptionString = null;
               int numOption;

               do
               {
                    PrintVehicleTypeMenu(Instance.sr_VehicleTypesStr);
                    numOptionString = Console.ReadLine();
               }
               while (OptionIsValid(numOptionString, out numOption) == false);

               return numOption;
          }

          public string GetLicenseNumStr()
          {
               string licenseNumStr = null;

               do
               {
                    Console.WriteLine(string.Format("Please enter {0}: {1}", Instance.sr_InitialsMemberInfoDetails[Garage.countProcessSteps]));
                    licenseNumStr = Console.ReadLine();

               } while (IsLicenseNumValid(licenseNumStr) == false);

               return licenseNumStr;

          }

          //****************Validation Methods******************//  
          public bool IsLicenseNumValid(string i_LicenseNum)
          {
               bool isValid = false;

               if (i_LicenseNum.Length == 8)
               {
                    isValid = true;
                    foreach (char ch in i_LicenseNum)
                    {
                         if (char.IsDigit(ch) == false)
                         {
                              isValid = false;
                              break;
                         }
                    }
               }

               return isValid;

          }
                   
          public bool OptionIsValid(string i_optionNumString, out int o_OptionNum)
          {
               return int.TryParse(i_optionNumString, out o_OptionNum) == true && o_OptionNum >= 1 && o_OptionNum <= Instance.sr_VehicleTypesStr.Count;
          }


          //****************Console Output******************//  
          public void PrintVehicleTypeMenu(List<string> VehicleTypeStrings)
          {
               foreach (string typeOfVehicle in VehicleTypeStrings)
               {
                    Console.WriteLine(string.Format("{0}. {1}{2}",
                         typeOfVehicle,
                         Environment.NewLine));
               }

          }

     }

}
