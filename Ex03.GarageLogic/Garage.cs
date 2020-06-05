using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Garage
     {
          private readonly Dictionary<int, Vehicle> r_Vehicles = null;
          private readonly Dictionary<int, string[]> r_VehiclesOwnerDetails = null;
          private readonly Dictionary<int, eVehicleStat> r_VehicleStatus = null;

          //New- update flow chart
          public static int countProcessSteps = 3;

          public Garage()
          {
               r_Vehicles = new Dictionary<int, Vehicle>();
               r_VehiclesOwnerDetails = new Dictionary<int, string[]>();
               r_VehicleStatus = new Dictionary<int, eVehicleStat>();

          }


          public enum eVehicleStat
          {
               InRepair,
               Repaired,
               Paid
          }

          // New method - update flow chart 
          //****************Functionality******************//  
          public bool IsVehicleExistsInGarage(Vehicle i_VehicleToLook)
          {
               int vehicleToLookKey = i_VehicleToLook.GetHashCode();

               return Vehicles.ContainsKey(vehicleToLookKey) == true;
          }

          public eVehicleStat GetVehicleStatus(Vehicle i_VehicleToCheck)
          {

               if (IsVehicleExistsInGarage(i_VehicleToCheck) == true)
               {
                    int vehicleToCheckKey = i_VehicleToCheck.GetHashCode();

                    VehicleStatus.TryGetValue(vehicleToCheckKey, out eVehicleStat o_VehicleStat);

                    return o_VehicleStat;
               }
               else
               {
                    throw new KeyNotFoundException("No such vehicle in the garage");
               }

          }

          public string[] GetVehicleOwnersDetails(Vehicle i_VehicleToCheck)
          {
               if (IsVehicleExistsInGarage(i_VehicleToCheck) == true)
               {
                    int vehicleToCheckKey = i_VehicleToCheck.GetHashCode();


                    VehiclesInGarageDetails.TryGetValue(vehicleToCheckKey, out string[] o_OwnersDetails);

                    return o_OwnersDetails;
               }
               else
               {
                    throw new KeyNotFoundException("No such vehicle owner details in the garage");
               }

          }

          public bool tryToAddVehicle(Vehicle i_VehicleToAdd)
          {
               int vehicleToAddKey             = i_VehicleToAdd.GetHashCode();
               bool isCarHasBeingAddedToGarage = false;

               if (Vehicles.ContainsKey(vehicleToAddKey) == false)
               {
                    Vehicles.Add(vehicleToAddKey, i_VehicleToAdd);
                    VehicleStatus.Add(vehicleToAddKey, eVehicleStat.InRepair);
                    isCarHasBeingAddedToGarage = true;
               }

               return isCarHasBeingAddedToGarage;

          }

          //****************Properties******************//  
          public Dictionary<int, Vehicle> Vehicles
          {
               get
               {
                    return r_Vehicles;
               }

          }

          public Dictionary<int, string[]> VehiclesInGarageDetails
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

          public int CountProcessSteps
          {
               get
               {
                    return countProcessSteps;
               }
          }

     }
}

