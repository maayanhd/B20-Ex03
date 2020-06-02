using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Wheel
     {
          private string m_Manufacturor;
          private float m_CurrentWheelPressure;
          private float m_MaximalWheelPressure;


          public string Manufacturor
          {
               get
               {
                    return m_Manufacturor;
               }

               set
               {
                    m_Manufacturor = value;
               }

          }

          public float CurrentWheelPressure
          {
               get
               {
                    return m_CurrentWheelPressure;
               }

               set
               {
                    m_CurrentWheelPressure=value;
               }

          }

          public float MaximalWheelPressure
          {
               get
               {
                    return m_MaximalWheelPressure;
               }

               set
               {
                    m_MaximalWheelPressure = value;
               }

          }

          public virtual bool IsAirPressureValid()
          {
               return m_CurrentWheelPressure >= 0;
          }

          public void Inflate(float i_AirToAdd)
          {

          }

     }

}
