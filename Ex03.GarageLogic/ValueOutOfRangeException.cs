using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
     public class ValueOutOfRangeException : Exception
     {
          private float m_MaxValue;
          private float m_MinValue;

          public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
          {
               m_MaxValue = i_MaxValue;
               m_MinValue = i_MinValue;
          }

          //****************Properties******************//  

          public float MaxValue
          {
               get
               {
                    return m_MaxValue;
               }

               set
               {
                    m_MaxValue = value;
               }

          }

          public float MinValue
          {
               get
               {
                    return m_MinValue;
               }

               set
               {
                    m_MinValue = value;
               }
          }

          public string NotifyingString
          {
               get
               {
                    return NotifyingString;
               }

          }

     }

}


//1. המשתמש מחליט איזה סוג רכב הוא רוצה ואת מספר הרישוי שלו
//2. פונים למחלקה המיוחדת הזו ומפעילים את המתודה ומבקשים ממנה מופע.
//3. המתודה נותנת מופע לפי סוג הרכב שביקשנו ממנה ליצור
//4. מבקשים מהמשתמש להזין את הנתונים לגבי הרכב.
//וכו'

// sending to a method for parsing 
// call methods that returns boolean variables for logic test- logic class 
