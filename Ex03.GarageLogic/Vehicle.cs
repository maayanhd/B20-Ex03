using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public abstract class Vehicle
     {
          private readonly string m_Model;
          private readonly string m_LicenseNum;
          private float m_EnergyLeftInPercents;
          private List<Wheel> m_Wheels;

          public Vehicle(string i_Model, string i_LicenseNumber)
          {
               this.m_Model = i_Model;
               this.m_LicenseNum= i_LicenseNumber;
               m_EnergyLeftInPercents = -1;
               m_Wheels = null;
          }

          public string Model
          {
               get
               {
                    return m_Model;
               }

          }
          public string LicenseNum
          {
               get
               {
                    return m_LicenseNum;
               }

          }

          public List<Wheel> Wheels
          {
               get
               {
                    return m_Wheels;
               }

               set
               {
                    m_Wheels=value;
               }

          }

          public abstract bool CheckWheelsValidity();
     }

}
