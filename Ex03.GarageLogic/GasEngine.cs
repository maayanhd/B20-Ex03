using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class GasEngine : Engine
     {
          private readonly Fuel m_Fuel;
          private float m_CurrentAmountOfFuelInLitters;
          private float m_MaximumAmountOfFuelInLitters;
          private readonly string m_CurrentAmountInfoStr;

          public GasEngine(float i_MaximumAmountOfFuelInLitters, Fuel i_Fuel)
          {
               m_Fuel = i_Fuel;
               m_MaximumAmountOfFuelInLitters = i_MaximumAmountOfFuelInLitters;
               m_CurrentAmountInfoStr = "current amount of fuel in litters";
          }

          public override string ToString()
          {
            StringBuilder gasEngineStr = new StringBuilder();
            gasEngineStr.AppendLine(string.Format("Fuel type: {0}", MyFuel.ToString()));
            gasEngineStr.Append(string.Format("Amount of fuel: {0}L out of {1}L", CurrentAmountOfFuelInLitters.ToString(),MaximumAmountOfFuelInLitters.ToString()));
            return gasEngineStr.ToString();
          }

          public void ReFuel(float i_FuelToAdd, Fuel i_FuelToFill,Vehicle io_VehicleToRefuel)
          {

               if (i_FuelToFill.FuelType != MyFuel.FuelType)
               {
                    throw new ArgumentException("The fuel type is not matching the vehicle's fuel type");
               }
               else
               {
                    InitializeAmountOfEnergy(i_FuelToAdd+CurrentAmountOfFuelInLitters,io_VehicleToRefuel);
               }

          }

          internal override void InitializeAmountOfEnergy(float i_AmountOfInitialEnergy,Vehicle io_CurrentVehicle)
          {
              if(IsAmountsOfSourcePowerMaterialValid(i_AmountOfInitialEnergy))
              {
                  CurrentAmountOfFuelInLitters = i_AmountOfInitialEnergy;
                  UpdateEnergyLeftInPercents(io_CurrentVehicle);
              }
              else
              {
                  throw new ValueOutOfRangeException(m_MaximumAmountOfFuelInLitters - m_CurrentAmountOfFuelInLitters, 0, "Amount of source power not in limit");
              }

          }

          public override float GetAmountOfSourcePowerMaterialPossible()
          {
              return MaximumAmountOfFuelInLitters - CurrentAmountOfFuelInLitters;
          }

          internal override void UpdateEnergyLeftInPercents(Vehicle i_CurrentVehicle)
          {
               i_CurrentVehicle.EnergyLeftInPercents = CurrentAmountOfFuelInLitters / MaximumAmountOfFuelInLitters;
          }

          public override bool IsAmountsOfSourcePowerMaterialValid(float i_FuelToAdd)
          {
            return i_FuelToAdd <= m_MaximumAmountOfFuelInLitters - m_CurrentAmountOfFuelInLitters && i_FuelToAdd >= 0;
          }

          public float CurrentAmountOfFuelInLitters
          {
               get
               {
                    return m_CurrentAmountOfFuelInLitters;
               }

               set
               {
                    m_CurrentAmountOfFuelInLitters = value;
               }

          }

          public float MaximumAmountOfFuelInLitters
          {
               get
               {
                    return m_MaximumAmountOfFuelInLitters;
               }

               set
               {
                    m_MaximumAmountOfFuelInLitters = value;
               }

          }

          public Fuel MyFuel
          {
              get
              {
                  return m_Fuel;
              }

          }

          public string CurrentAmountInfoStr
          {
               get
               {
                    return m_CurrentAmountInfoStr;
               }

          }

     }
}
