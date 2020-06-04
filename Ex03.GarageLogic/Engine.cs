using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
          public abstract void UpdateEnergyLeftInPercents(Vehicle i_CurrentVehicle);
          public abstract bool IsAmountsOfSourcePowerMaterialValid(float i_MaterialToCheck);

    }

}
