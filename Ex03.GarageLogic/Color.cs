using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Color
    {
        private eColor? m_EColor;

        public static bool TryParse(string i_ColorString,out Color o_Color)
        {
            bool isValid = false;
            o_Color = null;

            foreach (string color in Enum.GetNames(typeof(eColor)))
            {
                isValid = i_ColorString.Equals(color);
                if (isValid == true)
                {
                   o_Color =new Color();
                   o_Color.m_EColor = (eColor)(Enum.Parse(typeof(eColor), i_ColorString));
                   break;
                }
            }

            return isValid;
        }

        public enum eColor
        {
            Red,
            White,
            Black,
            Silver
        }

        public static string GetPossibleColorsStr()
        {
            StringBuilder colorsStr = new StringBuilder();

            foreach (string color in Enum.GetNames(typeof(eColor)))
            {
                colorsStr.Append(string.Format(" {0}", color));

            }

            return colorsStr.ToString();
        }

        public eColor? EColor
        {
            get
            {
                return m_EColor;
            }

            set
            {
                m_EColor = value;
            }

        }

        public override string ToString()
        {
            return EColor.ToString();
        }
    }
}
