using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {

        private float m_RemainingBatteryLifeInHours;
        private float m_MaxBatteryLifeInHours;

        public ElectricEngine()
        {
        }
        public void Reload(int i_HoursToCharge)
        {
            if (IsChargingPossible(i_HoursToCharge) == false)
            {
                throw new ValueOutOfRangeException(m_MaxBatteryLifeInHours - m_RemainingBatteryLifeInHours, 0);
            }
            else
            {
                m_RemainingBatteryLifeInHours += i_HoursToCharge;
            }
        }

        protected float MaxBatteryLifeInHours
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
        public bool IsChargingPossible(int i_HoursToCharge)
        {
            return i_HoursToCharge <= m_MaxBatteryLifeInHours - m_RemainingBatteryLifeInHours;
        }
    }
}
