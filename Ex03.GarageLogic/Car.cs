using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Car : Vehicle
     {
         private eColor r_EColor;

          private int m_NumOfDoors;

          public Car(string i_LicenseNumber, Engine i_Engine) : base(i_Engine,i_LicenseNumber)
          {
            NumOfWheels = 4;
            ManageMemberInfo();
            m_Engine = i_Engine;
          }


          public override string ToString()
          {
            StringBuilder carStr = new StringBuilder(base.ToString());
            carStr.AppendLine(string.Format("Color:{0}",EColor.ToString()));
            carStr.AppendLine(string.Format("Number of doors:{0}", NumOfDoors.ToString()));
            return carStr.ToString();
          }
          public override void ManageMemberInfo()
          {
               NumOfBaseMembers = NumOfWheels * 2 + 2;
               base.ManageMemberInfo();
               AddWheels();
               m_MemberInfoStr.Add("A color");
               m_MemberInfoStr.Add("Number of doors");
          }
          

          //****************Validation Methods******************//  
          public override bool TryAssignMember(int i_NumOfField, string i_InputStr)
          {
               bool isMemberValid = false;

               if(i_NumOfField < NumOfBaseMembers)
               {
                   isMemberValid = base.TryAssignMember(i_NumOfField, i_InputStr);
               }
               else
               {
                       switch(i_NumOfField - NumOfBaseMembers)
                       {
                           case 0:
                               isMemberValid = IsColorValid(i_InputStr);
                               if(isMemberValid == true)
                               {
                                   AssignColor(i_InputStr);
                               }

                               break;
                           case 1:
                               isMemberValid = int.TryParse(i_InputStr, out int io_NumOfDoors) == true
                                                   ? IsNumOfDoorsValid(io_NumOfDoors)
                                                   : false;
                               if(isMemberValid == true)
                               {
                                   AssignNumOfDoors(i_InputStr);
                               }

                               break;
                           case 2:
                               isMemberValid = float.TryParse(i_InputStr, out float io_AmountOfMaterial) == true
                                                   ? CarEngine.IsAmountsOfSourcePowerMaterialValid(io_AmountOfMaterial)
                                                   : false;
                               if(isMemberValid == true)
                               {
                                   if(m_Engine is GasEngine)
                                   {
                                       (m_Engine as GasEngine).ReFuel(
                                           io_AmountOfMaterial,
                                           (m_Engine as GasEngine).FuelType);
                                   }
                                   else
                                   {
                                       (m_Engine as Battery).Reload(io_AmountOfMaterial);
                                   }
                               }

                               break;
                       }

               }
               return isMemberValid;

          }
          
          // new method to update flow chart
          public bool IsColorValid(string i_ColorString)
          {
              bool isValid = false;
              foreach(string color in Enum.GetNames(typeof(eColor)))
              {
                  isValid = i_ColorString.Equals(color);
                  if(isValid == true)
                  {
                      break;
                  }
              }

              return isValid;
          }
              

          public bool IsNumOfDoorsValid(int i_NumOfDoors)
          {
               return i_NumOfDoors <= 5 && i_NumOfDoors >= 2;
          }

          //****************Enumerations******************//  
          public enum eColor
          {
               Red,
               White,
               Black,
               Silver
          }

          // New- update in flow chart
          //****************Assigning Methods******************//  
          public void AssignNumOfDoors(string i_NumOfDoors)
          {
              int numOfDoors=0;
               if (int.TryParse(i_NumOfDoors, out numOfDoors) ==false)
               {
                    throw new FormatException("Please enter a whole number" + Environment.NewLine);
               }
               else if (IsNumOfDoorsValid(numOfDoors)==false)
               {
                    throw new ValueOutOfRangeException(2, 5, "the number of doors must be a whole number from 2 to 5" + Environment.NewLine);
               }
               else
               {
                    NumOfDoors = numOfDoors;
               }
               
          }

          public void AssignColor(string i_Color)
          {
              if(IsColorValid(i_Color))
              {
                  r_EColor = (eColor)(Enum.Parse(typeof(eColor), i_Color));
              }
              else
              {
                  throw  new FormatException("Color not found");
              }
          }
          
          //****************Properties******************//  
          public eColor EColor
          {
               get
               {
                    return r_EColor;
               }
               set
               {
                   r_EColor = value;
               }

          }

          public int NumOfDoors
          {
               get
               {
                    return m_NumOfDoors;
               }

               set
               {
                    m_NumOfDoors = value;
               }

          }
                    
          public string[] ColorStrings
          {
               get
               {
                    return r_ColorStrings;
               }

          }

          public Engine CarEngine
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

     }

}
