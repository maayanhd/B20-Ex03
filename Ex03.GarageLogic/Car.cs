using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Car:Vehicle
     {
         private eColor m_EColor;
         private int m_NumOfDoors;

         private Engine m_Engine;
         private static readonly int sr_NumOfWheels = 4;
        public Car(string i_LicenseNumber) : base(i_LicenseNumber)
        {
            for (int i = 0; i < sr_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(32));
            }

            m_MemberInfoStr.Add("A color");
            m_MemberInfoStr.Add("Number of doors");
        }


        public enum eColor
          {
               Red,
               White,
               Black,
               Silver
          }

          public bool IsNumOfDoorsValid(int i_NumOfDoors)
          {
              return i_NumOfDoors <= 5 && i_NumOfDoors >= 2;
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
