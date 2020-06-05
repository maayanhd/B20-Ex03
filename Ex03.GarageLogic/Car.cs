using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Car : Vehicle
     {
          // new access modifier to update flow chart
          private readonly eColor r_EColor;

          private int m_NumOfDoors;
          private Engine m_Engine;
          private static readonly int sr_NumOfWheels = 4;

          // new field to update flow chart
          private readonly string[] r_ColorStrings = {"Red", "White", "Black", "Silver"};  

          public Car(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber)
          {
               ManageMemberInfo();

               for (int i = 0; i < sr_NumOfWheels; i++)
               {
                    Wheels.Add(new Wheel(32));
               }

               m_Engine = i_Engine;
          }

          public override void ManageMemberInfo()
          {
               base.ManageMemberInfo();
               m_MemberInfoStr.Add("A color");
               m_MemberInfoStr.Add("Number of doors");
               manageEngineMemberInfoStr();
               m_MemberInfoStr.Add("wheel's manufacturer");
               m_MemberInfoStr.Add("current air pressure in wheel");
          }

          public void manageEngineMemberInfoStr()
          {
               GasEngine gasEngine = m_Engine as GasEngine;
               Battery battery = m_Engine as Battery;

               if (gasEngine != null)
               {
                    m_MemberInfoStr.Add(gasEngine.CurrentAmountInfoStr);
               }

               if (battery != null)
               {
                    m_MemberInfoStr.Add(battery.RemainingBatteryLifeInfoStr);
               }

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
                              isMemberValid = IsColorValid(i_InputStr);
                              break;
                         case 2:
                              isMemberValid = int.TryParse(i_InputStr, out int io_NumOfDoors) == true ? IsNumOfDoorsValid(io_NumOfDoors) : false;
                              break;
                         case 3:
                              isMemberValid = float.TryParse(i_InputStr, out float io_AmountOfMaterial) == true ? CarEngine.IsAmountsOfSourcePowerMaterialValid(io_AmountOfMaterial) : false;
                              break;
                    }

               }

               return isMemberValid;

          }
          
          // new method to update flow chart
          public bool IsColorValid(string ColorString)
          {
               return ColorString.Equals(ColorStrings[(int)EColor]);
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
          void AssignNumOfDoors(string i_NumOfDoors)
          {
               if (int.TryParse(i_NumOfDoors, out int io_numOfDoors)==false)
               {
                    throw new FormatException("Please enter a whole number" + Environment.NewLine);
               }
               else if (IsNumOfDoorsValid(io_numOfDoors))
               {
                    throw new ValueOutOfRangeException(2, 5, "the number of doors must be a whole number from 2 to 5" + Environment.NewLine);
               }
               else
               {
                    NumOfDoors = io_numOfDoors;
               }
               
          }

          //****************Properties******************//  
          public eColor EColor
          {
               get
               {
                    return r_EColor;
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
                    NumOfDoors = value;
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
