using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Truck: Vehicle
     {
          private bool m_IsCarryingDangerousMaterials;
          private float m_CarryingSize;
          private static readonly  int sr_NumOfWheels = 16;
          private GasEngine m_Engine;
        public Truck(string i_LicenseNumber) : base(i_LicenseNumber)
          {
              for(int i = 0; i < sr_NumOfWheels; i++)
              {
                  Wheels.Add(new Wheel(28));
              }

              m_Engine.FuelType = GasEngine.eFuelType.Soler; 
              m_Engine.MaximumAmountOfFuelInLitters = 120;
        }
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

          public static bool IsCarryingSizeValid(float i_CarryingSize)
          {

              return i_CarryingSize > 0;

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
