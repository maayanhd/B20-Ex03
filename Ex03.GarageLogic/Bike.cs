using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Bike : Vehicle
     {
          private eLicenseType m_ELicenseType;
          private int m_EngineVelocity;

          private Engine m_Engine;
          private readonly string[] m_LicenseTypeStrings = { "A", "A1", "AA", "B" };

          public Bike(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber)
          {
               Wheels.Add(new Wheel(30));
               Wheels.Add(new Wheel(30));
               ManageMemberInfo();
          }

          public override void ManageMemberInfo()
          {
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

          public override bool IsCurrentMemberValid(int i_NumOfField, string i_InputStr)
          {
               bool isMemberValid = false;

               if (base.IsCurrentMemberValid(i_NumOfField, i_InputStr))
               {
                    // The number of cases of vehicle is 3 + 2 * numofwheels  

                    switch (i_NumOfField - (3 + 2 * this.Wheels.Count))
                    {
                         case 1:
                              isMemberValid = IsLicenseNumValid(i_InputStr);
                              break;
                         case 2:
                              isMemberValid = float.TryParse(i_InputStr, out float io_EngineVelocity) == true ? IsEngineVelocityValid(io_EngineVelocity) : false;
                              break;
                         case 3:
                              isMemberValid = float.TryParse(i_InputStr, out float io_AmountOfMaterial) == true ? BikeEngine.IsAmountsOfSourcePowerMaterialValid(io_AmountOfMaterial) : false;
                              break;
                         case 4:
                              isMemberValid = Wheels[io_NumOfWheelBasedOnField].IsManufactorerValid(i_InputStr);
                              break;
                         case 5:
                              isMemberValid = float.TryParse(i_InputStr, out float o_AirPressure) == true ? Wheels[io_NumOfWheelBasedOnField].IsAirPressureIsValid(o_AirPressure) : false;
                              break;
                    }

               }

               return isMemberValid;

          }


          public bool IsLicenseTypeValid(string i_LicenseType)
          {
               bool isValid = false;

               foreach (string type in m_LicenseTypeStrings)
               {
                    if (type.Equals(i_LicenseType) == true)
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

          public Engine BikeEngine
          {
               get
               {
                    return m_Engine;
               }

               set
               {
                    m_Engine = value;
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

          public string[] LicenseTypeStrings
          {
               get
               {
                    return m_LicenseTypeStrings;
               }

          }

          public static bool IsEngineVelocityValid(float i_EngineVelocity)
          {
               return i_EngineVelocity > 0;
          }

     }

}
