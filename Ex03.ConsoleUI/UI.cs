﻿using System;
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
     static public class UI
     {
          internal static void OpenGarageForBusiness()
          {
               Garage MyGarage = new Garage();

               AddVehicle();
          }

        //****************Functionality******************//  
        public static bool IsLicenseNumValid(string i_LicenseNum)
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
        internal static void AddVehicle()
          {
              Console.WriteLine("Please choose the type of vehicle you would like to enter the garage:" + Environment.NewLine);

               int numOption     = GetTypeOption();
               string licenseNum = GetLicenseNumStr();
               
               // Need to fix access to class of instance and static members in general
               Vehicle newVehicle = Instance.GenerateInstance((Instance.eVehicleType)numOption - 1, licenseNum);

               for(int i = 0; i < newVehicle.MemberInfoStrings.Count; i++)
               {
                   bool fieldIsValid = false;
                   while(fieldIsValid == false)
                   {
                       Console.WriteLine(string.Format("Please enter {0}", newVehicle.MemberInfoStrings[i]));
                       string inputStr = Console.ReadLine();
                       fieldIsValid = newVehicle.TryAssignMember(i, inputStr);
                       if(fieldIsValid == false)
                       {
                           Console.WriteLine("Wrong input, please try again");
                       }
                   }
               }

          }

          internal static void ProceedToNextStepOfProcess()
          {
               Garage.countProcessSteps++;
          }
          //****************Input Methods******************//  
          internal static int GetTypeOption()
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

          internal static string GetLicenseNumStr()
          {
               string licenseNumStr = null;

               do
               {
                   Console.WriteLine("Please enter a license number of the vehicle: ");
                   licenseNumStr = Console.ReadLine();

               } while (IsLicenseNumValid(licenseNumStr) == false);

               return licenseNumStr;

          }

          //****************Validation Methods******************//  
          

          internal static bool OptionIsValid(string i_optionNumString, out int o_OptionNum)
          {
               return int.TryParse(i_optionNumString, out o_OptionNum) == true && o_OptionNum >= 1 && o_OptionNum <= Instance.sr_VehicleTypesStr.Count;
          }


          //****************Console Output******************//  
          internal static void PrintVehicleTypeMenu(List<string> VehicleTypeStrings)
          {
               int optionNum = 1;
               foreach (string typeOfVehicle in VehicleTypeStrings)
               {
                    Console.WriteLine(string.Format("{0}. {1}{2}",
                         optionNum++,
                         typeOfVehicle,
                         Environment.NewLine));
               }

          }

     }

}
