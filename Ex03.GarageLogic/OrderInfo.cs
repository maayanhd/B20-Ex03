using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class OrderInfo
    {

        private Vehicle m_VehicleInGarage;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private Garage.eVehicleStat m_VehicleStatus;

        public OrderInfo(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
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

        public static bool IsPhoneNumberValid(int i_PhoneNum)
        {
            bool isValid = false;
            isValid = i_PhoneNum.ToString().Length == 10;

            return isValid;
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
                    throw new ArgumentException();
                }
                m_OwnerName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder orderInfoStr = new StringBuilder();
            orderInfoStr.AppendLine(VehicleInGarage.ToString());
            orderInfoStr.AppendLine(string.Format("Owner name:{0}", Owner));
            orderInfoStr.AppendLine(string.Format("Owner phone number:{0}", OwnerPhoneNumber));

            return orderInfoStr.ToString();
        }
        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
            set
            {
                int phoneNum;
                if(int.TryParse(value, out phoneNum) == false)
                {
                    throw new FormatException();
                }
                else if(IsPhoneNumberValid(phoneNum) == false)
                {
                    throw new ArgumentException();
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
