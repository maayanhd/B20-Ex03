using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Bike : Vehicle
     {
          private License m_BikeLicense;
          private int m_EngineVelocity;

          public Bike(string i_LicenseNumber, Engine i_Engine) : base(i_Engine,i_LicenseNumber)
        {
               m_BikeLicense = new License();
               m_NumOfWheels = 2;
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


          public override string ToString()
          {
              StringBuilder bikeStr = new StringBuilder(base.ToString());
              bikeStr.AppendLine(string.Format("License type:{0}", m_BikeLicense.ToString()));
              bikeStr.AppendLine(string.Format("Engine velocity:{0}", EngineVelocity.ToString()));
              return bikeStr.ToString();

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
                           isMemberValid = License.TryParse(i_InputStr,out m_BikeLicense);
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
                    throw new FormatException("The Engine should be a whole number");
               }
               else if (IsEngineVelocityValid(io_EngineVelocity) == false)
               {
                    // Assuming maximal velocity of engine since not given 
                    throw new ValueOutOfRangeException(10000, 0);
               }
               else
               {
                    EngineVelocity = io_EngineVelocity;
               }

          }

          //****************Properties******************//  
         

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
