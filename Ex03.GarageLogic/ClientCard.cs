using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ClientCard
    {

        private Vehicle m_VehicleInGarage;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private Garage.eVehicleStat m_VehicleStatus;

        public ClientCard(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_VehicleInGarage = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = Garage.eVehicleStat.InRepair;

        }

        public static bool IsNameValid(string i_Name)
        {
            bool isValid = false;
            if(i_Name.Length > 0)
            {
                foreach(char ch in i_Name)
                {
                    if(char.IsLetter(ch) == false)
                    {
                        break;
                    }
                    else
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

        public static bool IsPhoneNumberValid(string i_PhoneNum)
        {
            return i_PhoneNum.Length==10 && int.TryParse(i_PhoneNum,out int phoneNum)==true;
        }

        public Vehicle VehicleInGarage
        {
            get
            {
                return m_VehicleInGarage;
            }
            set
            {
                m_VehicleInGarage = value;
            }
        }

        public string Owner
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                if(IsNameValid(value)==false)
                {
                    throw new FormatException("The name must contain letters only");
                }
                m_OwnerName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder clientCardStr = new StringBuilder();
            clientCardStr.AppendLine(VehicleInGarage.ToString());
            clientCardStr.AppendLine(string.Format("Owner name: {0}", Owner));
            clientCardStr.AppendLine(string.Format("Owner phone number: {0}", OwnerPhoneNumber));
            clientCardStr.AppendLine(string.Format("Status: {0}", Status.ToString()));

            return clientCardStr.ToString();
        }
        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }

            set
            {
                if(int.TryParse(value, out int phoneNum) == false)
                {
                    throw new FormatException("The phone number must consist of digits only");
                }
                if(value.Length == 10)
                {
                    throw new ArgumentException("The phone number should be only 10 characters");
                }
                m_OwnerPhoneNumber = value;
            }
        }

        public Garage.eVehicleStat Status
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }

        }
        
    }

}
