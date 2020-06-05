using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Bike : Vehicle
     {
          private eLicenseType m_ELicenseType;
          private int m_EngineVelocity;
          private readonly string[] m_LicenseTypeStrings = { "A", "A1", "AA", "B" };

          public Bike(string i_LicenseNumber, Engine i_Engine) : base(i_Engine,i_LicenseNumber)
          {
               NumOfWheels = 2;
               ManageMemberInfo();
          }

          public override void ManageMemberInfo()
          {
              NumOfBaseMembers = NumOfWheels * 2 + 2;
              base.ManageMemberInfo();
              AddWheels();
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
          public override bool TryAssignMember(int i_NumOfField, string i_InputStr)
          {
               bool isMemberValid = false;

               if (i_NumOfField<NumOfBaseMembers)
               {
                   isMemberValid = base.TryAssignMember(i_NumOfField, i_InputStr);
               }
               else
               {
                   switch(i_NumOfField - NumOfBaseMembers)
                   {

                       case 0:

                           isMemberValid = IsLicenseTypeValid(i_InputStr);
                           if (isMemberValid == true)
                           {
                               AssignLicenseType(i_InputStr);
                           }
                           break;
                        
                       case 1:
                           isMemberValid = float.TryParse(i_InputStr, out float io_EngineVelocity) == true
                                               ? IsEngineVelocityValid(io_EngineVelocity)
                                               : false;
                           if (isMemberValid == true)
                           {
                               AssignEngineVelocity(i_InputStr);
                           }
                           break;
                }

               }

               return isMemberValid;

          }
          public void AssignLicenseType(string i_LicenseType)
          {
              if (IsLicenseTypeValid(i_LicenseType))
              {
                  m_ELicenseType = (eLicenseType)(Enum.Parse(typeof(eLicenseType), i_LicenseType));
              }
              else
              {
                  throw new FormatException("Incorrect license type");
              }
          }
        public bool IsLicenseTypeValid(string i_LicenseType)
          {
            bool isValid = false;
            foreach (string type in Enum.GetNames(typeof(eLicenseType)))
            {
                isValid = i_LicenseType.Equals(type);
                if (isValid == true)
                {
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


          void AssignEngineVelocity(string i_EngineVelocity)
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


          public string[] LicenseTypeStrings
          {
               get
               {
                    return m_LicenseTypeStrings;
               }

          }

     }

}
