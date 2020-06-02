﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class ElectricCar:ElectricVehicle
     {
          private Car.eColor m_EColor;
          private int m_NumOfDoors;

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
