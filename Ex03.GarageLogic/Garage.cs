using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Garage
     {
          private Dictionary<int, Vehicle> m_Vehicles                  = null;
          private Dictionary<int, string[]> m_VehiclesOwnerDetails = null;
          private enumarations.eVehicleStatus[] m_EVehicleStatus       = null;
         
          public Dictionary<int, Vehicle> Vehicles
          {
               get
               {
                    return m_Vehicles;
               }

               set
               {
                    m_Vehicles = value;
               }

          }

          public Dictionary<Vehicle, string[]> VehiclesInGarageDetails
          {
               get
               {
                    return m_VehiclesOwnerDetails;
               }

               set
               {
                    m_VehiclesOwnerDetails=value;
                    
               }

          }

          public enumarations.eVehicleStatus eVehicleStatus
          {
               get
               {
                    return m_EVehicleStatus;
               }

               set
               {
                    m_EVehicleStatus = value;
               }
          }
     }

}
