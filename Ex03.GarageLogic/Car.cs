using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public sealed class Car : Vehicle
     {

          private Color m_CarColor;
          private int m_NumOfDoors;

          public Car(string i_LicenseNumber, Engine i_Engine) : base(i_Engine, i_LicenseNumber)
          {
               m_CarColor = new Color();
               m_NumOfWheels = 4;
               ManageMemberInfo();
               m_Engine = i_Engine;
          }


          public override string ToString()
          {
               StringBuilder carStr = new StringBuilder(base.ToString());
               carStr.AppendLine(string.Format("Color: {0}", CarColor.ToString()));
               carStr.AppendLine(string.Format("Number of doors: {0}", NumOfDoors.ToString()));
               return carStr.ToString();
          }
          public override void ManageMemberInfo()
          {
               NumOfBaseMembers = NumOfWheels * 2 + 2;
               base.ManageMemberInfo();
               AddWheels();
               m_MemberInfoStr.Add("A color");
               m_MemberInfoStr.Add("Number of doors");
          }


          //****************Validation Methods******************//  
          public override bool TryAssignMember(int i_NumOfField, string i_InputStr)
          {
               bool isMemberValid = false;

               if (i_NumOfField < NumOfBaseMembers)
               {
                    isMemberValid = base.TryAssignMember(i_NumOfField, i_InputStr);
               }
               else
               {
                    switch (i_NumOfField - NumOfBaseMembers)
                    {
                         case 0:
                              isMemberValid = Color.TryParse(i_InputStr, out m_CarColor);
                              break;
                         case 1:
                              isMemberValid = int.TryParse(i_InputStr, out int io_NumOfDoors) == true
                                                  ? IsNumOfDoorsValid(io_NumOfDoors)
                                                  : false;
                              if (isMemberValid == true)
                              {
                                   AssignNumOfDoors(i_InputStr);
                              }
                              break;

                    }

               }
               return isMemberValid;

          }

          // new method to update flow chart


          public bool IsNumOfDoorsValid(int i_NumOfDoors)
          {
               return i_NumOfDoors <= 5 && i_NumOfDoors >= 2;
          }

          //****************Enumerations******************//  


          // New- update in flow chart
          //****************Assigning Methods******************//  
          public void AssignNumOfDoors(string i_NumOfDoors)
          {
               int numOfDoors = 0;
               if (int.TryParse(i_NumOfDoors, out numOfDoors) == false)
               {
                    throw new FormatException("Please enter a whole number" + Environment.NewLine);
               }
               else if (IsNumOfDoorsValid(numOfDoors) == false)
               {
                    throw new ValueOutOfRangeException(2, 5);
               }
               else
               {
                    NumOfDoors = numOfDoors;
               }

          }

          //****************Properties******************//  

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
                    return m_Engine;
               }

               set
               {
                    m_Engine = value;
               }

          }

     }

}
