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

          //****************Validation Methods******************//  
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
                    }

               }

               return isMemberValid;

          }

          public bool IsLicenseTypeValid(string i_LicenseType, out eLicenseType o_LicenseType)
          {
               bool isValid = false;

               // Starting the type as initial -1 value
               o_LicenseType = (eLicenseType)(eLicenseType.A - 1);

               foreach (string type in m_LicenseTypeStrings)
               {
                    // as long as we didn't find a matching type
                    o_LicenseType++;

                    if (type.Equals(i_LicenseType) == true)
                    {
                         isValid = true;
                         break;
                    }

               }

               return isValid;
          }

          public bool IsEngineVelocityValid(float i_EngineVelocity)
          {
               return i_EngineVelocity > 0;
          }

          // New- update in flow chart
          //****************Assigning Methods******************//  
          void AssignLicenseType(string i_LicenseType)
          {
               if (IsLicenseTypeValid(i_LicenseType, out eLicenseType o_ELicenseType) == true)
               {
                    LicenseType = o_ELicenseType;         
               }
               else 
               {
                    throw new FormatException("Please enter only one of the following: A, A1, AA, B" + Environment.NewLine);
               }

          }

          void AssignmEngineVelocity(string i_EngineVelocity)
          {

               if (int.TryParse(i_EngineVelocity, out int io_EngineVelocity) == false)
               {
                    throw new FormatException("The Engine should be a whole number" + Environment.NewLine);
               }
               else if (IsEngineVelocityValid(io_EngineVelocity) == false)
               {
                    // Assuming maximal velocity of engine since not given 
                    throw new ValueOutOfRangeException(10000, 0, "Engine Velocity must be a positve whole number" + Environment.NewLine);
               }
               else
               {
                    EngineVelocity = io_EngineVelocity;
               }

          }

          //****************Properties******************//  
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
                    m_EngineVelocity = value;
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

          public string[] LicenseTypeStrings
          {
               get
               {
                    return m_LicenseTypeStrings;
               }

          }

     }

}
