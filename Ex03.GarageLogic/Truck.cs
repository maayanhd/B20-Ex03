using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Truck : Vehicle
     {
          private bool m_IsCarryingDangerousMaterials;
          private float m_CarryingSize;

          public Truck(string i_LicenseNumber, GasEngine i_GasEngine) : base(i_GasEngine,i_LicenseNumber)
          {
              NumOfWheels = 16;
              m_Engine = i_GasEngine;
              ((GasEngine)MyEngine).MyFuel.FuelType = Fuel.eFuelType.Soler;
              ((GasEngine)MyEngine).MaximumAmountOfFuelInLitters = 120;
              ManageMemberInfo();
          }
          public override string ToString()
          {
              StringBuilder truckStr = new StringBuilder(base.ToString());
              if(IsCarryingDangerousMaterials == true)
              {
                  truckStr.AppendLine("Is carrying dangerous materials");
              }
              else
              {
                  truckStr.AppendLine("Is not carrying dangerous materials");
              }
              truckStr.AppendLine(string.Format("Carrying size:{0}", CarryingSize.ToString()));


              return truckStr.ToString();
          }
        public override void ManageMemberInfo()
          {
               NumOfBaseMembers = NumOfWheels * 2 + 2;
               base.ManageMemberInfo();
               AddWheels();
               m_MemberInfoStr.Add("whether the truck carrying dangerous materials");
          }

          //****************Validations Methods******************//  
          public override bool TryAssignMember(int i_NumOfField, string i_InputStr)
          {
               bool isMemberValid = false;

               if (i_NumOfField < NumOfBaseMembers)
               {
                   isMemberValid = base.TryAssignMember(i_NumOfField, i_InputStr);
               }
                    
               switch (i_NumOfField - NumOfBaseMembers)
                    {
                         case 0:
                              isMemberValid = i_InputStr.Equals("Yes") == true || i_InputStr.Equals("No");
                              if (isMemberValid == true)
                              {
                                  AssignIsCarryingDangerousMaterials(i_InputStr);
                              }
                              break;
                         case 1:
                              isMemberValid = float.TryParse(i_InputStr, out float io_CarryingSize) == true ? IsCarryingSizeValid(io_CarryingSize) : false;
                              if(isMemberValid == true)
                              {
                                AssignCarryingSize(i_InputStr);
                              }
                              break;
                         case 2:
                              isMemberValid = float.TryParse(i_InputStr, out float io_AmountOfMaterial) == true ? ((GasEngine)MyEngine).IsAmountsOfSourcePowerMaterialValid(io_AmountOfMaterial) : false;
                              if (isMemberValid == true)
                              {
                                  (m_Engine as GasEngine).ReFuel(io_AmountOfMaterial, (m_Engine as GasEngine).MyFuel);
                              }
                              break;
                    }


               return isMemberValid;

          }

          public static bool IsCarryingSizeValid(float i_CarryingSize)
          {
              return i_CarryingSize > 0;
          }

          void AssignIsCarryingDangerousMaterials(string i_IsCarryingDangerousMaterials)
          {
               if (i_IsCarryingDangerousMaterials.Equals("Yes") == false && i_IsCarryingDangerousMaterials.Equals("No") == false)
               {
                    throw new FormatException("Please enter Yes or No only");
               }
               else
               {
                    IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials.Equals("Yes") == true;
               }

          }

          void AssignCarryingSize(string i_CarryingSize)
          {

               if (float.TryParse(i_CarryingSize, out float io_CarryingSize) == false)
               {
                    throw new FormatException("The Carrying size should be a decimal number");
               }
               else
               {
                    CarryingSize = io_CarryingSize;
               }

          }
          
          //****************Properties******************//  
          public bool IsCarryingDangerousMaterials
          {
               get
               {
                    return m_IsCarryingDangerousMaterials;
               }

               set
               {
                    m_IsCarryingDangerousMaterials = value;
               }

          }


          public float CarryingSize
          {
               get
               {
                    return m_CarryingSize;
               }

               set
               {
                    m_CarryingSize = value;
               }

          }



     }

}
