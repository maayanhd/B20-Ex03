using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class GasEngine : Engine
     {

          private eFuelType m_EFuelType;
          private float m_CurrentAmountOfFuelInLitters;
          private float m_MaximumAmountOfFuelInLitters;
          private readonly string m_CurrentAmountInfoStr;

          public GasEngine(float i_MaximumAmountOfFuelInLitters, eFuelType i_EFuelType)
          {
               m_EFuelType = i_EFuelType;
               m_MaximumAmountOfFuelInLitters = i_MaximumAmountOfFuelInLitters;
               m_CurrentAmountInfoStr = "current amount of fuel in litters";
          }

          public override string ToString()
          {
            StringBuilder gasEngineStr = new StringBuilder();
            gasEngineStr.AppendLine(string.Format("Fuel type: {0}", FuelType.ToString()));
            gasEngineStr.AppendLine(string.Format("Amount of fuel:{0}L from {1}L", CurrentAmountOfFuelInLitters.ToString(),MaximumAmountOfFuelInLitters.ToString()));
            return gasEngineStr.ToString();
          }
       //****************Functionality******************//  
       public void ReFuel(float i_FuelToAdd, eFuelType i_EFuelType)
          {
               if (IsTotalAmountOfFuelWithinLimit(i_FuelToAdd) == false)
               {
                    throw new ValueOutOfRangeException(m_MaximumAmountOfFuelInLitters - m_CurrentAmountOfFuelInLitters, 0, "You exceeded the amount of fuel to fill a full tank" + Environment.NewLine);
               }
               else if (i_EFuelType != m_EFuelType)
               {
                    throw new ArgumentException("The fuel type is not matching the vehicle's fuel type"+Environment.NewLine);
               }
               else
               {
                    m_CurrentAmountOfFuelInLitters += i_FuelToAdd;
               }

          }

          public override void UpdateEnergyLeftInPercents(Vehicle i_CurrentVehicle)
          {
               i_CurrentVehicle.EnergyLeftInPercents = CurrentAmountOfFuelInLitters / MaximumAmountOfFuelInLitters;
          }

          //**************Validation Methods***************//  
          public override bool IsAmountsOfSourcePowerMaterialValid(float i_MaterialToCheck)
          {
               return IsTotalAmountOfFuelWithinLimit(i_MaterialToCheck);
          }

          public bool IsTotalAmountOfFuelWithinLimit(float i_FuelToAdd)
          {
               return i_FuelToAdd <= m_MaximumAmountOfFuelInLitters - m_CurrentAmountOfFuelInLitters;
          }
                   
          //****************Properties*******************//  
          public eFuelType FuelType
          {
               get
               {
                    return m_EFuelType;
               }

               set
               {
                    m_EFuelType = value;
               }

          }

          public float CurrentAmountOfFuelInLitters
          {
               get
               {
                    return m_CurrentAmountOfFuelInLitters;
               }

               set
               {
                    CurrentAmountOfFuelInLitters = value;
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

          public string CurrentAmountInfoStr
          {
               get
               {
                    return m_CurrentAmountInfoStr;
               }

          }

          //****************Enumeration******************//  
          public enum eFuelType
          {
               Soler,
               Octan95,
               Octan96,
               Octan98
          }

     }
}
