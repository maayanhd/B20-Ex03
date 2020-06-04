using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Garage
     {
          private readonly Dictionary<int, Vehicle> r_Vehicles              = null;
          private readonly Dictionary<int, string[]> r_VehiclesOwnerDetails = null;
          private readonly Dictionary<int, eVehicleStat> r_VehicleStatus    = null;

          public Garage()
          {
               r_Vehicles             = new Dictionary<int, Vehicle>();
               r_VehiclesOwnerDetails = new Dictionary<int, string[]>();
               r_VehicleStatus        = new Dictionary<int, eVehicleStat>();

          }

          public enum eVehicleStat
          {
               InRepair,
               Repaired,
               Paid
          }

          public Dictionary<int, Vehicle> Vehicles
          {
               get
               {
                    return r_Vehicles;
               }

          }

          public Dictionary<int , string[]> VehiclesInGarageDetails
          {
               get
               {
                    return r_VehiclesOwnerDetails;
               }

          }

          public Dictionary<int, eVehicleStat> VehicleStatus
          {
               get
               {
                    return r_VehicleStatus;
               }

          }

     }

}
