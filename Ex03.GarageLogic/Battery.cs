using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Battery : Engine
    {
        private readonly string r_RemainingBatteryLifeInfoStr;
        private float m_RemainingBatteryLifeInHours;
        private float m_MaxBatteryLifeInHours;

        public Battery(float i_MaxBatteryLifeInHours)
        {
            m_MaxBatteryLifeInHours = i_MaxBatteryLifeInHours;
            r_RemainingBatteryLifeInfoStr = "remaining battery life in hours";
        }

        internal override void UpdateEnergyLeftInPercents(Vehicle i_CurrentVehicle)
        {
            i_CurrentVehicle.EnergyLeftInPercents = RemainingBatteryLifeInHours / MaxBatteryLifeInHours;
        }

        public override string ToString()
        {
            StringBuilder batteryStr = new StringBuilder();
            batteryStr.Append(string.Format("Energy left: {0}H out of {1}H", RemainingBatteryLifeInHours.ToString(), MaxBatteryLifeInHours.ToString()));
            return batteryStr.ToString();
        }

        public void Reload(float i_HoursToCharge, Vehicle io_VehicleToCharge)
        {
            InitializeAmountOfEnergy(i_HoursToCharge, io_VehicleToCharge);
        }

        internal override void InitializeAmountOfEnergy(float i_AmountOfInitialEnergy, Vehicle io_CurrentVehicle)
        {
            if (IsAmountsOfSourcePowerMaterialValid(i_AmountOfInitialEnergy))
            {
                RemainingBatteryLifeInHours += i_AmountOfInitialEnergy;
                UpdateEnergyLeftInPercents(io_CurrentVehicle);
            }
            else
            {
                throw new ValueOutOfRangeException(MaxBatteryLifeInHours - RemainingBatteryLifeInHours, 0, "Amount of source power not in limit");
            }
        }

        public override float GetAmountOfSourcePowerMaterialPossible()
        {
            return MaxBatteryLifeInHours - RemainingBatteryLifeInHours;
        }

        public override bool IsAmountsOfSourcePowerMaterialValid(float i_HoursToCharge)
        {
            return i_HoursToCharge <= m_MaxBatteryLifeInHours - m_RemainingBatteryLifeInHours && i_HoursToCharge >= 0;
        }

        public float RemainingBatteryLifeInHours
        {
            get
            {
                return m_RemainingBatteryLifeInHours;
            }

            set
            {
                if(value <= MaxBatteryLifeInHours)
                {
                    m_RemainingBatteryLifeInHours = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(
                        MaxBatteryLifeInHours - RemainingBatteryLifeInHours,
                        0,
                        "Amount of source power not in limit");
                }

            }
        }

        internal float MaxBatteryLifeInHours
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
                return r_RemainingBatteryLifeInfoStr;
            }
        }
    }
}
