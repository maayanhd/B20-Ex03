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
                m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
            set
            {
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
