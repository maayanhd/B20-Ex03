using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Bike:Vehicle
     {
          private eLicenseType m_ELicenseType;
          private int m_EngineVelocity;

          private Engine m_Engine;
          private readonly string[] m_LicenseTypeStrings = { "A", "A1", "AA", "B" };

          public Bike(string i_LicenseNumber) : base(i_LicenseNumber)
          {
            Wheels.Add(new Wheel(30));
            Wheels.Add(new Wheel(30));

            m_MemberInfoStr.Add("A license type");
            m_MemberInfoStr.Add("An engine Velocity");
          }



        public enum eLicenseType
          {
               A,
               A1,
               Aa,
               B 
          }

        public bool IsLicenseTypeValid(string i_LicenseType)
        {
            bool isValid = false;
            foreach(string type in m_LicenseTypeStrings)
            {
                if(type.Equals(i_LicenseType) == true)
                {
                    isValid = true;
                    break;
                }
               
            }

            return isValid;
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
