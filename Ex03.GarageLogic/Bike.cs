using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Bike:GasVehicle
     {
          private eLicenseType m_ELicenseType;
          private int m_EngineVelocity;
          
          // Optional
          private readonly string[] m_LicenseTypeStrings = { "A", "A1", "AA", "B" };

          public enum eLicenseType
          {
               A,
               A1,
               Aa,
               B 
          }

          public eLicenseType LicenseType
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
                    m_EngineVelocity=value;
               }

          }

          public string[] LicenseTypeStrings
          {
               get
               {
                    return m_LicenseTypeStrings;
               }

          }

          public static bool CheckEngineVelocityValidity(float i_EngineVelocity)
          {
               // Do we get a maximal value of engine velocity?
               return i_EngineVelocity > 0; 
          }

     }

}
