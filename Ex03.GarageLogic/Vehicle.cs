using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly Engine r_Engine;
        protected readonly List<Wheel> r_Wheels;
        protected readonly string r_LicenseNum;
        protected string m_Model;
        protected float m_EnergyLeftInPercents;
        protected int m_NumOfWheels;
        protected List<string> m_MemberInfoStr;
        protected int m_NumOfBaseMembers;

        protected Vehicle(Engine i_Engine, string i_LicenseNumber)
        {
            r_Engine = i_Engine;
            m_MemberInfoStr = new List<string>();
            r_LicenseNum = i_LicenseNumber;
            r_Wheels = new List<Wheel>();
        }

        internal virtual void ManageMemberInfo()
        {
            m_MemberInfoStr.Add("a model");
            ManageEngineMemberInfoStr();
        }

        internal void ManageEngineMemberInfoStr()
        {
            GasEngine gasEngine = r_Engine as GasEngine;
            Battery battery = r_Engine as Battery;

            if (gasEngine != null)
            {
                m_MemberInfoStr.Add(gasEngine.CurrentAmountInfoStr);
            }

            if (battery != null)
            {
                m_MemberInfoStr.Add(battery.RemainingBatteryLifeInfoStr);
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleStr = new StringBuilder(string.Format(
                "License number:{0}{1}Model: {2}{1}",
                LicenseNum,
                Environment.NewLine,
                Model));

            for (int i = 0; i < Wheels.Count; i++)
            {
                vehicleStr.AppendLine(string.Format("Wheel {0}: ", (i + 1).ToString()));
                vehicleStr.Append(Wheels[i].ToString());
            }

            vehicleStr.Append(MyEngine.ToString());
            vehicleStr.AppendLine(string.Format("({0:P})", EnergyLeftInPercents));

            return vehicleStr.ToString();
        }

        public virtual bool TryAssignMember(int i_NumOfField, string i_InputStr, out string io_ErrorMsg)
        {
            bool isMemberValid = false;
            int indexOfWheelBasedOnField = i_NumOfField;
            io_ErrorMsg = null;
            i_NumOfField = GetIndexOfWheelToValidate(i_NumOfField, ref indexOfWheelBasedOnField);

            switch (i_NumOfField)
            {
                case 0:
                    isMemberValid = IsModelValid(i_InputStr);
                    if (isMemberValid == true)
                    {
                        Model = i_InputStr;
                    }
                    else
                    {
                        io_ErrorMsg = "The model must contain letters or digits only";
                    }

                    break;
                case 1:
                    isMemberValid = float.TryParse(i_InputStr, out float io_AmountOfMaterial) == true ? r_Engine.IsAmountsOfSourcePowerMaterialValid(io_AmountOfMaterial) : false;
                    if (isMemberValid == true)
                    {
                        MyEngine.InitializeAmountOfEnergy(io_AmountOfMaterial, this);
                    }
                    else
                    {
                        io_ErrorMsg = string.Format(
                            "The value must be positive and below {0}",
                            r_Engine.GetAmountOfSourcePowerMaterialPossible().ToString());
                    }

                    break;
                case 2:
                    isMemberValid = Wheels[indexOfWheelBasedOnField].IsManufacturerValid(i_InputStr);
                    if (isMemberValid == true)
                    {
                        Wheels[indexOfWheelBasedOnField].Manufacturor = i_InputStr;
                    }
                    else
                    {
                        io_ErrorMsg = "The value must contain letter only";
                    }

                    break;
                case 3:
                    isMemberValid = float.TryParse(i_InputStr, out float o_AirPressure) == true ? Wheels[indexOfWheelBasedOnField].IsAirPressureIsValid(o_AirPressure) : false;
                    if (isMemberValid == true)
                    {
                        Wheels[indexOfWheelBasedOnField].Inflate(o_AirPressure);
                    }
                    else
                    {
                        io_ErrorMsg = string.Format(
                            "The value must be positive and below {0}",
                            Wheels[indexOfWheelBasedOnField].GetAmountOfPressurePossibleToInflate().ToString());
                    }

                    break;
            }

            return isMemberValid;
        }

        internal int GetIndexOfWheelToValidate(int i_CaseNum, ref int io_NumOfWheelBasedOnField)
        {
            if (i_CaseNum >= 2 && i_CaseNum < NumOfBaseMembers)
            {
                i_CaseNum = i_CaseNum % 2 == 0 ? 2 : 3;
                io_NumOfWheelBasedOnField = (io_NumOfWheelBasedOnField - 2) / 2;
            }

            return i_CaseNum;
        }

        public bool IsModelValid(string i_Model)
        {
            bool isValid = false;
            if (i_Model.Length != 0)
            {
                foreach (char ch in i_Model)
                {
                    isValid = char.IsLetterOrDigit(ch);
                    if (isValid == false)
                    {
                        break;
                    }
                }
            }

            return isValid;
        }

        internal void AddWheels(int i_MaxWheelPressure)
        {
            for (int i = 0; i < NumOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_MaxWheelPressure));
                m_MemberInfoStr.Add(string.Format(
                    "{0} wheel's manufacturer",
                    i + 1));
                m_MemberInfoStr.Add(string.Format(
                    "current air pressure in wheel {0}",
                    i + 1));
            }
        }

        public override int GetHashCode()
        {
            return int.Parse(r_LicenseNum);
        }

        public override bool Equals(object i_obj)
        {
            Vehicle vehicleToCompare = i_obj as Vehicle;
            bool isEqual = false;

            if (vehicleToCompare != null)
            {
                isEqual = GetHashCode().Equals(vehicleToCompare.GetHashCode());
            }
            else
            {
                throw new ArgumentException();
            }

            return isEqual;
        }

        public string LicenseNum
        {
            get
            {
                return r_LicenseNum;
            }
        }

        public Engine MyEngine
        {
            get
            {
                return r_Engine;
            }
        }

        public string Model
        {
            get
            {
                return m_Model;
            }

            set
            {
                if (IsModelValid(value) == true)
                {
                    m_Model = value;
                }
                else
                {
                    throw new FormatException("The Model should consist of only letters and digits");
                }
            }
        }

        public int NumOfWheels
        {
            get
            {
                return m_NumOfWheels;
            }
        }

        internal int NumOfBaseMembers
        {
            get
            {
                return m_NumOfBaseMembers;
            }

            set
            {
                m_NumOfBaseMembers = value;
            }
        }

        internal float EnergyLeftInPercents
        {
            get
            {
                return m_EnergyLeftInPercents;
            }

            set
            {
                m_EnergyLeftInPercents = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return r_Wheels;
            }
        }

        public List<string> MemberInfoStrings
        {
            get
            {
                return m_MemberInfoStr;
            }
        }
    }
}
