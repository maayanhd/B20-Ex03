using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class Wheel
     {
          private string m_Manufacturer;
          private float m_CurrentWheelPressure;
          private float m_MaximalWheelPressure;

          public Wheel(float i_MaxPressure)
          {
              m_CurrentWheelPressure = 0;
              m_MaximalWheelPressure = i_MaxPressure;
          }
          
          //****************Properties******************//  
          public string Manufacturor
          {
               get
               {
                    return m_Manufacturer;
               }

               set
               {
                    m_Manufacturer = value;
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

          public override string ToString()
          {
              StringBuilder strToReturn = new StringBuilder();

              strToReturn.AppendLine(string.Format("Manufacturer:{0}", Manufacturor));
              strToReturn.AppendLine(string.Format("Current wheel pressure:{0} from {1} possible", CurrentWheelPressure,MaximalWheelPressure));
              return strToReturn.ToString();
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

          //****************Validations Methods******************//  
          public bool IsManufactorerValid(string i_Manufacorer)
          {
               bool isValid = false;

               foreach (char ch in i_Manufacorer)
               {
                    isValid = char.IsLetter(ch);

                    if (isValid == false)
                    {
                         break;
                    }

               }

               return isValid;

          }

          public bool IsAirPressureIsValid(float i_AirPressure)
          {
              return i_AirPressure <= m_MaximalWheelPressure - m_CurrentWheelPressure;
          }

          //****************Functionality******************//  
          public void InflateToMaximum()
          {
            Inflate(m_MaximalWheelPressure-m_CurrentWheelPressure);
          }

          public void Inflate(float i_AirToAdd)
          {
              if(IsAirPressureIsValid(i_AirToAdd))
              {
                  m_CurrentWheelPressure += i_AirToAdd;
              }
              else
              {
                  throw new ValueOutOfRangeException(m_MaximalWheelPressure - m_CurrentWheelPressure,0);
              }

          }
          
          // New- update in flow chart
          //****************Assigning Methods******************//  

          void AssignManufacturer(string i_Manufacturer)
          {
               if (IsManufactorerValid(i_Manufacturer) == true)
               {
                    Manufacturor = i_Manufacturer;
               }
               else
               {
                    throw new FormatException("The Manufacturer should consist only letters");
               }

          }

          void AssignCurrentWheelPressure(string i_CurrentAirPressure)
          {
               if (float.TryParse(i_CurrentAirPressure, out float io_CurrentAirPressure) == false)
               {
                    throw new FormatException("The value must be a number");
               }
               else if (IsAirPressureIsValid(io_CurrentAirPressure) == false)
               {
                    throw new ValueOutOfRangeException(MaximalWheelPressure, 0);
               }
               else
               {
                    CurrentWheelPressure = io_CurrentAirPressure;
               }

          }

     }

}
