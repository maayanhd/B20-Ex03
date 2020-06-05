using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     static public class Instance
     {
          public static readonly List<string> sr_VehicleTypesStr = new List<string> { "Car", "Bike", "Truck", "ElectricCar", "ElectricBike" };
          
          // New - update flow chart 
          public static readonly List<string> sr_InitialsMemberInfoDetails = new List<string> {"License Number", "Type Of Vehicle"};
                    
          //****************Vehicle types list******************//  
          public enum eVehicleType
          {
               GasCar,
               GasBike,
               Truck,
               ElectricCar,
               ElectricBike

          }
          

          static public Vehicle GenerateInstance(eVehicleType i_EVehicleType, string i_LicenseNum)
          {
               Vehicle generatedVehicle = null;

               switch (i_EVehicleType)
               {
                    case eVehicleType.GasCar:
                         generatedVehicle = new Car(i_LicenseNum, new GasEngine(60, GasEngine.eFuelType.Octan96));
                         break;

                    case eVehicleType.GasBike:
                         generatedVehicle = new Bike(i_LicenseNum, new GasEngine(7, GasEngine.eFuelType.Octan95));
                         break;

                    case eVehicleType.Truck:
                         generatedVehicle = new Truck(i_LicenseNum, new GasEngine(120, GasEngine.eFuelType.Soler));
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

     }

}
