using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Garage
     {
          private readonly Dictionary<string, OrderInfo> r_Vehicles = null;
          private readonly Dictionary<eVehicleStat, string> r_VehicleStatus = null;

          //New- update flow chart
          public static int countProcessSteps = 1;

          public Garage()
          {
               r_Vehicles = new Dictionary<string, OrderInfo>(); // <License number,Vehicle + owners info>
               r_VehicleStatus = new Dictionary<eVehicleStat, string>(); // <Vehicle status, lisence number>

          }

          public enum eVehicleStat
          {
              InRepair,
              Repaired,
              Paid
          }

          public void AddVehicleToGarage(OrderInfo i_VehicleToAdd)
          {

              if(Vehicles.ContainsKey(i_VehicleToAdd.VehicleInGarage.LicenseNum) == false)
              {
                  Vehicles.Add(i_VehicleToAdd.VehicleInGarage.LicenseNum, i_VehicleToAdd);
                  VehicleStatus.Add(i_VehicleToAdd.Status,i_VehicleToAdd.VehicleInGarage.LicenseNum);
              }
          }
        //****************Functionality******************//  
          public bool IsVehicleExistsInGarage(string i_LicenseNumber)
          {
              return Vehicles.ContainsKey(i_LicenseNumber) == true;
          }
        
        

          //****************Properties******************//  
          public Dictionary<string, OrderInfo> Vehicles
          {
               get
               {
                    return r_Vehicles;
               }

          }
        

          public Dictionary<eVehicleStat, string> VehicleStatus
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

