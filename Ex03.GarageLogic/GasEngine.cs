using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class GasEngine : Engine
    {

        private eFuelType m_EFuelType;
        private float m_CurrentAmountOfFuelInLitters;
        private float m_MaximumAmountOfFuelInLitters;

        public GasEngine()
        {

        }
        public void ReFuel(float i_FuelToAdd, eFuelType i_EFuelType)
        {
            if (IsRefuelingPossible(i_FuelToAdd) == false)
            {
                throw new ValueOutOfRangeException(m_MaximumAmountOfFuelInLitters - m_CurrentAmountOfFuelInLitters, 0);
            }
            else if (i_EFuelType != m_EFuelType)
            {
                throw new ArgumentException("The fuel type is not matching the vehicle's fuel type");
            }
            else
            {
                m_CurrentAmountOfFuelInLitters += i_FuelToAdd;
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

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public bool IsRefuelingPossible(float i_FuelToAdd)
        {
            return i_FuelToAdd <= m_MaximumAmountOfFuelInLitters - m_CurrentAmountOfFuelInLitters;
        }

    }
}
