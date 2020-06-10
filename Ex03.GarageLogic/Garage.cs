using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Garage
     {
          private readonly Dictionary<string, ClientCard> r_Vehicles = null;
          private readonly Dictionary<eVehicleStat, List<string>> r_VehicleStatus = null;

          public Garage()
          {
               r_Vehicles = new Dictionary<string, ClientCard>(); // <License number,Vehicle + owners info>
               r_VehicleStatus = new Dictionary<eVehicleStat, List<string>>(); // <Vehicle status, lisence number>
               r_VehicleStatus[eVehicleStat.InRepair] = new List<string>();
               r_VehicleStatus[eVehicleStat.Paid] = new List<string>();
               r_VehicleStatus[eVehicleStat.Repaired] = new List<string>();
          }

          public enum eVehicleStat
          {
               InRepair,
               Repaired,
               Paid
          }

          public static eVehicleStat GetStatusFromInt(int i_Status)
          {
               eVehicleStat statusToReturn;
               switch (i_Status)
               {
                    case 0:
                         statusToReturn = eVehicleStat.InRepair;
                         break;
                    case 1:
                         statusToReturn = eVehicleStat.Repaired;
                         break;
                    case 2:
                         statusToReturn = eVehicleStat.Paid;
                         break;
                    default:
                         throw new ValueOutOfRangeException(2, 0);
               }

               return statusToReturn;
          }

          public void ChangeVehicleStatus(ClientCard i_ClientToChange, eVehicleStat i_StatusToSet)
          {
               VehicleStatus[i_ClientToChange.Status].Remove(i_ClientToChange.VehicleInGarage.LicenseNum);
               VehicleStatus[i_StatusToSet].Add(i_ClientToChange.VehicleInGarage.LicenseNum);
               i_ClientToChange.Status = i_StatusToSet;
          }

          public void AddVehicleToGarage(ClientCard i_VehicleToAdd)
          {
               if (Clients.ContainsKey(i_VehicleToAdd.VehicleInGarage.LicenseNum) == false)
               {
                    Clients.Add(i_VehicleToAdd.VehicleInGarage.LicenseNum, i_VehicleToAdd);
                    VehicleStatus[i_VehicleToAdd.Status].Add(i_VehicleToAdd.VehicleInGarage.LicenseNum);
               }
          }

          public List<string> GetClientsByStatus(eVehicleStat i_Status)
          {
               return VehicleStatus[i_Status];
          }

          public bool TryToFindClient(string i_LicenseNum, out ClientCard o_Client)
          {
              bool isFound = Clients.TryGetValue(i_LicenseNum, out o_Client);
              return isFound;
          }

          public Dictionary<string, ClientCard> Clients
          {
               get
               {
                    return r_Vehicles;
               }
          }

          public Dictionary<eVehicleStat, List<string>> VehicleStatus
          {
               get
               {
                    return r_VehicleStatus;
               }
          }
     }
}