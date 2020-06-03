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

          public Wheel(float i_MaxPressure)
          {
              m_CurrentWheelPressure = 0;
              m_MaximalWheelPressure = i_MaxPressure;
          }

          public Wheel()
          {
              m_CurrentWheelPressure = 0;
          }
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

          public bool IsAirPressureToAddIsValid(float i_AirToAdd)
          {
              return i_AirToAdd <=m_MaximalWheelPressure - m_CurrentWheelPressure;
          }

          public void Inflate(float i_AirToAdd)
          {
              if(IsAirPressureToAddIsValid(i_AirToAdd))
              {
                  m_CurrentWheelPressure += i_AirToAdd;
              }
              else
              {
                  throw new ValueOutOfRangeException(m_MaximalWheelPressure - m_CurrentWheelPressure,0);
              }
          }

     }

}
