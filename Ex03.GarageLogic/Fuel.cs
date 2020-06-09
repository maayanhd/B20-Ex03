using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel
    {
        private eFuelType m_EFuelType;

        public static bool TryParse(string i_FuelTypeStr, out Fuel o_Fuel)
        {
            o_Fuel = null;
            bool isValid = false;
            foreach (string type in Enum.GetNames(typeof(eFuelType)))
            {
                isValid = i_FuelTypeStr.Equals(type);
                if (isValid == true)
                {
                    o_Fuel = new Fuel((eFuelType)Enum.Parse(typeof(eFuelType), i_FuelTypeStr));
                    break;
                }
            }

            return isValid;
        }

        public Fuel(eFuelType i_EFuelType)
        {
            FuelType = i_EFuelType;
        }

        public Fuel()
        {
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
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

        public bool Equals(Fuel i_FuelToCompare)
        {
            return this.FuelType == i_FuelToCompare.FuelType;
        }

        public override string ToString()
        {
            return FuelType.ToString();
        }
    }
}
