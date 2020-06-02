using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Instance
     {
          public enum eVehicleType
          {
               GasCar, 
               GasBike,
               Truck, 
               ElectricCar, 
               ElectricBike
          }

          public Vehicle Generate(eVehicleType i_EVehicleType)
          {
               Vehicle generatedVehicle = null;

               switch(i_EVehicleType)
               {
                    case eVehicleType.GasCar:
                         generatedVehicle = new Car();
                         break;

                    case eVehicleType.GasBike:
                         generatedVehicle = new Bike();
                         break;

                    case eVehicleType.Truck:
                         generatedVehicle = new Truck();
                         break;

                    case eVehicleType.ElectricCar:
                         generatedVehicle = new ElectricBike();
                         break;

                    case eVehicleType.ElectricBike:
                         generatedVehicle = new ElectricBike();
                         break;
               }
          
               return generatedVehicle;

          }
     
     }

}
