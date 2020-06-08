﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Battery : Engine
     {

          private float m_RemainingBatteryLifeInHours;
          private float m_MaxBatteryLifeInHours;
          private readonly string m_RemainingBatteryLifeInfoStr;

          public Battery(float i_MaxBatteryLifeInHours)
          {
               m_MaxBatteryLifeInHours = i_MaxBatteryLifeInHours;
               m_RemainingBatteryLifeInfoStr = "remaining battery life in hours";
          }

          //****************Functionality******************//  
          public override void UpdateEnergyLeftInPercents(Vehicle i_CurrentVehicle)
          {
               i_CurrentVehicle.EnergyLeftInPercents = RemainingBatteryLifeInHours / MaxBatteryLifeInHours;
          }
          public override string ToString()
          {
              StringBuilder batteryStr = new StringBuilder();
              batteryStr.Append(string.Format("Energy left: {0}H out of {1}H", RemainingBatteryLifeInHours.ToString(), MaxBatteryLifeInHours.ToString()));
              return batteryStr.ToString();
          }
        public void Reload(float i_HoursToCharge,Vehicle io_VehicleToCharge)
          {
               if (IsTotalAmountOfChargingWithinLimit(i_HoursToCharge) == false)
               {
                    throw new ValueOutOfRangeException(m_MaxBatteryLifeInHours - m_RemainingBatteryLifeInHours, 0);
               }
               else
               {
                    m_RemainingBatteryLifeInHours += i_HoursToCharge;
                    UpdateEnergyLeftInPercents(io_VehicleToCharge);
               }
          }
        public override void InitializeAmountOfEnergy(float i_AmountOfInitialEnergy,Vehicle io_CurrentVehicle)
        {
            if (IsAmountsOfSourcePowerMaterialValid(i_AmountOfInitialEnergy))
            {
                RemainingBatteryLifeInHours = i_AmountOfInitialEnergy;
                UpdateEnergyLeftInPercents(io_CurrentVehicle);
            }
            else
            {
                throw new ValueOutOfRangeException(MaxBatteryLifeInHours - RemainingBatteryLifeInHours, 0);
            }

        }
        public bool IsTotalAmountOfChargingWithinLimit(float i_HoursToCharge)
        {
            return i_HoursToCharge <= m_MaxBatteryLifeInHours - m_RemainingBatteryLifeInHours && i_HoursToCharge >= 0;
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

    
     }
}
