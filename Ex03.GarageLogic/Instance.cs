using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    public class Instance
     {
        private readonly List<string> r_VehicleTypesStr = new List<string> { "Car", "Bike", "Truck", "ElectricCar", "ElectricBike" };

        public enum eVehicleType
          {
               GasCar, 
               GasBike,
               Truck, 
               ElectricCar, 
               ElectricBike
          }
           
          public Vehicle Generate(eVehicleType i_EVehicleType,string i_LicenseNum)
          {
               Vehicle generatedVehicle = null;

               switch(i_EVehicleType)
               {
                    case eVehicleType.GasCar:
                         generatedVehicle = new Car(i_LicenseNum);
                         break;

                    case eVehicleType.GasBike:
                         generatedVehicle = new Bike(i_LicenseNum);
                         break;

                    case eVehicleType.Truck:
                         generatedVehicle = new Truck(i_LicenseNum);
                         break;

                    case eVehicleType.ElectricCar:
                         generatedVehicle = new ElectricBike(i_LicenseNum);
                         break;

                    case eVehicleType.ElectricBike:
                         generatedVehicle = new ElectricBike(i_LicenseNum);
                         break;
               }
          
               return generatedVehicle;

          }
     
     }

}
