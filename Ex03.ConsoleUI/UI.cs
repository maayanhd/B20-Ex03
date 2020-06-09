using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Policy;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class UI
    {
        public static void OpenGarageForBusiness()
        {
            Garage currentGarage = new Garage();
            bool closeApp = false;
            while (closeApp == false)
            {
                Menu(currentGarage, out closeApp);
            }
        }

        public static void Menu(Garage io_Garage, out bool io_CloseApp)
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
            while (inputIsValid == false)
            {
                optionStr = Console.ReadLine();
                inputIsValid = IsOptionValid(optionStr, 8);
                if (inputIsValid == true)
                {
                    ExecuteChoosedOption(int.Parse(optionStr), io_Garage, out io_CloseApp);
                }
                else
                {
                    Console.WriteLine("Option that specified doesn't exist, please try again");
                }
            }
        }

        public static void ExecuteChoosedOption(int i_Option, Garage io_Garage, out bool io_CloseApp)
        {
            io_CloseApp = false;
            switch (i_Option)
            {
                case 1:
                    AddVehicle(io_Garage);
                    break;
                case 2:
                    ShowGarageDataBase(io_Garage);
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
            if(io_Garage.TryToFindClient(licenseNumToWatch, out ClientCard client) == true)
            {
                Vehicle vehicleToRefuel = client.VehicleInGarage;
                if(vehicleToRefuel.MyEngine is GasEngine)
                {
                    float amountOfFuel = GetAmountOfFuelFromUser(vehicleToRefuel.MyEngine as GasEngine);
                    GetFuelTypeFromUser(out Fuel fuelToFill, (vehicleToRefuel.MyEngine as GasEngine).MyFuel);
                    (vehicleToRefuel.MyEngine as GasEngine).ReFuel(amountOfFuel, fuelToFill, vehicleToRefuel);
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
            while (isValid == false)
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
            while (isValid == false)
            {
                Console.WriteLine("Please enter a fuel type");
                fuelType = Console.ReadLine();
                isValid = Fuel.TryParse(fuelType, out io_Fuel);
                if (isValid == false)
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

        public static void ShowGarageDataBase(Garage i_Garage)
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
                optionIsValid = IsOptionValid(choosedOption, 4);
                if (optionIsValid == false)
                {
                    Console.WriteLine("Incorrect input");
                }
            }

            optionNum = int.Parse(choosedOption);
            if (optionNum == 1)
            {
                PrintAllClientsLicenseNum(i_Garage);
            }
            else
            {
                Garage.eVehicleStat filter = Garage.GetStatusFromInt(optionNum - 2);
                PrintListOfStrings(i_Garage.GetClientsByStatus(filter));
            }
        }

        public static void PrintAllClientsLicenseNum(Garage i_Garage)
        {
            if (i_Garage.Clients.Count == 0)
            {
                Console.WriteLine("No vehicles in the garage at this moment");
            }
            else
            {
                foreach (string key in i_Garage.Clients.Keys)
                {
                    Console.WriteLine(key);
                }
            }
        }

        public static void PrintListOfStrings(List<string> i_ListToPrint)
        {
            if (i_ListToPrint.Count == 0)
            {
                Console.WriteLine("No vehicles applied to your request");
            }
            else
            {
                foreach (string str in i_ListToPrint)
                {
                    Console.WriteLine(str);
                }
            }
        }

        public static bool IsOptionValid(string i_ChoosedOption, int i_NumOfOptions)
        {
            bool isValid = false;
            for (int i = 1; i <= i_NumOfOptions; i++)
            {
                if (i_ChoosedOption.Equals(i.ToString()))
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
                    hoursToCharge = GetMinutesToChargeFromUser((Battery)vehicleToCharge.MyEngine);
                    (vehicleToCharge.MyEngine as Battery).Reload(hoursToCharge, vehicleToCharge);
                    Console.WriteLine("Charged successfully");
                }
                else
                {
                    Console.WriteLine("Cannot charge gasoline vehicle");
                }
            }
        }

        public static float GetMinutesToChargeFromUser(Battery i_BatteryToCharge)
        {
            float minutesToCharge = 0;
            bool isValid = false;

            while (isValid == false)
            {
                Console.WriteLine("Please enter amount of minutes to load");
                minutesToCharge = GetFloatFromUser();
                isValid = i_BatteryToCharge.IsAmountsOfSourcePowerMaterialValid(minutesToCharge / 60);
                if (isValid == false)
                {
                    Console.WriteLine("Cannot charge more than the capacity of the battery");
                }
            }

            return minutesToCharge / 60;
        }

        public static float GetFloatFromUser()
        {
            bool isValid = false;
            string inputStr;
            float floatToReturn = 0;
            while (isValid == false)
            {
                inputStr = Console.ReadLine();
                isValid = float.TryParse(inputStr, out floatToReturn);
                if (isValid == false)
                {
                    Console.WriteLine("The input must be a number");
                }
            }

            return floatToReturn;
        }

        public static void InflateVehicleWheels(Garage io_Garage)
        {
            if (FindClientInGarage(io_Garage, out ClientCard clientToWatch) == true)
            {
                Vehicle currentVehicle = clientToWatch.VehicleInGarage;
                foreach (Wheel wheel in currentVehicle.Wheels)
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
            if (FindClientInGarage(io_Garage, out ClientCard clientToWatch) == true)
            {
                while (inputIsValid == false)
                {
                    Console.WriteLine("Choose the status you want to set for the vehicle: InRepair, Repaired, Paid ");
                    Console.WriteLine("1.In repair ");
                    Console.WriteLine("2.Repaired ");
                    Console.WriteLine("3.Paid");
                    optionStr = Console.ReadLine();
                    inputIsValid = IsOptionValid(optionStr, 3);
                    if (inputIsValid == false)
                    {
                        Console.WriteLine("Invalid choice, please try again");
                    }
                    else
                    {
                        io_Garage.ChangeVehicleStatus(clientToWatch, Garage.GetStatusFromInt(int.Parse(optionStr) - 1));
                    }
                }
            }
        }

        public static bool FindClientInGarage(Garage i_Garage, out ClientCard o_Client)
        {
            bool isFound = false;
            int attemptsLeft = 2;
            o_Client = null;

            while(isFound == false)
            {
                if(attemptsLeft >= 0)
                {
                    string licenseNumToWatch = GetLicenseNumStr();
                    isFound = i_Garage.TryToFindClient(licenseNumToWatch, out o_Client);
                    if (isFound == false)
                    {
                        Console.WriteLine("Vehicle not found, attempts left:{0}", attemptsLeft--);
                    }
                }
                else
                {
                    Console.WriteLine("Vehicle not found, no attempts left, going back to the menu");
                    break;
                }
            }

            return isFound;
        }

        public static void ShowVehicleData(Garage i_Garage)
        {
            if (FindClientInGarage(i_Garage, out ClientCard clientToWatch))
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

        public static void AddVehicle(Garage io_Garage)
        {
            Console.WriteLine("Please choose the type of vehicle you would like to enter the garage:");

            int numOption = GetTypeOption();
            string licenseNum = GetLicenseNumStr();

            if (io_Garage.TryToFindClient(licenseNum, out ClientCard newClient) == true)
            {
                Console.WriteLine("The Vehicle is already in the garage");
                newClient.Status = Garage.eVehicleStat.InRepair;
            }
            else
            {
                string ownerName;
                string ownerPhoneNum;
                Vehicle vehicleToAdd = Instance.GenerateInstance((Instance.eVehicleType)numOption - 1, licenseNum);

                for (int i = 0; i < vehicleToAdd.MemberInfoStrings.Count; i++)
                {
                    bool fieldIsValid = false;
                    while (fieldIsValid == false)
                    {
                        Console.WriteLine("Please enter {0}", vehicleToAdd.MemberInfoStrings[i]);
                        string inputStr = Console.ReadLine();
                        fieldIsValid = vehicleToAdd.TryAssignMember(i, inputStr, out string errorMessage);
                        if (fieldIsValid == false)
                        {
                            Console.WriteLine(errorMessage);
                        }
                    }
                }

                ownerName = GetNameFromUser();
                ownerPhoneNum = GetPhoneNumberFromUser();
                io_Garage.AddVehicleToGarage(new ClientCard(vehicleToAdd, ownerName, ownerPhoneNum));
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
                if (inputIsValid == false)
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
                if (inputIsValid == false)
                {
                    Console.WriteLine("The number must contain 10 digits");
                }
            }

            return phoneNumStr;
        }

        public static int GetTypeOption()
        {
            string choosedOption = null;
            bool inputIsValid = false;

            while (inputIsValid == false)
            {
                PrintVehicleTypeMenu(Enum.GetNames(typeof(Instance.eVehicleType)));
                choosedOption = Console.ReadLine();
                inputIsValid = IsOptionValid(choosedOption, Enum.GetNames(typeof(Instance.eVehicleType)).Length);
                if (inputIsValid == false)
                {
                    Console.WriteLine("Invalid option, please try again");
                }
            }

            return int.Parse(choosedOption);
        }

        public static string GetLicenseNumStr()
        {
            string licenseNumStr = null;
            bool isLicenseNumberValid = false;

            do
            {
                Console.WriteLine("Please enter a license number of the vehicle: ");
                licenseNumStr = Console.ReadLine();
                isLicenseNumberValid = IsLicenseNumValid(licenseNumStr);
                if (isLicenseNumberValid == false)
                {
                    Console.WriteLine("Incorrect format, it must be a 10-digit number");
                }
            }
            while (isLicenseNumberValid == false);

            return licenseNumStr;
        }

        public static void PrintVehicleTypeMenu(string[] VehicleTypeStrings)
        {
            int optionNum = 1;
            foreach (string typeOfVehicle in VehicleTypeStrings)
            {
                Console.WriteLine("{0}. {1}", optionNum++, typeOfVehicle);
            }
        }
    }
}
