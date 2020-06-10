using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsCarryingDangerousMaterials;
        private float m_CarryingSize;

        public static bool IsCarryingSizeValid(float i_CarryingSize)
        {
            return i_CarryingSize > 0;
        }

        public Truck(string i_LicenseNumber, GasEngine i_GasEngine) : base(i_GasEngine, i_LicenseNumber)
        {
            m_NumOfWheels = 16;
            ((GasEngine)MyEngine).MyFuel.FuelType = Fuel.eFuelType.Soler;
            ((GasEngine)MyEngine).MaximumAmountOfFuelInLitters = 120;
            ManageMemberInfo();
        }

        public override string ToString()
        {
            StringBuilder truckStr = new StringBuilder(base.ToString());
            if (IsCarryingDangerousMaterials == true)
            {
                truckStr.AppendLine("Is carrying dangerous materials");
            }
            else
            {
                truckStr.AppendLine("Is not carrying dangerous materials");
            }

            truckStr.AppendLine(string.Format("Carrying size: {0} kg", CarryingSize.ToString()));

            return truckStr.ToString();
        }

        internal override void ManageMemberInfo()
        {
            NumOfBaseMembers = (NumOfWheels * 2) + 2;
            base.ManageMemberInfo();
            AddWheels(28);
            m_MemberInfoStr.Add("whether the truck carrying dangerous materials");
            m_MemberInfoStr.Add("carrying size of the truck");
        }

        public override bool TryAssignMember(int i_NumOfField, string i_InputStr, out string io_ErrorMsg)
        {
            bool isMemberValid = false;
            io_ErrorMsg = null;
            if (i_NumOfField < NumOfBaseMembers)
            {
                isMemberValid = base.TryAssignMember(i_NumOfField, i_InputStr, out io_ErrorMsg);
            }

            switch (i_NumOfField - NumOfBaseMembers)
            {
                case 0:
                    isMemberValid = i_InputStr.Equals("Yes") || i_InputStr.Equals("No");

                    if (isMemberValid == true)
                    {
                        AssignIsCarryingDangerousMaterials(i_InputStr);
                    }
                    else
                    {
                        io_ErrorMsg = "Your answer must be either: Yes or No";
                    }

                    break;
                case 1:
                    isMemberValid = float.TryParse(i_InputStr, out float io_CarryingSize) == true ? IsCarryingSizeValid(io_CarryingSize) : false;
                    if (isMemberValid == true)
                    {
                        AssignCarryingSize(i_InputStr);
                    }
                    else
                    {
                        io_ErrorMsg = "The value must be a positive number";
                    }

                    break;
            }

            return isMemberValid;
        }

        public void AssignIsCarryingDangerousMaterials(string i_IsCarryingDangerousMaterials)
        {
            if (i_IsCarryingDangerousMaterials.Equals("Yes") == false && i_IsCarryingDangerousMaterials.Equals("No") == false)
            {
                throw new FormatException("Please enter Yes or No only");
            }
            else
            {
                IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials.Equals("Yes") == true;
            }
        }

        public void AssignCarryingSize(string i_CarryingSize)
        {
            if (float.TryParse(i_CarryingSize, out float io_CarryingSize) == false)
            {
                throw new FormatException("The Carrying size should be a decimal number");
            }
            else
            {
                CarryingSize = io_CarryingSize;
            }
        }

        public bool IsCarryingDangerousMaterials
        {
            get
            {
                return m_IsCarryingDangerousMaterials;
            }

            set
            {
                m_IsCarryingDangerousMaterials = value;
            }
        }

        public float CarryingSize
        {
            get
            {
                return m_CarryingSize;
            }

            set
            {
                m_CarryingSize = value;
            }
        }
    }
}
