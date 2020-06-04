using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Car : Vehicle
     {
          private eColor m_EColor;
          private int m_NumOfDoors;
          private Engine m_Engine;
          private static readonly int sr_NumOfWheels = 4;

          public Car(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber)
          {
               for (int i = 0; i < sr_NumOfWheels; i++)
               {
                    Wheels.Add(new Wheel(32));
               }

               m_Engine = i_Engine;
               ManageMemberInfo();
          }

          public override void ManageMemberInfo()
          {
               m_MemberInfoStr.Add("A color");
               m_MemberInfoStr.Add("Number of doors");
               manageMemberEngineInfoStr();
               m_MemberInfoStr.Add("wheel's manufacturer");
               m_MemberInfoStr.Add("current air pressure in wheel");
          }

          public void manageMemberEngineInfoStr()
          {
               GasEngine gasEngine = m_Engine as GasEngine;
               ElectricEngine electricEngine = m_Engine as ElectricEngine;

               if (gasEngine != null)
               {
                    m_MemberInfoStr.Add(gasEngine.CurrentAmountInfoStr);
               }

               if (electricEngine != null)
               {
                    m_MemberInfoStr.Add(electricEngine.RemainingBatteryLifeInfoStr);
               }

          }

          //****************Validation Methods******************//  
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

          public eColor EColor
          {
               get
               {
                    return m_EColor;
               }

               set
               {
                    m_EColor = value;
               }

          }
                   
     }

}
