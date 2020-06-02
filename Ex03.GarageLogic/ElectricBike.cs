using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class ElectricBike : ElectricVehicle
     {
          private Bike.eLicenseType m_ELicenseType;
          private int m_EngineVelocity;

          public Bike.eLicenseType ELicenseType
          {
               get
               {
                    return m_ELicenseType;
               }

               set
               {
                    m_ELicenseType = value;
               }

          }

          public int EngineVelocity
          {
               get
               {
                    return m_EngineVelocity;
               }

               set
               {
                    m_EngineVelocity = value;

               }

          }

     }
     
}
