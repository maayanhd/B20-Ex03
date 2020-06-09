using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
          internal abstract void UpdateEnergyLeftInPercents(Vehicle i_CurrentVehicle);
          public abstract float GetAmountOfSourcePowerMaterialPossible();
          public abstract bool IsAmountsOfSourcePowerMaterialValid(float i_MaterialToCheck);
          internal abstract void InitializeAmountOfEnergy(float i_AmountOfInitialEnergy,Vehicle i_CurrentVehicle);

    }

}
