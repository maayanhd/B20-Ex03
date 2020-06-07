using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public static class Instance
     {

          public enum eVehicleType
          {
               Car,
               Bike,
               Truck,
               ElectricCar,
               ElectricBike

          }


        static public Vehicle GenerateInstance(eVehicleType i_EVehicleType, string i_LicenseNum)
          {
               Vehicle generatedVehicle = null;

               switch (i_EVehicleType)
               {
                    case eVehicleType.Car:
                         generatedVehicle = new Car(i_LicenseNum, new GasEngine(60, new Fuel(Fuel.eFuelType.Octan96)));
                         break;

                    case eVehicleType.Bike:
                         generatedVehicle = new Bike(i_LicenseNum, new GasEngine(7, new Fuel(Fuel.eFuelType.Octan95)));
                         break;

                    case eVehicleType.Truck:
                         generatedVehicle = new Truck(i_LicenseNum, new GasEngine(120, new Fuel(Fuel.eFuelType.Soler)));
                         break;

                    case eVehicleType.ElectricCar:
                         generatedVehicle = new Car(i_LicenseNum, new Battery((float)2.1));
                         break;

                    case eVehicleType.ElectricBike:
                         generatedVehicle = new Bike(i_LicenseNum, new Battery((float)1.2));
                         break;
               }

               return generatedVehicle;

          }

        public static bool OptionIsValid(int o_OptionNum)
        {
            return o_OptionNum >= 1 && o_OptionNum <= Enum.GetNames(typeof(Instance.eVehicleType)).Length;
        }

    }

}
