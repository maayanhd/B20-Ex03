using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class GasVehicle: Vehicle
     {
          private eFuelType m_EFuelType;
          private float m_CurrentAmountOfFuelInLitters;
          private float m_MaximumAmountOfFuelInLitters;

          public void ReFuel(float i_FuelToAdd, eFuelType i_EFuelType)
          {
          
          }

          public enum eFuelType
          {
               Soler,
               Octan95,
               Octan96,
               Octan98
          }



     }
}
