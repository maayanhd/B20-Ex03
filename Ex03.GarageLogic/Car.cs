using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Car:GasVehicle
     {
          private eColor m_EColor;
          private int m_NumOfDoors;

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
