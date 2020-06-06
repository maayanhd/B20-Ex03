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
     static public class UI
     {
          internal static void OpenGarageForBusiness()
          {
               Garage currentGarage = new Garage();
               Menu(currentGarage);
          }

        //****************Functionality******************//
        public static void Menu(Garage io_Garage)
        {
            string optionStr;
            int option;
            bool inputIsValid = false;
            Console.WriteLine("Choose one of the options below:");
            Console.WriteLine("1.Add vehicle");
            Console.WriteLine("2.View the list of vehicles in the garage");
            Console.WriteLine("3.Change vehicle status");
            Console.WriteLine("4.Inflate wheels of a vehicle");
            Console.WriteLine("5.Refuel a vehicle");
            Console.WriteLine("6.Charge an electric vehicle battery");
            Console.WriteLine("7.Get vehicle info by a license number");
            Console.WriteLine("8.Exit");
            while(inputIsValid == false)
            {
                optionStr = Console.ReadLine();
                inputIsValid = IsMenuOptionValid(optionStr);
                if(inputIsValid == true)
                {
                    ExecuteChoosedOption(int.Parse(optionStr), io_Garage);
                }
                {
                    Console.WriteLine("Option that specified doesn't exist, please try again");
                }
            }

        }

        public static void ExecuteChoosedOption(int i_Option,Garage io_Garage)
        {
            switch(i_Option)
            {
                case 1:
                    AddVehicle(io_Garage);
                    break;
                case 2:
                    ShowVehiclesInGarage(io_Garage);
                    break;
                case 3:
                    ChangeVehicleStatus(io_Garage);
                    break;
                case 4:
                    InflateVehicleWheels(io_Garage);
                    break;
                case 5:
                    RefuelVehicle(io_Garage);
                    break;
                case 6:
                    ChargeVehiclesBattery(io_Garage);
                    break;
                case 7:
                    WatchVehicleData(io_Garage);
                    break;
                case 8:
                    Environment.Exit(0);
                    break;


            }

        }

        public static void RefuelVehicle(Garage io_Garage)
        {
            string licenseNumToWatch = GetLicenseNumStr();
            if (io_Garage.Vehicles.TryGetValue(licenseNumToWatch, out OrderInfo orderToWatch) == true)
            {
                Vehicle vehicleToRefuel = orderToWatch.VehicleInGarage;
                if(vehicleToRefuel.MyEngine is GasEngine)
                {
                   // input fuel 
                }
                else
                {
                    Console.WriteLine("Cannot refuel electric vehicle");
                }
            }
            else
            {
                Console.WriteLine("Vehicle not found");
            }

        }

        public static void WatchVehicleData(Garage i_Garage)
        {
            string licenseNumToWatch = GetLicenseNumStr();
            if(i_Garage.Vehicles.TryGetValue(licenseNumToWatch, out OrderInfo orderToWatch) == true)
            {
                Console.WriteLine(orderToWatch.ToString());
            }
            else
            {
                Console.WriteLine("Vehicle not found");
            }
           
            

        }
        public static void ChargeVehiclesBattery(Garage io_Garage)
        {


        }
        public static void InflateVehicleWheels(Garage io_Garage)
        {


        }
        public static void ChangeVehicleStatus(Garage io_Garage)
        {

        }
        public static void ShowVehiclesInGarage(Garage i_Garage)
        {


        }
        public static bool IsMenuOptionValid(string i_OptionStr)
        {
            bool isValid = false;
            string[] options = new string[8] { "1", "2", "3", "4", "5", "6", "7", "8" };
            foreach(string option in options)
            {
                if(option.Equals(i_OptionStr))
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }
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
        internal static void AddVehicle(Garage io_Garage)
          {
              Console.WriteLine("Please choose the type of vehicle you would like to enter the garage:" + Environment.NewLine);

               int numOption     = GetTypeOption();
               string licenseNum = GetLicenseNumStr();
               
               if (io_Garage.IsVehicleExistsInGarage(licenseNum) == true)
               {
                   Console.WriteLine("The Vehicle is already in the garage");
                   OrderInfo orderOfTheVehicle = io_Garage.Vehicles[licenseNum];
                   orderOfTheVehicle.Status = Garage.eVehicleStat.InRepair;
               }
               else
               {
                   string ownerName;
                   string ownerPhoneNum;
                   Vehicle vehicleToAdd = Instance.GenerateInstance((Instance.eVehicleType)numOption - 1, licenseNum);

                   for(int i = 0; i < vehicleToAdd.MemberInfoStrings.Count; i++)
                   {
                       bool fieldIsValid = false;
                       while(fieldIsValid == false)
                       {
                           Console.WriteLine(string.Format("Please enter {0}", vehicleToAdd.MemberInfoStrings[i]));
                           string inputStr = Console.ReadLine();
                           fieldIsValid = vehicleToAdd.TryAssignMember(i, inputStr);
                           if(fieldIsValid == false)
                           {
                               Console.WriteLine("Wrong input, please try again");
                           }
                       }
                   }

                   ownerName = GetNameFromUser();
                   ownerPhoneNum = GetPhoneNumberFromUser();
                   io_Garage.AddVehicleToGarage(new OrderInfo(vehicleToAdd,ownerName,ownerPhoneNum));
                   Console.WriteLine("The Vehicle successfully added to the garage ");
               }
          }

        public static string GetNameFromUser()
        {
            bool inputIsValid = false;
            string name = null;
            while (inputIsValid == false)
            {
                Console.WriteLine("Please enter your name");
                name = Console.ReadLine();
                inputIsValid = OrderInfo.IsNameValid(name);
                if(inputIsValid == false)
                {
                    Console.WriteLine("The input should contain only letters");
                }
            }
            
            return name;
        }

        public static string GetPhoneNumberFromUser()
        {
            string phoneNumStr = null;
            bool inputIsValid = false;
            while (inputIsValid == false)
            {
                Console.WriteLine("Please enter your phone number");
                phoneNumStr = Console.ReadLine();
                inputIsValid = int.TryParse(phoneNumStr, out int phoneNum);
                if (inputIsValid == false)
                {
                    Console.WriteLine("The input should contain only digits");
                }
                else
                {
                    inputIsValid = OrderInfo.IsPhoneNumberValid(phoneNum);
                    if(inputIsValid == false)
                    {
                        Console.WriteLine("The number must contain 10 digits");
                    }
                }

            }

            return phoneNumStr;

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
