using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class ElectricEngine : Engine
     {

          private float m_RemainingBatteryLifeInHours;
          private float m_MaxBatteryLifeInHours;
          private readonly string m_RemainingBatteryLifeInfoStr;

          public ElectricEngine(float i_MaxBatteryLifeInHours)
          {
               i_MaxBatteryLifeInHours = m_MaxBatteryLifeInHours;
               m_RemainingBatteryLifeInfoStr = "remaining battery life in hours";
          }

          //****************Functionality******************//  
          public override void UpdateEnergyLeftInPercents(Vehicle i_CurrentVehicle)
          {
               i_CurrentVehicle.EnergyLeftInPercents = RemainingBatteryLifeInHours / MaxBatteryLifeInHours;
          }

          public void Reload(int i_HoursToCharge)
          {
               if (IsTotalAmountOfChargingWithinLimit((float)i_HoursToCharge) == false)
               {
                    throw new ValueOutOfRangeException(m_MaxBatteryLifeInHours - m_RemainingBatteryLifeInHours, 0);
               }
               else
               {
                    m_RemainingBatteryLifeInHours += i_HoursToCharge;
               }
          }

          public override bool IsAmountsOfSourcePowerMaterialValid(float i_MaterialToCheck)
          {
               return IsTotalAmountOfChargingWithinLimit(i_MaterialToCheck);
          }

          //****************Properties******************//  

          public float RemainingBatteryLifeInHours
          {
               get
               {
                    return m_RemainingBatteryLifeInHours;
               }

               set
               {
                    m_RemainingBatteryLifeInHours = value;
               }
               
          }

          public float MaxBatteryLifeInHours
          {
               get
               {
                    return m_MaxBatteryLifeInHours;
               }
               set
               {
                    m_MaxBatteryLifeInHours = value;
               }

          }

          public string RemainingBatteryLifeInfoStr
          {
               get
               {
                    return m_RemainingBatteryLifeInfoStr;
               }
               
          }

          //****************Validation Methods******************//  
          public bool IsTotalAmountOfChargingWithinLimit(float i_HoursToCharge)
          {
               return i_HoursToCharge <= m_MaxBatteryLifeInHours - m_RemainingBatteryLifeInHours;
          }
     }
}
