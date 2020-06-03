using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Ex03.GarageLogic
{
     public abstract class Vehicle
     {
          private string m_Model;
          private readonly string m_LicenseNum;
          private float m_EnergyLeftInPercents;
          private readonly List<Wheel> m_Wheels;

          protected List<string> m_MemberInfoStr;
          protected Vehicle(string i_LicenseNumber)
          {
              this.m_LicenseNum= i_LicenseNumber;
               m_Wheels = new List<Wheel>();
               m_MemberInfoStr = new List<string> { "A model" };
          }

          public override int GetHashCode()
          {
              return int.Parse(m_LicenseNum);
          }

          public static bool CheckModelValidity(string i_Model)
          {
              bool isValid = false;
              foreach(char ch in i_Model)
              {
                  isValid = char.IsLetterOrDigit(ch);
                  if(isValid == false)
                  {
                      break;
                  }
              }

              return isValid;

          }
          public override string ToString()
          {
              string vehicleString = string.Format(
                  "Model: {0}{1}Lisence Number: {2}",
                  Model,
                  Environment.NewLine,
                  LicenseNum);

              return vehicleString;
          }

          public override bool Equals(object i_obj)
          {
              Vehicle vehicleToCompare = i_obj as Vehicle;
              bool isEqual = false;

              if(vehicleToCompare != null)
              {
                  isEqual = this.LicenseNum.Equals(vehicleToCompare.LicenseNum);
              }
              else
              {
                  throw new ArgumentException();
              }

              return isEqual;
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

          }

          public static bool CheckLicenseNumValidity(string i_LicenseNum)
          {
              bool isValid = false;
              int licenceNumInt;
              if (i_LicenseNum.Length == 8)
              {
                  isValid = true;
                  foreach(char ch in i_LicenseNum)
                  {
                      if(char.IsDigit(ch)==false)
                      {
                          isValid = false;
                          break;
                      }
                  }
              }

              return isValid;

          }
         
     }

}
