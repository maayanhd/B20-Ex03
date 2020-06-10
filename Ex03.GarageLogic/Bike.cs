using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Bike : Vehicle
    {
        private License m_BikeLicense;
        private int m_EngineVelocity;

        public Bike(string i_LicenseNumber, Engine i_Engine) : base(i_Engine, i_LicenseNumber)
        {
            m_BikeLicense = new License();
            m_NumOfWheels = 2;
            ManageMemberInfo();
        }

        internal override void ManageMemberInfo()
        {
            NumOfBaseMembers = (NumOfWheels * 2) + 2;
            base.ManageMemberInfo();
            AddWheels(30);
            m_MemberInfoStr.Add("a license type");
            m_MemberInfoStr.Add("an engine Velocity");
        }

        public override string ToString()
        {
            StringBuilder bikeStr = new StringBuilder(base.ToString());
            bikeStr.AppendLine(string.Format("License type: {0}", m_BikeLicense.ToString()));
            bikeStr.AppendLine(string.Format("Engine velocity: {0}", EngineVelocity.ToString()));
            return bikeStr.ToString();
        }

        public override bool TryAssignMember(int i_NumOfField, string i_InputStr, out string o_ErrorMsg)
        {
            bool isMemberValid = false;
            o_ErrorMsg = null;
            if (i_NumOfField < NumOfBaseMembers)
            {
                isMemberValid = base.TryAssignMember(i_NumOfField, i_InputStr, out o_ErrorMsg);
            }
            else
            {
                switch (i_NumOfField - NumOfBaseMembers)
                {
                    case 0:
                        isMemberValid = License.TryParse(i_InputStr, out m_BikeLicense);
                        if (isMemberValid == false)
                        {
                            o_ErrorMsg = string.Format(
                                "Allowed types:{0}",
                                License.GetPossibleLicenseTypes());
                        }

                        break;

                    case 1:
                        isMemberValid = float.TryParse(i_InputStr, out float engineVelocity) == true
                                            ? IsEngineVelocityValid(engineVelocity)
                                            : false;
                        if (isMemberValid == true)
                        {
                            AssignEngineVelocity(i_InputStr);
                        }
                        else
                        {
                            o_ErrorMsg = "The value must be positive and below 2500";
                        }

                        break;
                }
            }

            return isMemberValid;
        }

        public bool IsEngineVelocityValid(float i_EngineVelocity)
        {
            return i_EngineVelocity > 0 && i_EngineVelocity < 2500;
        }

        public void AssignEngineVelocity(string i_EngineVelocity)
        {
            if (int.TryParse(i_EngineVelocity, out int engineVelocity) == false)
            {
                throw new FormatException("The Engine should be a whole number");
            }

            if (IsEngineVelocityValid(engineVelocity) == false)
            {
                // Assuming maximal velocity of engine since not given 
                throw new ValueOutOfRangeException(2500, 0);
            }

            EngineVelocity = engineVelocity;
        }

        internal int EngineVelocity
        {
            get
            {
                return m_EngineVelocity;
            }

            set
            {
                m_EngineVelocity = value;
            }
        }
    }
}
