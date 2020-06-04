using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Truck : Vehicle
     {
          private bool m_IsCarryingDangerousMaterials;
          private float m_CarryingSize;
          private static readonly int sr_NumOfWheels = 16;
          private GasEngine m_Engine;

          public Truck(string i_LicenseNumber, GasEngine i_GasEngine) : base(i_LicenseNumber)
          {
               for (int i = 0; i < sr_NumOfWheels; i++)
               {
                    Wheels.Add(new Wheel(28));
               }

               m_Engine = i_GasEngine;
               m_Engine.FuelType = GasEngine.eFuelType.Soler;
               m_Engine.MaximumAmountOfFuelInLitters = 120;
               ManageMemberInfo();
          }

          public override void ManageMemberInfo()
          {
               r_MemberInfoStr.Add("whether the truck carrying dangerous materials");
               r_MemberInfoStr.Add("whether the truck carrying dangerous materials");
               r_MemberInfoStr.Add(m_Engine.CurrentAmountInfoStr);
          }

          //****************Validations Methods******************//  
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

          //****************Properties******************//  
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
