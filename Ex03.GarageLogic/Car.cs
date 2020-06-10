using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private Color m_CarColor;
        private int m_NumOfDoors;

        public Car(string i_LicenseNumber, Engine i_Engine) : base(i_Engine, i_LicenseNumber)
        {
            m_CarColor = new Color();
            m_NumOfWheels = 4;
            ManageMemberInfo();
        }

        public override string ToString()
        {
            StringBuilder carStr = new StringBuilder(base.ToString());
            carStr.AppendLine(string.Format("Color: {0}", CarColor.ToString()));
            carStr.AppendLine(string.Format("Number of doors: {0}", NumOfDoors.ToString()));
            return carStr.ToString();
        }

        internal override void ManageMemberInfo()
        {
            NumOfBaseMembers = (NumOfWheels * 2) + 2;
            base.ManageMemberInfo();
            AddWheels(32);
            m_MemberInfoStr.Add("a color");
            m_MemberInfoStr.Add("number of doors");
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
                        isMemberValid = Color.TryParse(i_InputStr, out m_CarColor);
                        if (isMemberValid == false)
                        {
                            o_ErrorMsg = string.Format(
                                "Allowed colors:{0}",
                                Color.GetPossibleColorsStr());
                        }

                        break;
                    case 1:
                        isMemberValid = int.TryParse(i_InputStr, out int numOfDoors) == true
                                            ? IsNumOfDoorsValid(numOfDoors)
                                            : false;
                        if (isMemberValid == true)
                        {
                            AssignNumOfDoors(i_InputStr);
                        }
                        else
                        {
                            o_ErrorMsg = "A car must have: 2,3,4 or 5 doors";
                        }

                        break;
                }
            }

            return isMemberValid;
        }

        public bool IsNumOfDoorsValid(int i_NumOfDoors)
        {
            return i_NumOfDoors <= 5 && i_NumOfDoors >= 2;
        }

        public void AssignNumOfDoors(string i_NumOfDoors)
        {
            if (int.TryParse(i_NumOfDoors, out int numOfDoors) == false)
            {
                throw new FormatException("Please enter a whole number");
            }
            else if (IsNumOfDoorsValid(numOfDoors) == false)
            {
                throw new ValueOutOfRangeException(5, 2);
            }
            else
            {
                NumOfDoors = numOfDoors;
            }
        }

        public Color CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public int NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                m_NumOfDoors = value;
            }
        }

        public Engine CarEngine
        {
            get
            {
                return r_Engine;
            }
        }
    }
}
