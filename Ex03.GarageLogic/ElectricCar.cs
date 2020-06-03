using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class ElectricCar:ElectricVehicle
     {
          private Car.eColor m_EColor;
          private int m_NumOfDoors;

          private static readonly int sr_NumOfWheels = 4;
        public ElectricCar(string i_LicenseNumber) : base(i_LicenseNumber)
        {
            for (int i = 0; i < sr_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(32));
            }
            MaxBatteryLifeInHours = (float)2.1;

            m_MemberInfoStr.Add("A color");
            m_MemberInfoStr.Add("Number of doors");
        }
        public Car.eColor EColor
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

     }
     
}
