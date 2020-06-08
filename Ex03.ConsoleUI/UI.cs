using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Policy;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
     static public class UI
     {
          internal static void OpenGarageForBusiness()
          {
               Garage currentGarage = new Garage();
               bool closeApp = false;
               while(closeApp==false)
               {
                   Menu(currentGarage,out closeApp);
               }
          }
          public static void Menu(Garage io_Garage,out bool io_CloseApp)
          {
            io_CloseApp = false;
            string optionStr = null;
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
                    inputIsValid = IsOptionValid(optionStr, 8);
                    if(inputIsValid == true)
                    {
                        ExecuteChoosedOption(int.Parse(optionStr), io_Garage,out io_CloseApp);
                    }
                    else
                    {
                        Console.WriteLine("Option that specified doesn't exist, please try again");
                    }
                }
            
          }

        public static void ExecuteChoosedOption(int i_Option,Garage io_Garage,out bool io_CloseApp)
        {
            io_CloseApp = false;
            switch(i_Option)
            {
                case 1:
                    AddVehicle(io_Garage);
                    break;
                case 2:
                    WatchGarageDataBase(io_Garage);
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
                    ShowVehicleData(io_Garage);
                    break;
                case 8:
                    io_CloseApp = true;
                    break;


            }

        }

        public static void RefuelVehicle(Garage io_Garage)
        {
            string licenseNumToWatch = GetLicenseNumStr();
            if (io_Garage.Clients.TryGetValue(licenseNumToWatch, out ClientCard client) == true)
            {
                Vehicle vehicleToRefuel = client.VehicleInGarage;
                if(vehicleToRefuel.MyEngine is GasEngine)
                {
                    Fuel fuelToFill = null;
                    float amountOfFuel = GetAmountOfFuelFromUser(vehicleToRefuel.MyEngine as GasEngine);
                    GetFuelTypeFromUser(out fuelToFill, (vehicleToRefuel.MyEngine as GasEngine).MyFuel);
                    (vehicleToRefuel.MyEngine as GasEngine).ReFuel(amountOfFuel,fuelToFill);
                    Console.WriteLine("Refueled successfully");
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

        public static float GetAmountOfFuelFromUser(GasEngine i_EngineToRefuel)
        {
            bool isValid = false;
            float amountOfFuel = 0;
            while(isValid == false)
            {
                Console.WriteLine("Please enter amount of fuel to add");
                amountOfFuel = GetFloatFromUser();
                isValid = i_EngineToRefuel.IsAmountsOfSourcePowerMaterialValid(amountOfFuel);
                if (isValid == false)
                {
                    Console.WriteLine("Cannot add fuel more than the gas tank can hold");
                }

            }

            return amountOfFuel;

        }
        public static string GetFuelTypeFromUser(out Fuel io_Fuel, Fuel i_FuelRequired)
        {
            bool isValid = false;
            string fuelType = null;
            io_Fuel = null;
            while(isValid == false)
            {
                Console.WriteLine("Please enter a fuel type");
                fuelType = Console.ReadLine();
                isValid = Fuel.TryParse(fuelType,out io_Fuel);
                if(isValid == false)
                { 
                    Console.WriteLine("Fuel type you mentioned doesn't exist");
                }
                else if (io_Fuel.Equals(i_FuelRequired) == false)
                {
                    Console.WriteLine("This vehicle uses another type of fuel");
                    isValid = false;
                }
            }

            return fuelType;
        }

        public static void WatchGarageDataBase(Garage i_Garage)
        {
            string choosedOption = null;
            int optionNum;
            bool optionIsValid = false;
            while (optionIsValid == false)
            {
                Console.WriteLine("Choose one of the options below:");
                Console.WriteLine("1.Show all vehicles");
                Console.WriteLine("2.Show all vehicles that in repair");
                Console.WriteLine("3.Show all vehicles that repaired");
                Console.WriteLine("4.Show all vehicles that just paid for the service");
                choosedOption = Console.ReadLine();
                optionIsValid = IsOptionValid(choosedOption,4);
                if(optionIsValid == false)
                {
                    Console.WriteLine("Incorrect input");
                }
            }

            optionNum = int.Parse(choosedOption);
            foreach (ClientCard client in i_Garage.Clients.Values)
            {
                if(optionNum==1)
                {
                    Console.WriteLine(client.VehicleInGarage.LicenseNum);
                }
                else if(optionNum-2==(int)client.Status)
                {
                    Console.WriteLine(client.VehicleInGarage.LicenseNum);
                }
            }

        }

        public static bool IsOptionValid(string i_ChoosedOption,int i_NumOfOptions)
        {
            bool isValid = false;
            for(int i = 1; i <= i_NumOfOptions; i++)
            {
                if(i_ChoosedOption.Equals(i.ToString()))
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }
        public static void ChargeVehiclesBattery(Garage io_Garage)
        {
            if (FindClientInGarage(io_Garage, out ClientCard clientToWatch) == true)
            {
                Vehicle vehicleToCharge = clientToWatch.VehicleInGarage;
                if (vehicleToCharge.MyEngine is Battery)
                {
                    float hoursToCharge = 0;
                    hoursToCharge = GetHoursToChargeFromUser((Battery)vehicleToCharge.MyEngine);
                    (vehicleToCharge.MyEngine as Battery).Reload(hoursToCharge);
                    Console.WriteLine("Charged successfully");
                }
                else
                {
                    Console.WriteLine("Cannot refuel electric vehicle");
                }
            }
        }
        public static float GetHoursToChargeFromUser(Battery i_BatteryToCharge)
        {
            float hoursToCharge = 0;
            bool isValid = false;

            while(isValid == false)
            {
                Console.WriteLine("Please enter amount of hours to load");
                hoursToCharge = GetFloatFromUser();
                isValid = i_BatteryToCharge.IsAmountsOfSourcePowerMaterialValid(hoursToCharge);
                if (isValid == false)
                {
                    Console.WriteLine("Cannot charge more than the capacity of the battery");
                }
            }

            return hoursToCharge;
        }

        public static float GetFloatFromUser()
        {
            bool isValid = false;
            string inputStr;
            float floatToReturn = 0;
            while(isValid == false)
            {
                inputStr = Console.ReadLine();
                isValid = float.TryParse(inputStr,out floatToReturn);
                if(isValid == false)
                {
                    Console.WriteLine("The input must be a number");
                }
            }
            return floatToReturn;
        }
        public static int GetIntFromUser()
        {
            bool isValid = false;
            string inputStr;
            int IntToReturn = 0;
            while (isValid == false)
            {
                inputStr = Console.ReadLine();
                isValid = int.TryParse(inputStr, out IntToReturn);
                if (isValid == false)
                {
                    Console.WriteLine("The input must be an integer");
                }
            }
            return IntToReturn;
        }
  
        public static void InflateVehicleWheels(Garage io_Garage)
        {
            if (FindClientInGarage(io_Garage, out ClientCard clientToWatch) == true)
            {
                Vehicle currentVehicle = clientToWatch.VehicleInGarage;
                foreach(Wheel wheel in currentVehicle.Wheels)
                {
                    wheel.InflateToMaximum();
                }
                Console.WriteLine("All wheels of the vehicle were inflated to the maximum value possible");
            }

        }
        public static void ChangeVehicleStatus(Garage io_Garage)
        {
            string optionStr = null;
            bool inputIsValid = false;
            if (FindClientInGarage(io_Garage,out ClientCard clientToWatch) == true)
            {
                while(inputIsValid == false)
                {
                    Console.WriteLine("Choose the status you want to set for the vehicle: InRepair, Repaired, Paid ");
                    Console.WriteLine("1.In repair ");
                    Console.WriteLine("2.Repaired ");
                    Console.WriteLine("3.Paid");
                    optionStr = Console.ReadLine();
                    inputIsValid = IsOptionValid(optionStr, 3);
                    if(inputIsValid == false)
                    {
                        Console.WriteLine("Invalid choice, please try again");
                    }
                    else
                    {
                         HandleStatusChange(clientToWatch, Garage.GetStatusFromInt(int.Parse(optionStr) - 1));
                    }
                }

            }
        }

        public static bool FindClientInGarage(Garage i_Garage,out ClientCard o_Client)
        {
            bool isFound = false;
            int attemptsLeft = 2;
            o_Client = null;

            while(isFound == false && attemptsLeft > 0)
            {
                string licenseNumToWatch = GetLicenseNumStr();
                isFound = i_Garage.Clients.TryGetValue(licenseNumToWatch, out o_Client);
                if(isFound == false)
                {
                    if(attemptsLeft > 0)
                    {
                        Console.WriteLine(string.Format(
                            "Vehicle not found, attempts left:{0}"
                            , attemptsLeft--));
                    }
                    else
                    {
                        Console.WriteLine("Vehicle not found, no attempts left, going back to the menu");
                    }
                }
            }

            return isFound;

        }
        public static void ShowVehicleData(Garage i_Garage)
        {

            if(FindClientInGarage(i_Garage, out ClientCard clientToWatch))
            {
                Console.WriteLine(clientToWatch.ToString());
            }
           
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
                   ClientCard newClient = io_Garage.Clients[licenseNum];
                   newClient.Status = Garage.eVehicleStat.InRepair;
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
                   io_Garage.AddVehicleToGarage(new ClientCard(vehicleToAdd,ownerName,ownerPhoneNum));
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
                inputIsValid = ClientCard.IsNameValid(name);
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
                inputIsValid = ClientCard.IsPhoneNumberValid(phoneNumStr);
                if (inputIsValid==false)
                {
                    Console.WriteLine("The number must contain 10 digits");
                }

            }

            return phoneNumStr;

        }

          internal static int GetTypeOption()
          {
              string choosedOption = null;
              bool inputIsValid = false;

              while(inputIsValid == false)
              {
                  PrintVehicleTypeMenu(Enum.GetNames(typeof(Instance.eVehicleType)));
                  choosedOption = Console.ReadLine();
                  inputIsValid = IsOptionValid(choosedOption, Enum.GetNames(typeof(Instance.eVehicleType)).Length);
                  if(inputIsValid == false)
                  {
                      Console.WriteLine("Incorrect input, please try again");
                  }
              }

              return int.Parse(choosedOption);
          }

          internal static string GetLicenseNumStr()
          {
               string licenseNumStr = null;
               bool isLicenseNumberValid = false;

               do
               {
                    Console.WriteLine("Please enter a license number of the vehicle: ");
                    licenseNumStr = Console.ReadLine();
                    isLicenseNumberValid = IsLicenseNumValid(licenseNumStr);
               } while (isLicenseNumberValid == false);


               return licenseNumStr;

          }

          internal static void PrintVehicleTypeMenu(string[] VehicleTypeStrings)
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
